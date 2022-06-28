
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ERP_Common;
using ERP_Component_1.Identity;
using ERP_Component_1.Models;
using ERP_MVVM.Notification;
using Microsoft.Toolkit.Mvvm.Input;
using static ERP_Common.Helpers.Constantes;



namespace ERP_Component_1.ViewModels.Dialog
{
    public class AutoMtoViewModel : AutoModel
    {
        #region Fields
        public Auto Auto { get; set; }
        #endregion
        

        #region Commands
        public ICommand LoadedCommand => new RelayCommand(Loaded);
        public ICommand AcceptCommand => new RelayCommand<Window>(Accept);
        public ICommand AcceptCerrarCommand => new RelayCommand<Window>(AcceptCerrar);
        public ICommand CancelCommand => new RelayCommand<Window>(Cancel);
        public ICommand GetInfoCommand => new RelayCommand<Window>(GetInfo);
        
        #endregion


        #region Contructors
        public AutoMtoViewModel()
        {
            Inicialize();
            MainComponent.Messenger.GetAutosRegisterMessage(this);
            this.AcceptIsEnabled = true;
        }


        public AutoMtoViewModel(Auto autoParam)
        {
            Inicialize();

            this.Auto = autoParam;

            this.MarcaSelected = this.MarcaList.Where(W => W.Clave == autoParam.IdMarca).FirstOrDefault();
            this.ModeloSelected = this.MarcaSelected.ObservableList.Where(W => W.Clave == autoParam.IdModelo).FirstOrDefault();
            this.CarroceriaSelected = this.CarroceriaList.Where(W => W.Clave == autoParam.IdCarroceria).FirstOrDefault();

            this.Anio = autoParam.Anio;
            this.Color = autoParam.Color;
            this.Precio = autoParam.Precio;
            this.FechaCompra = autoParam.FechaCompra;
            this.Observaciones = autoParam.Observaciones;

            this.AcceptIsEnabled = false;

            MainComponent.Messenger.GetAutosRegisterMessage(this);

        }

        #endregion
        


        #region Loaded
        public void Loaded()
        {
            this.ValidateAllProperties();
        }
        

        public void Inicialize()
        {
            this.MarcaList = GetMarcas();
            this.ModeloList = new ObservableCollection<ErpDictionary>(Data.Querys.Select_ModeloList());         
            this.CarroceriaList = new ObservableCollection<ErpDictionary>(Data.Querys.Select_CarroceriaList());

            this.Auto = new Auto();
            this.Anio = 0;
            this.Color = "";
            this.Precio = 0;
            this.FechaCompra = new System.DateTime(2022, 06, 01);
            this.Observaciones = "";
        }
        #endregion



        #region Methods
        public ObservableCollection<ErpDictionary> GetMarcas()
        {
            var marca = new ObservableCollection<ErpDictionary>(Data.Querys.Select_MarcaList());
            var modelo = Data.Querys.Select_ModeloList();

            foreach (var item in marca)
            {
                item.ObservableList = new ObservableCollection<ErpDictionary>(modelo.Where(W => W.Opcion == item.Clave));
            }

            return marca;
        }



        public ObservableCollection<Auto> AutoList { get; set; }
        public void GetAutos(ObservableCollection<Auto> autoList) => this.AutoList = autoList;

        

        public void GetInfo(Window window)
        {
            MainComponent.Messenger.SendAutosMessage();
            Popup.ExecutePopup(MessageType.Warning, "Title", "Autos " + this.AutoList.Count());
        }

        public void Accept(Window window)
        {
            if (this.HasErrorsProperties)
            {
                Popup.ExecutePopup(MessageType.Warning, "Errores de Captura", "Soluciona los siguienes errores para continuar " + Environment.NewLine + this.GetErrorsMessage);     
                return;
            }

            var resp = new Auto
            {
                IdMarca = this.MarcaSelected.Clave,
                DescMarca = this.MarcaSelected.Descripcion,
                IdModelo = this.ModeloSelected.Clave,
                DescModelo = this.ModeloSelected.Descripcion,
                IdCarroceria = this.CarroceriaSelected.Clave,
                DescCarroceria = this.CarroceriaSelected.Descripcion,
                IdAuto = this.Auto.IdAuto,
                Anio = this.Anio,
                Color = this.Color,
                Precio = this.Precio,
                FechaCompra = this.FechaCompra,
                Observaciones = this.Observaciones
            };

            Inicialize();
        }

        public void AcceptCerrar(Window window)
        {
            //var qwe = this.HasErrorsProperties;
            //var asd = this.GetErrorsProperties();
            //var qqq = this.GetErrorsMessage;

            if (this.HasErrorsProperties)
            {
                Popup.ExecutePopup(MessageType.Warning, "Errores de Captura", "Soluciona los siguienes errores para continuar " + Environment.NewLine + this.GetErrorsMessage);
                return;
            }
            
            
            var resp = new Auto
            {
                IdMarca = this.MarcaSelected.Clave,
                DescMarca = this.MarcaSelected.Descripcion,
                IdModelo = this.ModeloSelected.Clave,
                DescModelo = this.ModeloSelected.Descripcion,
                IdCarroceria = this.CarroceriaSelected.Clave,
                DescCarroceria = this.CarroceriaSelected.Descripcion,
                IdAuto = this.Auto.IdAuto,
                Anio = this.Anio,
                Color = this.Color,
                Precio = this.Precio,
                FechaCompra = this.FechaCompra,
                Observaciones = this.Observaciones
            };

            ErpResponse<Auto> response = new ErpResponse<Auto>(resp);
            this.CloseDialogWithResult(window, response);
        }


        public void Cancel(Window window)
        {
            ErpResponse<Auto> response = new ErpResponse<Auto>("Accion Cancelada");
            this.CloseDialogWithResult(window, null);
        }
        #endregion

    }


}
