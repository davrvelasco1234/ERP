using System;
using System.Configuration;
using System.IO;
using PluginHosting;

namespace PluginProcess
{
    class Program
    {
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        static void Main(string[] args)
        {
            bool breakIntoDebugger = bool.Parse(ConfigurationManager.AppSettings["BreakIntoDebugger"]); 
            if (breakIntoDebugger) System.Diagnostics.Debugger.Break();                                 

            bool pauseOnError = bool.Parse(ConfigurationManager.AppSettings["PauseOnError"]);           

            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: PluginProcess name assemblyPath");
                if (pauseOnError) Console.ReadLine();
                return;
            }

            try
            {
                var name = args[0];
                int bits = IntPtr.Size * 8;
                Console.WriteLine("Starting PluginProcess {0}, {1} bit", name, bits);

                var assemblyPath = args[1];
                Console.WriteLine("Plugin assembly: {0}", assemblyPath);

                CheckFileExists(assemblyPath);
                var configFile = GetConfigFile(assemblyPath);

                var appBase = Path.GetDirectoryName(assemblyPath);
                
                var appDomain = CreateAppDomain(appBase, configFile);
                var bootstrapper = CreateInstanceFrom<PluginLoaderBootstrapper>(appDomain);
                bootstrapper.Run(name);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                if (pauseOnError)
                {
                    Console.Error.WriteLine("Pausing on error, press any key to exit...");
                    Console.ReadLine();
                }
            }
        }

        private static T CreateInstanceFrom<T>(AppDomain appDomain)
        {
            return (T)appDomain.CreateInstanceFromAndUnwrap(typeof(T).Assembly.Location, typeof(T).FullName);
        }

        private static void CheckFileExists(string path)
        {
            if (!File.Exists(path)) throw new InvalidOperationException("File '" + path + "' does not exist");
        }

        private static string GetConfigFile(string assemblyPath)
        {
            var name = assemblyPath + ".config";
            return File.Exists(name) ? name : null;
        }

        private static AppDomain CreateAppDomain(string appBase, string config)
        {
            var setup = new AppDomainSetup
            {
                ApplicationBase = appBase,
                ConfigurationFile = String.IsNullOrEmpty(config)? null : config
            };

            return AppDomain.CreateDomain("PluginDomain", null, setup);
        }
    }
}
