using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ERP_Core;
using ERP_Common.Helpers;
using Unity;
using ERP_AppDesktop.Views;
using ERP_AppDesktop.ViewModels;
using ERP_AppDesktop.WindowPlugin;
using PluginHosting.Log;
using Unity.Lifetime;
using PluginInterfaces;

namespace ERP_AppDesktop
{
    public partial class App : AppERP
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string[] param = e.Args.Count() > 0 ? e.Args : null;
            //var window = new Views.MainWindow(WindowLocator.ViewModelLocator.BottomViewModel, param);
            var window = new Views.MainWindow(param);
            window.Show();
            var resp = ERP_Security.LoginERP.Log(param);
            WindowLocator.ViewModelLocator.MainViewModel.InicializaLogIn();

            window.IniWindowAppErp(resp.LoginRequest);
            //WindowLocator.ViewModelLocator.MainViewModel.LoadBottomViewModel();

            //Application.Current.Resources[KeyDefaultFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;
            //Application.Current.Resources[KeyFixedFontSize] = ERP_Common.Helpers.Constantes.FontSizeSmall;
        }

        private IUnityContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            _container = new UnityContainer();
            ConfigureContainer();
            _container.Resolve<ILog>().Info("WpfHost starting");

            var mainWindow = _container.Resolve<MainWindow>();
            var viewModel = _container.Resolve<MainViewModel>();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
            

        }
        protected override void OnExit(ExitEventArgs e)
        {
            _container.Resolve<ILog>().Info("WpfHost shutting down");
            _container.Dispose();
            base.OnExit(e);
        }

        private void ConfigureContainer()
        {
            _container.RegisterType<ErrorHandlingService>(Singleton());
            _container.RegisterInstance<ILog>(new LocalLog().File("WpfHost", LogLevel.Debug), Singleton());
        }

        private static ContainerControlledLifetimeManager Singleton()
        {
            return new ContainerControlledLifetimeManager();
        }


    }

}


