
using System;
using ERP_AppDesktop.ViewModels;
using ERP_Entorno.Interfaces;
using ERP_Template.Bottom;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;


namespace ERP_AppDesktop.WindowLocator
{
    public class ViewModelLocator
    {

        public static MainViewModel MainViewModel => Ioc.Default.GetService<MainViewModel>();
        public static ControlsViewModel ControlsViewModel => Ioc.Default.GetService<ControlsViewModel>();
        public static BottomViewModel BottomViewModel => Ioc.Default.GetService<BottomViewModel>();


        static ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(ConfigureService());
        }
        

        private static IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ControlsViewModel>();
            


            //Services
            //services.AddTransient<IExecQuery>(EX => new ExecQuery("Default"));


            
            //Templates
            services.AddSingleton<BottomViewModel>();

            return services.BuildServiceProvider();
        }

        
    }
}
