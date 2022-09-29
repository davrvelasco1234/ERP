using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters;

namespace PluginHosting
{
    public class IpcServices
    {
        public static bool Registered;
        public static object Mutex = new object();

        public static void RegisterChannel(string portName)
        {
            lock (Mutex)
            {
                if (Registered) return;

                var serverProvider = new BinaryServerFormatterSinkProvider { TypeFilterLevel = TypeFilterLevel.Full };
                var clientProvider = new BinaryClientFormatterSinkProvider();
                var properties = new Hashtable();
                properties["portName"] = portName;

                var channel = new IpcChannel(properties, clientProvider, serverProvider);
                ChannelServices.RegisterChannel(channel, false);
                Registered = true;
            }
        }
    }
}
