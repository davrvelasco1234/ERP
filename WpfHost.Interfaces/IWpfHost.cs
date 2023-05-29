using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHost.Interfaces
{
    /// <summary>
    /// Plugins' view of host
    /// </summary>
    public interface IWpfHost : IServiceProvider
    {
        /// <summary>
        /// Reports fatal plugin error to the host; the plugin will be closed
        /// </summary>
        /// <param name="userMessage">Message explaining the nature of the error</param>
        /// <param name="fullExceptionText">Exception call stack as string</param>
        void ReportFatalError(string userMessage, string fullExceptionText);

        /// <summary>
        /// ID of the host process
        /// </summary>
        int HostProcessId { get; }
    }
}
