using ERP_Core;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;

namespace TemplateMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : AppERP
    {
        public static Entorno entorno;
        
        public static Boolean MuestraPantallaSeguridad = true;

        public const string KeyDefaultFontSize = "DefaultFontSize"; 
        public const string KeyFixedFontSize = "FixedFontSize";     

        static App()
        {
            //var asd = GetType().Namespace.Split('.')[0];
            ERP_Log4Net.Custom4Net.Initialize(ERP_Common.Helpers.Inicializa.GetAssemblyName());                 

            //Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;  
            //Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;    
        }
        /*
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] param = e.Args.Count() > 0 ? e.Args : null;
            var window = new WindowStart.MainWindow();
            window.Show();
            var resp = ERP_Security.LoginERP.Log(param);

            window.IniWindowAppErp(resp.LoginRequest);
            WindowLocator.ViewModelLocator.MainViewModel.LoadBottomViewModel();

            Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;    
            Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;      
        }
        */



        [MTAThread()]
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            if (e.Args.Count() > 0)
            {
                entorno = new Entorno(e);
            }
            else
            {
                entorno = new Entorno();
            }

            if (Entorno.Conexion == null)
            {
                System.Windows.MessageBox.Show("La configuración de la aplicación esta mal, comunicarse con sistemas: " + Entorno.UltimoError);
                System.Windows.Application.Current.Shutdown();
                return;
            }

            if (entorno.argumentos.Count() >= 2)
            {
                MuestraPantallaSeguridad = false;
            }

            ERP_Entorno.Entorno.Initilize(Entorno.Conexion, Entorno.Password);

            var Main = new View.MainWindow();

            ValidaUsuario(e.Args);

            Main.Show();
        }

        public void ValidaUsuario(string[] args)
        {
            if (App.MuestraPantallaSeguridad)
            {
                var Seguridad = new Seguridad();
                Seguridad.ShowDialog();
                if (!Seguridad.Seguridad == true) System.Windows.Application.Current.Shutdown();
            }
            else
            {
                var usuario = args[0];
                var contraseña = string.Empty;

                if (args.Count() >= 1) contraseña = args[0];

                var mensajeError = string.Empty;
                var numeroError = string.Empty;
                var aux = "J";

                if (!Entorno.EjecutaSeguridad(usuario, contraseña, ref aux, ref mensajeError, ref numeroError))
                {
                    MessageBox.Show("Se produjo el siguiente error al intentar validar los datos: \n" + mensajeError);
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }



    }
}
