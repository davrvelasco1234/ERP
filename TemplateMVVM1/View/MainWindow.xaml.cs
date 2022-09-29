


using MVVM.IoC;
using TemplateMVVM1.ViewModel;
using DevComponents.WpfRibbon;


namespace TemplateMVVM1.View
{
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TemplateMVVM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!SimpleIoc.Default.GetInstance<MainViewModel>().IsEnabledWindow)
            {
                e.Cancel = true;
            }
        }
    }
}
