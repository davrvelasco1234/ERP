using ERP_MVVM.BaseMVVM;
using ERP_Template.Bottom;
using System.Windows.Media.Imaging;
using TemplateMVVM.ViewModel;


namespace TemplateMVVM.WindowStart
{
    public class MainViewModel : BaseViewModel
    {
        public static FrameTabsViewModel FrameTabsViewModel => WindowLocator.ViewModelLocator.FrameTabsViewModel;

        private BottomViewModel bottomViewModel;
        public BottomViewModel BottomViewModel
        {
            get => bottomViewModel;
            set => SetProperty(ref this.bottomViewModel, value);
        }


        private BitmapImage logoCompany;
        public BitmapImage LogoCompany
        {
            get => logoCompany;
            set => SetProperty(ref this.logoCompany, value);
        }


        public MainViewModel()
        {
            this.LogoCompany = ((BitmapImage)ERP_Images.Images.Logo200.Construccion);
        }

        
        public void LoadBottomViewModel() => this.BottomViewModel = new BottomViewModel();

    }
}
