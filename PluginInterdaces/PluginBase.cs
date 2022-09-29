using System;
using System.Windows;

namespace PluginInterdaces
{
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
