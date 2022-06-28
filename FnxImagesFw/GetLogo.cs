
using System.Windows.Media;


namespace FnxImagesFw
{
    public class GetLogo
    {
        private readonly string Prefijo = "img_";
        private readonly string Pixeles;
        public GetLogo(string pixeles)
        {
            Pixeles = pixeles;
        }


        public ImageSource FinamexNegativo      => ImagingExtension.GetImageSource(Prefijo + "FinamexNegativo"  + this.Pixeles);
        public ImageSource FinamexPositivo      => ImagingExtension.GetImageSource(Prefijo + "FinamexPositivo"  + this.Pixeles);
        public ImageSource FinamexPositivoT     => ImagingExtension.GetImageSource(Prefijo + "FinamexPositivoT" + this.Pixeles);
        public ImageSource Construccion         => ImagingExtension.GetImageSource(Prefijo + "construccion"     + this.Pixeles);


        public ImageSource LogoFinamex => ImagingExtension.GetImageSource(Prefijo + "FinamexPositivo" + this.Pixeles);

    }
}
