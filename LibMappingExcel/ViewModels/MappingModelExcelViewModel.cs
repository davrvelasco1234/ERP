
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;


using LibMappingExcel.Models;
using LibMappingExcel.Helpers;
using MVVM.BaseMVVM;
using MVVM.Helpers;
using MVVM.Model;
using MVVM.Notification;


namespace LibMappingExcel.ViewModels
{
    internal class MappingModelExcelViewModel<T> : MappingModelExcelViewModel
    {

        #region Attribites
        private PlantillasExcel plantillaExcelSelected = new PlantillasExcel();
        private MappingExcel mappingExcel = null;
        private ObservableCollection<PlantillasExcel> plantillaExcelList = new ObservableCollection<PlantillasExcel>();
        private Propiedades propiedadSelected = new Propiedades();
        private Visibility isVisibilityDelete = Visibility.Visible;

        private Control userControl;
        private int index;
        private string nombrePlantilla;
        private readonly string assemblyName;
        private readonly SqlConnection sqlConnection;
        private Balloon Balloon;
        #endregion


        #region Properties
        public MappingExcel MappingExcel
        {
            get { return this.mappingExcel; }
            set { SetValue(ref this.mappingExcel, value); }
        }
        public Propiedades PropiedadSelected
        {
            get { return this.propiedadSelected; }
            set { SetValue(ref this.propiedadSelected, value); }
        }
        public ObservableCollection<PlantillasExcel> PlantillaExcelList
        {
            get { return this.plantillaExcelList; }
            set { SetValue(ref this.plantillaExcelList, value); }
        }
        public PlantillasExcel PlantillaExcelSelected
        {
            get { return this.plantillaExcelSelected; }
            set { SetValue(ref this.plantillaExcelSelected, value); }
        }
        public string NombrePlantilla
        {
            get { return this.nombrePlantilla; }
            set { SetValue(ref this.nombrePlantilla, value); }
        }
        public Visibility IsVisibilityDelete
        {
            get { return this.isVisibilityDelete; }
            set { SetValue(ref this.isVisibilityDelete, value); }
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand { get { return new RelayCommandMVVM(Loaded); } }
        public ICommand GuardarCommand { get { return new RelayCommandMVVM(Guardar); } }
        public ICommand EliminarCommand { get { return new RelayCommandMVVM(Eliminar); } }
        public ICommand UpdateCommand { get { return new RelayCommandMVVM(Update); } }
        public ICommand SelectionChangedPlantillaCommand { get { return new RelayCommandMVVM(SelectionChangedPlantilla); } }
        public ICommand LostFocusRenglonInicialCommand { get { return new RelayCommandMVVM(LostFocusRenglonInicial); } }
        #endregion


        #region Contructors
        public MappingModelExcelViewModel(string assembly, SqlConnection connection)
        {
            var manager = new DataTemplateManager();
            manager.RegisterDataTemplate<MappingModelExcelViewModel, Views.MappingModelExcelPage>();
            manager.RegisterDataTemplate<MappingValuesModelViewModel, Views.MappingValuesModelPage>();
            
            this.sqlConnection = connection;
            this.assemblyName = assembly;
        }

        public MappingModelExcelViewModel(string assembly, SqlConnection connection, int plantillaID)
        {
            var manager = new DataTemplateManager();
            manager.RegisterDataTemplate<MappingModelExcelViewModel, Views.MappingModelExcelPage>();
            manager.RegisterDataTemplate<MappingValuesModelViewModel, Views.MappingValuesModelPage>();

            this.sqlConnection = connection;
            this.assemblyName = assembly;

            this.PlantillaExcelSelected.Id = plantillaID;
            this.isVisibilityDelete = Visibility.Collapsed;
        }
        #endregion


        #region Events
        internal void Loaded(object param)
        {
            this.userControl = (Control)param;
            
            if (this.PlantillaExcelList is null) { this.PlantillaExcelList = new ObservableCollection<PlantillasExcel>(); }

            if(plantillaExcelSelected.Id != 0)
            {
                this.PlantillaExcelList = (ObservableCollection<PlantillasExcel>)Data.Query.GetPlantillas(this.sqlConnection, this.assemblyName, plantillaExcelSelected.Id).Result;
                this.PlantillaExcelSelected = this.PlantillaExcelList.FirstOrDefault();
                SelectionChangedPlantilla(this.userControl);
            }
            else
            {
                this.PlantillaExcelList = (ObservableCollection<PlantillasExcel>)Data.Query.GetPlantillas(this.sqlConnection, this.assemblyName).Result;
                PlantillasExcel nuevaPlantilla = new PlantillasExcel
                {
                    Id = 0,
                    Descripcion = "Nueva_Plantilla",
                    Proyecto = this.assemblyName,
                    MappingExcel = CreateMapping()
                };
                this.PlantillaExcelList.Insert(0, nuevaPlantilla);
                this.MappingExcel = null;
            }
        }
        #endregion


        #region Methods
        internal void LostFocusRenglonInicial(object param)
        {
            if (!(this.Balloon is null)) { this.Balloon.Close(); }
            if (this.MappingExcel.RenglonInicial < 1)
            {
                this.MappingExcel.RenglonInicial = 0;
                if (!(param is null) && ((Control)param).IsVisible)
                {
                    this.Balloon = new Balloon((Control)param,
                    "Renglon incial invalido",
                    MessageType.Warning);
                    this.Balloon.Show();
                    return;
                }
                return;
            }
        }

        internal MappingExcel CreateMapping()
        {
            ObservableCollection<Propiedades> PropiedadesList = new ObservableCollection<Propiedades>();
            int index = 1;
            T objectGeneric = InstancenGeneric.GetInstance<T>();
            foreach (PropertyInfo property in objectGeneric.GetType().GetProperties())
            {
                string RegularExpression = null;
                string Comentario = null;
                string Constantes = null;
                bool IsVisible = true;
                string InputFormatDate = "";
                string OutputFormatDate = "";
                string valDefault = null;


                System.Type type = property.PropertyType;
                TypeCode    typeCode = System.Type.GetTypeCode(type);
                var asdd = type.BaseType;
                if (typeCode == TypeCode.Object && type.BaseType.FullName == "System.Object")
                {
                    continue;
                }

                string AliasProperty = property.Name;

                ObservableCollection<ValorPropiedades> ValorPropiedadesList = new ObservableCollection<ValorPropiedades>();
                if (!(property.GetCustomAttributesData().Where(
                        A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).FirstOrDefault() is null))
                {
                    if (!(property.GetCustomAttributesData().Where(
                                            A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                            FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.IsVisible.ToString()).
                                            FirstOrDefault().TypedValue.Value is null))
                    {
                        IsVisible = Convert.ToBoolean(property.GetCustomAttributesData().Where(
                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.IsVisible.ToString()).
                                FirstOrDefault().TypedValue.Value);
                        if (!IsVisible)
                        {
                            continue;
                        }
                    }

                    if (!(property.GetCustomAttributesData().Where(
                                            A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                            FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.RegularExpression.ToString()).
                                            FirstOrDefault().TypedValue.Value is null))
                    {
                        RegularExpression = property.GetCustomAttributesData().Where(
                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.RegularExpression.ToString()).
                                FirstOrDefault().TypedValue.Value.ToString();
                    }
                    if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Message.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                    {
                        Comentario = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Message.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();
                    }

                    if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Constans.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                    {
                        Constantes = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Constans.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();
                    }
                    if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Default.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                    {
                        valDefault = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Default.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();
                    }
                    
                    if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.AliasProperty.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                    {
                        AliasProperty = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.AliasProperty.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();
                    }
                    if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.InputFormatDate.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                    {
                        InputFormatDate = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.InputFormatDate.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();
                    }
                    if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.OutputFormatDate.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                    {
                        OutputFormatDate = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.OutputFormatDate.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();
                    }


                }


                if (!(Constantes is null))
                {
                    string[] ListConstantes = Constantes.Split('|');
                    for (int i = 0; i < ListConstantes.Count(); i++)
                    {
                        ValorPropiedades valorPropiedades = new ValorPropiedades
                        {
                            Propiedad = ListConstantes[i],
                            Valor = ListConstantes[i],
                        };
                        ValorPropiedadesList.Add(valorPropiedades);
                    }
                }

                ValorDefault valorDefault = null;
                if(valDefault != null)
                {
                    valorDefault = new ValorDefault { Valor = valDefault };
                }
                else
                {
                    valorDefault = new ValorDefault { IsRequired = true };
                }

                FormatDate formatDate;
                if (typeCode == TypeCode.DateTime)
                {
                    //dd/MM/yyyy
                    if (InputFormatDate == "")
                    {
                        InputFormatDate = "dd/MM/yyyy";
                    }
                    if (OutputFormatDate == "")
                    {
                        OutputFormatDate = "dd/MM/yyyy";
                    }
                    formatDate = new FormatDate { IsDate = true, InputFormatDate = InputFormatDate, OutputFormatDate = OutputFormatDate };
                }
                else if (typeCode == TypeCode.String)
                {
                    if (InputFormatDate != "" || OutputFormatDate != "")
                    {
                        if (InputFormatDate == "")
                        {
                            InputFormatDate = "dd/MM/yyyy";
                        }
                        if (OutputFormatDate == "")
                        {
                            OutputFormatDate = "dd/MM/yyyy";
                        }
                        formatDate = new FormatDate { IsDate = true, InputFormatDate = InputFormatDate, OutputFormatDate = OutputFormatDate };
                    }
                    else
                    {
                        formatDate = new FormatDate { IsDate = false, InputFormatDate = "", OutputFormatDate = "" };
                    }
                }
                else
                {
                    formatDate = new FormatDate { IsDate = false, InputFormatDate = "", OutputFormatDate = "" };
                }



                Propiedades prop = new Propiedades
                {
                    Propiedad = property.Name,
                    Alias = AliasProperty,
                    ColumnaExcel = index,
                    Comentario = Comentario,
                    FormatDate = formatDate,
                    ValorPropiedadesList = new ObservableCollection<ValorPropiedades>(ValorPropiedadesList),
                    ValorDefault = valorDefault
                };
                PropiedadesList.Add(prop);



                index++;
            }


            MappingExcel datos = new MappingExcel
            {
                RenglonInicial = 3,
                MaximoRenglones = 1000,
                NumeroConlumnas = 0,
                MaximoColumnas = 0,
                PropiedadesList = new ObservableCollection<Propiedades>(PropiedadesList)
            };

            return datos;

        }

        internal void SelectionChangedPlantilla(object param)
        {
            if (this.PlantillaExcelSelected is null) { return; }

            string msg = "";
            if (this.PlantillaExcelSelected.Id > 0)
            {
                msg = "MODIFICA la plantilla seleccionada";
            }
            else
            {
                msg = "CREA una nueva plantilla";
            }

            if (!(this.Balloon is null)) { this.Balloon.Close(); }
            if (!(param is null) && ((Control)param).IsVisible)
            {
                this.Balloon = new Balloon((Control)param,
                msg,
                MessageType.Success);
                this.Balloon.Show();
            }

            this.MappingExcel = new MappingExcel();
            this.MappingExcel = this.PlantillaExcelSelected.MappingExcel;
            this.index = this.PlantillaExcelList.IndexOf(this.PlantillaExcelSelected);
            this.NombrePlantilla = this.PlantillaExcelSelected.Descripcion;
        }
        #endregion


        #region Buttons
        internal void Guardar(object param)
        {
            try
            {
                if (!(this.Balloon is null)) { this.Balloon.Close(); }

                XmlDocument asd = XML.ObjectToXml(this.MappingExcel);
                string xml = XML.ObjectToXml(this.MappingExcel).InnerXml;
                string script = "";
                string msg = "";

                if (this.MappingExcel.RenglonInicial < 1)
                {
                    MessageBox.Show("Renglon incial invalido", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (this.PlantillaExcelSelected.Id > 0)
                {
                    script = Data.Query.UpdatePlantilla(this.PlantillaExcelSelected.Proyecto, this.NombrePlantilla, xml, this.PlantillaExcelSelected.Id);
                    msg = "Se actualizo la plantilla ";
                }
                else
                {
                    script = Data.Query.InsertPlantilla(this.assemblyName, this.NombrePlantilla, xml);
                    msg = "Se creo la plantilla ";
                }



                SqlCommand cmd = new SqlCommand(script, this.sqlConnection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

                //Popup.ExecutePopup(MessageType.Success, "", msg);
                MessageBox.Show(msg, "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Loaded(null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        internal void Eliminar(object param)
        {
            if (this.MappingExcel is null || this.PlantillaExcelSelected.Id < 1)
            {
                Popup.ExecutePopup(MessageType.Warning, "", "Selecciona una plantilla");
                return;
            }

            MessageBoxResult resp = MessageBox.Show("Esta a punto de eliminar la plantilla " + this.PlantillaExcelSelected.Descripcion + Environment.NewLine +
                "¿Desea continuar?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resp == MessageBoxResult.No) { return; }

            string script = Data.Query.DeletePlantilla(this.PlantillaExcelSelected.Id);

            SqlCommand cmd = new SqlCommand(script, this.sqlConnection);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se elimino la plantilla ", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            Loaded(null);
        }


        internal void Update(object param)
        {
            Response responseMVVM = new Response();
            int index = MappingExcel.PropiedadesList.IndexOf(PropiedadSelected);
            DialogBaseViewModel PropiedadSelectedViewModel = new MappingValuesModelViewModel((Propiedades)PropiedadSelected.Clone());
            responseMVVM = DialogService.OpenDialog(PropiedadSelectedViewModel, "Modifica Propiedades");

            if (responseMVVM == null || responseMVVM.IsSuccess == false) { return; }

            MappingExcel.PropiedadesList.RemoveAt(index);
            MappingExcel.PropiedadesList.Insert(index, (Propiedades)responseMVVM.Result);
        }

        #endregion

    }

    public class MappingModelExcelViewModel : BaseViewModel
    {

    }

}
