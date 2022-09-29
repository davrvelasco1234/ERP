
using System;

namespace ERP_AppDesktop.WindowPlugin
{
    class PluginException : Exception
    {
        private readonly string _fullExceptionText; 

        public PluginException(string userMessage, string fullExceptionText) : base(userMessage)
        {
            _fullExceptionText = fullExceptionText;
        }

        public override string ToString()
        {
            return "Plugin exception: " + _fullExceptionText;
        }
    }
}
