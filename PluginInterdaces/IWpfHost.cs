using System;

namespace PluginInterdaces
{
    public interface IWpfHost : IServiceProvider
    {
        void ReportFatalError(string userMessage, string fullExceptionText);
        int HostProcessId { get; }
    }
}
