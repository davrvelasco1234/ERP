using System;
using System.Windows;

namespace PluginInterdaces
{
    public interface IPlugin : IServiceProvider, IDisposable
    {
        FrameworkElement CreateControl();
    }
}
