using System;
using System.Reflection;
using WpfHost.Interfaces;

namespace PluginHosting
{
    class AssemblyResolver
    {
        private string _thisAssemblyName;
        private string _interfacesAssemblyName;
        public void Setup()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
            _thisAssemblyName = GetType().Assembly.GetName().Name;
            _interfacesAssemblyName = typeof(IWpfHost).Assembly.GetName().Name;

        }

        private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var name = new AssemblyName(args.Name);

            if (name.Name == _thisAssemblyName) return GetType().Assembly;
            if (name.Name == _interfacesAssemblyName) return typeof(IWpfHost).Assembly;

            return null;
        }

    }
}
