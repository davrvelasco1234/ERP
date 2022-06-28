using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;


namespace ERP_Log4Net
{
    public static class Custom4Net
    {
        private static ILog _log = null;
        private static string _logFile = null;

        public static void Initialize(string name, string nameFileConfig = "Log4Net.config")
        {
            var pathIni = ERP_Common.Helpers.Inicializa.GetAssemblyDirectory();
            var ApplicationPath = System.IO.Path.Combine(pathIni, "..\\");
            _logFile = Path.Combine(ApplicationPath, "Logs4Net", name, name + ".log");
            GlobalContext.Properties["LogFileName"] = _logFile;
            string pathConfig = Path.Combine(ApplicationPath, nameFileConfig);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(pathConfig));
            _log = LogManager.GetLogger(name);

            Process currentProcess = Process.GetCurrentProcess();

            var qwe = Assembly.GetExecutingAssembly().Location;
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(assemblyFolder, "AggregatorItems.xml");

            var resp1 = currentProcess.MainModule.ModuleName;
            var resp2 = currentProcess.MainModule.FileName;
        }

        public static string LogFile
        {
            get { return _logFile; }
        }


        public enum TracingLevel
        {
            ALL, DEBUG, INFO, WARN, ERROR, FATAL, OFF
        }


        public static void LogMessage(TracingLevel Level, string Message)
        {
            switch (Level)
            {
                case TracingLevel.DEBUG:
                    _log.Debug(Message);
                    break;

                case TracingLevel.INFO:
                    _log.Info(Message);
                    break;

                case TracingLevel.WARN:
                    _log.Warn(Message);
                    break;

                case TracingLevel.ERROR:
                    _log.Error(Message);
                    break;

                case TracingLevel.FATAL:
                    _log.Fatal(Message);
                    break;
            }
        }

        public static void LogMessage(TracingLevel Level, string Message, System.Exception exception)
        {
            switch (Level)
            {
                case TracingLevel.DEBUG:
                    _log.Debug(Message, exception);
                    break;

                case TracingLevel.INFO:
                    _log.Info(Message, exception);
                    break;

                case TracingLevel.WARN:
                    _log.Warn(Message, exception);
                    break;

                case TracingLevel.ERROR:
                    _log.Error(Message, exception);
                    break;

                case TracingLevel.FATAL:
                    _log.Fatal(Message, exception);
                    break;
            }
        }

    }
}
