using System;

namespace ERP_AppDesktop.WindowPlugin
{
    public class PluginErrorEventArgs : EventArgs
    {
        public PluginErrorEventArgs(Plugin plugin, string message, Exception exception)
        {
            Plugin = plugin;
            Message = message;
            Exception = exception;
        }

        public Plugin Plugin { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }
    }
}