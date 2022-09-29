using PluginPruebas.WindowLocator;
using System.Windows;
namespace PluginPruebas
{
    public partial class App : Application
    {
        public App()
        {
            var resp1 = ViewModelLocator.Frame2ViewModel;
            var resp2 = ViewModelLocator.FrameViewModel;
            //var resp3 = ViewModelLocator.BottomViewModel;
        }
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            var Main = new WindowPlugin.MainWindow();
            Main.Show();
        }
    }
}
