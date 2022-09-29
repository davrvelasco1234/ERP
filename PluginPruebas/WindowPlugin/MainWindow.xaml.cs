using System.Windows;

namespace PluginPruebas.WindowPlugin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TemplateMVVM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (!SimpleIoc.Default.GetInstance<MainViewModel>().IsEnabledWindow)
            //{
            //    e.Cancel = true;
            //}
        }


    }
}
