
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibMappingExcel.Helpers;
using LibMappingExcel.Models;
using MVVM.BaseMVVM;
using MVVM.Model;
using MVVM.Notification;

namespace LibMappingExcel.ViewModels
{
    internal class MappingValuesModelViewModel : BaseViewModel
    {
        #region Attribites
        private Propiedades propiedad = new Propiedades();
        Balloon Balloon;
        Visibility isVisibilityFormatDate = Visibility.Collapsed;
        bool isCheckedIsRequired = false;
        bool isEnabledValorDeafult = false;
        string textValorDeafult = string.Empty;
        #endregion


        #region Properties
        public Propiedades Propiedad
        {
            get { return this.propiedad; }
            set { SetValue(ref this.propiedad, value); }
        }
        public Visibility IsVisibilityFormatDate
        {
            get { return this.isVisibilityFormatDate; }
            set { SetValue(ref this.isVisibilityFormatDate, value); }
        }

        public bool IsCheckedIsRequired
        {
            get
            {
                this.isCheckedIsRequired = this.propiedad.ValorDefault.IsRequired;
                return this.isCheckedIsRequired;
            }
            set
            {
                this.propiedad.ValorDefault.IsRequired = value;
                this.IsEnabledValorDeafult = !value;
                SetValue(ref this.isCheckedIsRequired, value);
            }
        }

        public bool IsEnabledValorDeafult
        {
            get
            {
                this.isEnabledValorDeafult = !this.IsCheckedIsRequired;
                return this.isEnabledValorDeafult;
            }
            set
            {
                if (!value)
                {
                    this.TextValorDeafult = "";
                }
                SetValue(ref this.isEnabledValorDeafult, value);
            }
        }

        public string TextValorDeafult
        {
            get
            {
                this.textValorDeafult = this.propiedad.ValorDefault.Valor;
                return this.textValorDeafult;
            }
            set
            {
                this.propiedad.ValorDefault.Valor = value;
                SetValue(ref this.textValorDeafult, value);
            }
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand { get { return new RelayCommandMVVM(Loaded); } }
        public ICommand AceptarCommand { get { return new RelayCommandMVVM(Aceptar); } }
        public ICommand CancelarCommand { get { return new RelayCommandMVVM(Cancelar); } }
        public ICommand LostFocusColumnaExcelCommand { get { return new RelayCommandMVVM(LostFocusColumnaExcel); } }
        public ICommand LostFocusInputFormatDateCommand { get { return new RelayCommandMVVM(LostFocusInputFormatDate); } }
        #endregion


        #region Contructors
        public MappingValuesModelViewModel(Propiedades propiedadParam )
        {
            //this.Propiedad = new Propiedades { Alias = propiedadParam.Alias, ColumnaExcel = propiedadParam.ColumnaExcel, Comentario = propiedadParam.Comentario, FormatDate = propiedadParam.FormatDate, Propiedad = propiedadParam.Propiedad, ValorDefault = new ValorDefault { IsRequired = propiedadParam.ValorDefault.IsRequired, Valor = propiedadParam.ValorDefault.Valor }, ValorPropiedadesList = propiedadParam.ValorPropiedadesList };
            this.propiedad = propiedadParam;
            if (this.Propiedad.FormatDate.IsDate)
            {
                this.IsVisibilityFormatDate = Visibility.Visible;
            }

            //if (!this.Propiedad.ValorDefault.IsRequired)
            //{
            //    this.IsCheckedIsRequired = this.Propiedad.ValorDefault.IsRequired;
            //}

        }
        #endregion


        #region Events
        public void Loaded(object param)
        {

        }
        #endregion


        #region Methods
        private void LostFocusColumnaExcel(object param)
        {
            if (this.Propiedad.ColumnaExcel < 1)
            {
                if (!(this.Balloon is null)) { this.Balloon.Close(); }
                if (!(param is null) && ((Control)param).IsVisible)
                {
                    this.Balloon = new Balloon((Control)param,
                    "Numero del columna invalido",
                    MessageType.Warning);
                    this.Balloon.Show();
                }
            }
        }


        private void LostFocusInputFormatDate(object param)
        {
            bool resp = ValidateFormat.ValidateFormatDate(this.Propiedad.FormatDate.InputFormatDate);

            if (!resp)
            {
                if (!(this.Balloon is null)) { this.Balloon.Close(); }
                if (!(param is null) && ((Control)param).IsVisible)
                {
                    this.Balloon = new Balloon((Control)param,
                    "Formato de Fecha Invalido",
                    MessageType.Warning);
                    this.Balloon.Show();
                }
            }
        }


        public void Aceptar(object param)
        {
            if (this.Propiedad.ColumnaExcel < 1)
            {
                Popup.ExecutePopup(MessageType.Warning, "", "Numero del columna invalido");
                return;
            }

            bool resp = ValidateFormat.ValidateFormatDate(this.Propiedad.FormatDate.InputFormatDate);
            if (!resp && this.Propiedad.FormatDate.IsDate)
            {
                Popup.ExecutePopup(MessageType.Warning, "", "Formato de Fecha Invalido");
                return;
            }


            Response responseMVVM = new Response();
            responseMVVM.IsSuccess = true;
            responseMVVM.Message = "";
            responseMVVM.MessageType = MessageType.Success;
            responseMVVM.Result = this.Propiedad;
            this.CloseDialogWithResult(param as Window, responseMVVM);
        }

        public void Cancelar(object param)
        {
            Response responseMVVM = new Response();
            responseMVVM.IsSuccess = false;
            responseMVVM.Message = "Accion cancelada";
            responseMVVM.MessageType = MessageType.Warning;
            responseMVVM.Result = null;
            this.CloseDialogWithResult(param as Window, responseMVVM);
        }


        

        #endregion

    }
}
