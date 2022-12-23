using System;
using System.Diagnostics;
using Unity;
using PluginInterfaces;

namespace ERP_AppDesktop.WindowPlugin
{
    internal class PluginViewOfHost : MarshalByRefObject, IWpfHost
    {
        private readonly IUnityContainer _container;

        public PluginViewOfHost(IUnityContainer container)
        {
            _container = container;
        }

        public void ReportFatalError(string userMessage, string fullExceptionText)
        {
            LastError = new PluginException(userMessage, fullExceptionText);
            if (FatalError != null) FatalError(LastError);
        }

        public int HostProcessId { get { return Process.GetCurrentProcess().Id; } }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public event Action<Exception> FatalError;

        public Exception LastError { get; private set; }

        public override object InitializeLifetimeService()
        {
            return null; // live forever
        }
    }
}
