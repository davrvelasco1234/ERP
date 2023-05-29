using System;
using System.AddIn.Contract;

namespace PluginHosting
{
    public interface IRemotePlugin : IServiceProvider, IDisposable
    {
        INativeHandleContract Contract { get; }
    }
}
