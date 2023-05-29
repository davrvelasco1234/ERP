
using System;
using System.Windows;


namespace WpfHost.Interfaces
{
    /// <summary>
    /// Interface for user-defined plugin
    /// </summary>
    public interface IPlugin : IServiceProvider, IDisposable
    {
        /// <summary>
        /// Creates plugin's visual element; called only ones in plugin's lifetime
        /// </summary>
        /// <returns>WPF framework element of the plugin</returns>
        FrameworkElement CreateControl();
    }
}
