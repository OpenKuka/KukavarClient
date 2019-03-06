using NLog;
using NLog.Config;
using System;
using System.Reflection;
using System.IO;

namespace Kukavar
{
    public class KukavarLogManager
    {
        // A Logger dispenser for the current assembly (Remember to call Flush on application exit)
        public static LogFactory Instance { get { return _instance.Value; } }
        private static Lazy<LogFactory> _instance = new Lazy<LogFactory>(BuildLogFactory2);
        public static Logger GetLogger(int guid) => Instance.GetLogger(guid.ToString());

        // Use a config file located next to our current assembly dll 
        // eg, if the running assembly is c:\path\to\MyComponent.dll 
        // the config filepath will be c:\path\to\MyComponent.nlog 
        // 
        // WARNING: This will not be appropriate for assemblies in the GAC 
        // 
        private static LogFactory BuildLogFactory()
        {
            // Use name of current assembly to construct NLog config filename 
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string configFilePath = Path.ChangeExtension(thisAssembly.Location, ".nlog");

            LogFactory logFactory = new LogFactory();
            logFactory.Configuration = new XmlLoggingConfiguration(configFilePath, true, logFactory);
            return logFactory;
        }

        private static LogFactory BuildLogFactory2()
        {

            LogFactory logFactory = new LogFactory();

            var config = new LoggingConfiguration();

            var logconsole = new NLog.Targets.ConsoleTarget("logconsole")
            {
                Layout = @"[${date:format=HH\:mm\:ss | fff}ms | Id ${pad:padding=3:inner=#${logger}} | ${pad:padding=5:inner=#${level:uppercase=true}}] : ${message}${when:when=length('${exception}')>0:Inner= | EXCEPTION}",
            };
            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                Layout = @"[${date:format=yyyy-MM-dd HH\:mm\:ss | fff}ms | ${pad:padding=3:inner=#${logger:format=00}} | ${pad:padding=6:inner=#${level:uppercase=true}}] : ${message}${when:when=length('${exception}')>0:inner=${exception:format=tostring}:}",
                FileName = "file.txt",
                FileNameKind = NLog.Targets.FilePathKind.Relative,
            };
            var logsentinel = new NLog.Targets.NLogViewerTarget("logsentinel")
            {
                IncludeSourceInfo = true,
                Address = "tcp://127.0.0.1:9999",
                Layout = logfile.Layout,
            };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logsentinel);

            logFactory.Configuration = config;
            return logFactory;
        }

    }
}
