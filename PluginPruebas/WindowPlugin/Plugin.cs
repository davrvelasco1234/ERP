using System.Windows;
using PluginInterdaces;

namespace PluginPruebas.WindowPlugin
{
    public class Plugin : PluginBase
    {
        public override FrameworkElement CreateControl()
        {
            return new PluginControl();
        }
    }
}



