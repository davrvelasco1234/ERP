using System;

namespace PluginHosting
{
    public class PluginLoaderBootstrapper : MarshalByRefObject
    {
        public void Run(string name)
        {
            new PluginLoader().Run(name);
        }
    }
}
