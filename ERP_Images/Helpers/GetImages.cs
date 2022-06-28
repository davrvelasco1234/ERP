using System.Windows.Media;

namespace ERP_Images.Helpers
{
    public class GetImages
    {
        private readonly string Prefijo = "img_";
        private readonly string Pixeles;
        public GetImages(string pixeles)
        {
            Pixeles = pixeles;
        }

        public ImageSource accept => ImagingExtension.GetImageSource(Prefijo + "accept" + this.Pixeles);
        public ImageSource add => ImagingExtension.GetImageSource(Prefijo + "add" + this.Pixeles);
        public ImageSource admin => ImagingExtension.GetImageSource(Prefijo + "admin" + this.Pixeles);
        public ImageSource Ajustes => ImagingExtension.GetImageSource(Prefijo + "Ajustes" + this.Pixeles);
        public ImageSource alta_baja => ImagingExtension.GetImageSource(Prefijo + "alta_baja" + this.Pixeles);
        public ImageSource ApretonManos => ImagingExtension.GetImageSource(Prefijo + "ApretonManos" + this.Pixeles);
        public ImageSource asignar => ImagingExtension.GetImageSource(Prefijo + "asignar" + this.Pixeles);
        public ImageSource asigna_all => ImagingExtension.GetImageSource(Prefijo + "asigna_all" + this.Pixeles);
        public ImageSource Banco => ImagingExtension.GetImageSource(Prefijo + "Banco" + this.Pixeles);
        public ImageSource Calendar => ImagingExtension.GetImageSource(Prefijo + "Calendar" + this.Pixeles);
        public ImageSource Calendario => ImagingExtension.GetImageSource(Prefijo + "Calendario" + this.Pixeles);
        public ImageSource CambiarEdo => ImagingExtension.GetImageSource(Prefijo + "CambiarEdo" + this.Pixeles);
        public ImageSource cancel => ImagingExtension.GetImageSource(Prefijo + "cancel" + this.Pixeles);
        public ImageSource carteras => ImagingExtension.GetImageSource(Prefijo + "carteras" + this.Pixeles);
        public ImageSource clean => ImagingExtension.GetImageSource(Prefijo + "clean" + this.Pixeles);
        public ImageSource cleanFilter => ImagingExtension.GetImageSource(Prefijo + "cleanFilter" + this.Pixeles);
        public ImageSource Clientes => ImagingExtension.GetImageSource(Prefijo + "Clientes" + this.Pixeles);
        public ImageSource ClienteUnico => ImagingExtension.GetImageSource(Prefijo + "ClienteUnico" + this.Pixeles);
        public ImageSource config => ImagingExtension.GetImageSource(Prefijo + "config" + this.Pixeles);
        public ImageSource confirmar => ImagingExtension.GetImageSource(Prefijo + "confirmar" + this.Pixeles);
        public ImageSource confirma_all => ImagingExtension.GetImageSource(Prefijo + "confirma_all" + this.Pixeles);
        public ImageSource Contrato => ImagingExtension.GetImageSource(Prefijo + "Contrato" + this.Pixeles);
        public ImageSource DownloadExcel => ImagingExtension.GetImageSource(Prefijo + "DownloadExcel" + this.Pixeles);
        public ImageSource Efectivo => ImagingExtension.GetImageSource(Prefijo + "Efectivo" + this.Pixeles);
        public ImageSource Ejecucion => ImagingExtension.GetImageSource(Prefijo + "Ejecucion" + this.Pixeles);
        public ImageSource ejecutar => ImagingExtension.GetImageSource(Prefijo + "ejecutar" + this.Pixeles);
        public ImageSource ejecuta_all => ImagingExtension.GetImageSource(Prefijo + "ejecuta_all" + this.Pixeles);
        public ImageSource emailGo => ImagingExtension.GetImageSource(Prefijo + "emailGo" + this.Pixeles);
        public ImageSource excel => ImagingExtension.GetImageSource(Prefijo + "excel" + this.Pixeles);
        public ImageSource FinamexNegativo => ImagingExtension.GetImageSource(Prefijo + "FinamexNegativo" + this.Pixeles);
        public ImageSource Ganancias => ImagingExtension.GetImageSource(Prefijo + "Ganancias" + this.Pixeles);
        public ImageSource getOut => ImagingExtension.GetImageSource(Prefijo + "getOut" + this.Pixeles);
        public ImageSource Global => ImagingExtension.GetImageSource(Prefijo + "Global" + this.Pixeles);
        public ImageSource goUp => ImagingExtension.GetImageSource(Prefijo + "goUp" + this.Pixeles);
        public ImageSource Grafico => ImagingExtension.GetImageSource(Prefijo + "Grafico" + this.Pixeles);
        public ImageSource ImportExcel => ImagingExtension.GetImageSource(Prefijo + "ImportExcel" + this.Pixeles);
        public ImageSource imprimir => ImagingExtension.GetImageSource(Prefijo + "imprimir" + this.Pixeles);

        public ImageSource IconFinamex => ImagingExtension.GetImageSource(Prefijo + "FinamexNegativo" + this.Pixeles);

        public ImageSource ListaVerificacio => ImagingExtension.GetImageSource(Prefijo + "ListaVerificacio" + this.Pixeles);
        public ImageSource mailserver => ImagingExtension.GetImageSource(Prefijo + "mailserver" + this.Pixeles);
        public ImageSource modify => ImagingExtension.GetImageSource(Prefijo + "modify" + this.Pixeles);
        public ImageSource No => ImagingExtension.GetImageSource(Prefijo + "No" + this.Pixeles);
        public ImageSource Notes => ImagingExtension.GetImageSource(Prefijo + "Notes" + this.Pixeles);
        public ImageSource page_white => ImagingExtension.GetImageSource(Prefijo + "page_white" + this.Pixeles);
        public ImageSource pdf => ImagingExtension.GetImageSource(Prefijo + "pdf" + this.Pixeles);
        public ImageSource perfiles => ImagingExtension.GetImageSource(Prefijo + "perfiles" + this.Pixeles);
        public ImageSource periodos => ImagingExtension.GetImageSource(Prefijo + "periodos" + this.Pixeles);
        public ImageSource Porcent => ImagingExtension.GetImageSource(Prefijo + "Porcent" + this.Pixeles);
        public ImageSource porcentajes => ImagingExtension.GetImageSource(Prefijo + "porcentajes" + this.Pixeles);
        public ImageSource procesar => ImagingExtension.GetImageSource(Prefijo + "procesar" + this.Pixeles);
        public ImageSource refresh => ImagingExtension.GetImageSource(Prefijo + "refresh" + this.Pixeles);
        public ImageSource remove => ImagingExtension.GetImageSource(Prefijo + "remove" + this.Pixeles);
        public ImageSource save => ImagingExtension.GetImageSource(Prefijo + "save" + this.Pixeles);
        public ImageSource socialMedia => ImagingExtension.GetImageSource(Prefijo + "socialMedia" + this.Pixeles);
        public ImageSource TarjetaCredito => ImagingExtension.GetImageSource(Prefijo + "TarjetaCredito" + this.Pixeles);
        public ImageSource timecalendar => ImagingExtension.GetImageSource(Prefijo + "timecalendar" + this.Pixeles);
        public ImageSource userRole => ImagingExtension.GetImageSource(Prefijo + "userRole" + this.Pixeles);
        public ImageSource users => ImagingExtension.GetImageSource(Prefijo + "users" + this.Pixeles);
        public ImageSource view => ImagingExtension.GetImageSource(Prefijo + "view" + this.Pixeles);

    }

}
