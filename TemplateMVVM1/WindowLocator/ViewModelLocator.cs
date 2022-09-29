

using System.ComponentModel;

using Microsoft.Practices.ServiceLocation;
using MVVM.IoC;
using TemplateMVVM1.ViewModel;
using Templates.CB.Bottom;



namespace TemplateMVVM1.WindowLocator
{
    public class ViewModelLocator
    {
        //[Description]

        public MainViewModel MainViewModel { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }
        public FrameViewModel FrameViewModel { get { return ServiceLocator.Current.GetInstance<FrameViewModel>(); } }
        public Frame2ViewModel Frame2ViewModel { get { return ServiceLocator.Current.GetInstance<Frame2ViewModel>(); } }


        public BottomViewModel BottomViewModel { get { return ServiceLocator.Current.GetInstance<BottomViewModel>(); } }


        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FrameViewModel>();
            SimpleIoc.Default.Register<Frame2ViewModel>();
            SimpleIoc.Default.Register<BottomViewModel>();

        }
    }
}
