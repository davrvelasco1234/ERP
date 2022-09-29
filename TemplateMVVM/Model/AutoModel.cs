using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ERP_Common;
using ERP_MVVM.BaseMVVM;

namespace TemplateMVVM.Model
{
    public class AutoModel : BaseViewModel<Auto>
    {
        private ObservableCollection<ErpDictionary> marcaList;
        public ObservableCollection<ErpDictionary> MarcaList
        {
            get => this.marcaList;
            set => SetProperty(ref this.marcaList, value);
        }

        private ErpDictionary marcaSelected;
        [Required(ErrorMessage = "Selecciona una Marca")]
        public ErpDictionary MarcaSelected
        {
            get => this.marcaSelected;
            set => SetProperty(ref this.marcaSelected, value, true);
        }

        private ObservableCollection<ErpDictionary> modeloList;
        public ObservableCollection<ErpDictionary> ModeloList
        {
            get => this.modeloList;
            set => SetProperty(ref this.modeloList, value);
        }

        private ErpDictionary modeloSelected;
        [Required(ErrorMessage = "Selecciona una Modelo")]
        public ErpDictionary ModeloSelected
        {
            get => this.modeloSelected;
            set => SetProperty(ref this.modeloSelected, value, true);
        }

        private ObservableCollection<ErpDictionary> carroceriaList;
        public ObservableCollection<ErpDictionary> CarroceriaList
        {
            get => this.carroceriaList;
            set => SetProperty(ref this.carroceriaList, value);
        }

        private ErpDictionary carroceriaSelected;
        [Required(ErrorMessage = "Selecciona una Carroceria")]
        public ErpDictionary CarroceriaSelected
        {
            get => this.carroceriaSelected;
            set => SetProperty(ref this.carroceriaSelected, value, true);
        }

        private int anio;
        [Required(ErrorMessage = "Captura un Año")]
        [Range(1900, 2030, ErrorMessage = "El rango valido para Año es entre 1900 y 2030")]
        public int Anio
        {
            get => this.anio;
            set => SetProperty(ref this.anio, value, true);
        }

        private string color;
        [Required(ErrorMessage = "Captura un color")]
        public string Color
        {
            get => this.color;
            set => SetProperty(ref this.color, value, true);
        }

        private decimal precio;
        [Required(ErrorMessage = "Captura un precio")]
        [Range(50000, 1000000, ErrorMessage = "El rango valido para Precio es entre 50,000.00 y 1,000,000.00")]
        public decimal Precio
        {
            get => this.precio;
            set => SetProperty(ref this.precio, value, true);
        }

        private DateTime fechaCompra;
        [Required(ErrorMessage = "Indica la fecha de compra")]
        [Range(typeof(DateTime), "2000/01/01", "2050/01/01", ErrorMessage = "Rango Invalido de fechas")]
        public DateTime FechaCompra
        {
            get => this.fechaCompra;
            set => SetProperty(ref this.fechaCompra, value, true);
        }

        private string observaciones;
        [Required(ErrorMessage = "Danos tus observaciones")]
        public string Observaciones
        {
            get => this.observaciones;
            set => SetProperty(ref this.observaciones, value, true);
        }


        private bool acceptIsEnabled;
        public bool AcceptIsEnabled
        {
            get => this.acceptIsEnabled;
            set => SetProperty(ref this.acceptIsEnabled, value);
        }


    }

}
