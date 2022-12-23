using System;
using ERP_MVVM.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using TemplateMVVM.Messaging;
using TemplateMVVM.ViewModel;
using TemplateMVVM.WindowStart;

namespace TemplateMVVM.WindowLocator
{
    public static class ViewModelLocator
    {
        public static MainViewModel MainViewModel => Ioc.Default.GetService<MainViewModel>();

        public static FrameTabsViewModel FrameTabsViewModel => Ioc.Default.GetService<FrameTabsViewModel>();


        public static FrameContentViewModel FrameContentViewModel => Ioc.Default.GetService<FrameContentViewModel>();


        //public static BottomViewModel BottomViewModel => Ioc.Default.GetService<BottomViewModel>();
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
            services.AddSingleton<FrameTabsViewModel>();
            services.AddSingleton<FrameContentViewModel>();

            //Messenger
            services.AddSingleton<Messenger>();

            //Templates
            //services.AddSingleton<BottomViewModel>();

            return services.BuildServiceProvider();
        }


        //se registran las ventana de dialogo
        private static void RegisterDialogs()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModel.FrameTabsViewModel, View.FrameTabsControl>();
            DataTemplateManager.RegisterDataTemplate<ViewModel.Dialog.MtoViewModel, View.Dialog.MtoControl>();
        }
    }
}


