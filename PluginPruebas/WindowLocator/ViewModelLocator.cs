using Microsoft.Practices.ServiceLocation;
using MVVM.BaseMVVM;
using MVVM.IoC;
using PluginPruebas.ViewModel;
using PluginPruebas.WindowPlugin;
using Templates.CB.Bottom;



namespace PluginPruebas.WindowLocator
{
    public static class ViewModelLocator
    {
        public static FrameViewModel FrameViewModel { get { return ServiceLocator.Current.GetInstance<FrameViewModel>(); } }
        public static Frame2ViewModel Frame2ViewModel { get { return ServiceLocator.Current.GetInstance<Frame2ViewModel>(); } }
        
        //public static BottomViewModel BottomViewModel { get { return ServiceLocator.Current.GetInstance<BottomViewModel>(); } }


        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<FrameViewModel>();
            SimpleIoc.Default.Register<Frame2ViewModel>();
            //SimpleIoc.Default.Register<BottomViewModel>();


            var manager = new DataTemplateManager();
            manager.RegisterDataTemplate<ViewModel.Dialog.DialogViewModel, View.Dialog.DialogControl>();

        }
    }
}
