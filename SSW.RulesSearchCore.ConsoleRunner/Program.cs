using System.Collections.Generic;
using System.Linq;
using Autofac;
using Serilog;
using SSW.RulesSearchCore.ConsoleRunner.Commands;

namespace SSW.RulesSearchCore.ConsoleRunner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InitSerilog();

            using (var container = AutofacContainerFactory.CreateContainer())
            {
                var commandName = args.Length > 0 ? args[0] : "";

                if (container.IsRegisteredWithName<ICommand>(commandName))
                {
                    Log.Information("Running Command {commandName}", args[0]);
                    container.ResolveNamed<ICommand>(commandName)
                        .Run();
                    Log.Information("Commmand Complete");
                }
                else
                {
                    var commandList = string.Join(",",
                        container.Resolve<IEnumerable<ICommand>>().Select(c => c.GetType().Name));
                    Log.Error($"Please provide one of the following commands: {commandList}");
                }

            }

        }


        private static void InitSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                //.WriteTo.RollingFile(@"c:\log\SSW.RulesSearchService{Date}.log")
                //.WriteTo.Seq("http://localhost:5341")
                .Enrich.WithProperty("ApplicationName", "SSW.RulesSearchCore.ConsoleRunner")
                .CreateLogger();

            Log.Information("Starting application {ApplicationName}");
        }

    }
}