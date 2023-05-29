using System;
using System.Windows;


namespace WpfHost.Interfaces
{
    /// <summary>
    /// Recommended (but not requried) base class for user-defined plugins
    /// </summary>
    public abstract class PluginBase : MarshalByRefObject, IPlugin
    {
        public abstract FrameworkElement CreateControl();

        public virtual object GetService(Type serviceType)
        {
            if (serviceType.IsAssignableFrom(GetType())) return this;
            return null;
        }

        public virtual void Dispose()
        {
        }

        public override object InitializeLifetimeService()
        {
            return null; // live forever
        }
    }
}
