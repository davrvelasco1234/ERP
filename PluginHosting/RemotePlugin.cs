using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;
using PluginInterdaces;

namespace PluginHosting
{
    internal class RemotePlugin : MarshalByRefObject, IRemotePlugin
    {
        private readonly IPlugin _plugin;
        
        public RemotePlugin(IPlugin plugin)
        {
            _plugin = plugin;
            var control = plugin.CreateControl();
            var localContract = FrameworkElementAdapters.ViewToContractAdapter(control);
            Contract = new NativeHandleContractInsulator(localContract);
        }

        public INativeHandleContract Contract { get; private set; }

        public object GetService(Type serviceType)
        {
            return _plugin.GetService(serviceType);
        }

        public void Dispose()
        {
            _plugin.Dispose();
        }

        public override object InitializeLifetimeService()
        {
            return null; // live forever
        }
    }
}
