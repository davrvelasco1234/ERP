using System.Linq;
using System.Windows;
using ERP_Core;

namespace ERP_AppDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : AppERP
    {

        public App()
        {

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] param = e.Args.Count() > 0 ? e.Args : null;
            var window = new MainWindow(WindowLocator.ViewModelLocator.BottomViewModel, param);
            window.Show();



            var resp = ERP_AppDesktop.Helpers.LogIn.Log(param);
            WindowLocator.ViewModelLocator.MainViewModel.InicializaLogIn();


        }

    }

}
