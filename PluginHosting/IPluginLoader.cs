using System;
using WpfHost.Interfaces;

namespace PluginHosting
{
    public interface IPluginLoader : IDisposable
    {
        IRemotePlugin LoadPlugin(IWpfHost host, PluginStartupInfo startupInfo);
    }
}
