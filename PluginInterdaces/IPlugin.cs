using System;
using System.Windows;

namespace PluginInterfaces
{
    public interface IPlugin : IServiceProvider, IDisposable
    {
        FrameworkElement CreateControl();
    }
}
