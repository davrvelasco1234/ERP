using ERP_Core;
using System.Linq;
using System.Windows;

namespace TemplateMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : AppERP
    {
        public const string KeyDefaultFontSize = "DefaultFontSize"; 
        public const string KeyFixedFontSize = "FixedFontSize";     

        static App()
        {
            //var asd = GetType().Namespace.Split('.')[0];
            ERP_Log4Net.Custom4Net.Initialize(ERP_Common.Helpers.Inicializa.GetAssemblyName());
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] param = e.Args.Count() > 0 ? e.Args : null;
            var window = new View.MainWindow();
            window.Show();
            var resp = ERP_Security.LoginERP.Log(param);

            window.IniWindowAppErp(resp.LoginRequest);
            WindowLocator.ViewModelLocator.MainViewModel.LoadBottomViewModel();

            Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;    
            Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;      
        }
    }
}
