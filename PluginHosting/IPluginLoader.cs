using System;
using PluginInterdaces;

namespace PluginHosting
{
    public interface IPluginLoader : IDisposable
    {
        IRemotePlugin LoadPlugin(IWpfHost host, PluginStartupInfo startupInfo);
    }
}
