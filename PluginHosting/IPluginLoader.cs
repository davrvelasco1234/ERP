using System;
using PluginInterfaces;

namespace PluginHosting
{
    public interface IPluginLoader : IDisposable
    {
        IRemotePlugin LoadPlugin(IWpfHost host, PluginStartupInfo startupInfo);
    }
}
