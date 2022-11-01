
using ERP_MVVM.BaseMVVM;
using ERP_Template.Bottom;
using System.Windows.Media.Imaging;


namespace TemplateMVVM.ViewModel
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
            this.LogoCompany = ((BitmapImage)ERP_Images.Images.Logo400.FinamexPositivoT);
        }

        //public void LoadBottomViewModel() 
        //    => this.BottomViewModel = WindowLocator.ViewModelLocator.BottomViewModel;


        public void LoadBottomViewModel() => this.BottomViewModel = new BottomViewModel();
    }
}
