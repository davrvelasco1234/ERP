using System;
using System.Data.SqlClient;
using ERP_Entorno;
using ERP_MVVM.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using TemplateMVVM.Messaging;
using TemplateMVVM.ViewModel;
using Templates.CB.Bottom;


namespace TemplateMVVM.WindowLocator
{
    public static class ViewModelLocator
    {
        public static MainViewModel MainViewModel => Ioc.Default.GetService<MainViewModel>();       
        public static FrameViewModel FrameViewModel => Ioc.Default.GetService<FrameViewModel>();          
        public static BottomViewModel BottomViewModel => Ioc.Default.GetService<BottomViewModel>();
        public static Messenger Messenger => Ioc.Default.GetService<Messenger>();
        

        static ViewModelLocator()
        {
            //Entorno entorno = new Entorno();
            Ioc.Default.ConfigureServices(ConfigureService());
            RegisterDialogs();
        }

        private static IServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();

            //ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<FrameViewModel>();

            //Messenger
            services.AddSingleton<Messenger>();
            

            //Services
            //services.AddTransient<IExecQuery>(EX => new ExecQuery("Default"));

            //Templates
            services.AddSingleton<BottomViewModel>();

            return services.BuildServiceProvider();
        }


        //se registran las ventana de dialogo
        private static void RegisterDialogs()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModel.Dialog.MtoViewModel, View.Dialog.MtoControl>();
        }
    }
}


