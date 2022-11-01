using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ERP_Core;
using ERP_Common.Helpers;
using Unity;

namespace ERP_AppDesktop
{
    public partial class App : AppERP
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] param = e.Args.Count() > 0 ? e.Args : null;
            var window = new Views.MainWindow(WindowLocator.ViewModelLocator.BottomViewModel, param);
            window.Show();
            var resp = ERP_Security.LoginERP.Log(param);
            WindowLocator.ViewModelLocator.MainViewModel.InicializaLogIn();
        }

    }

}


