using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Serilog;

namespace SSW.RulesSearchCore.ConsoleRunner
{
    public static class ConfigSettings
    {
        public static string SeqUrl => Config["AppConfig:SeqUrl"];

        public static string SharePointUrl => Config["AppConfig:SharePointUrl"];

        public static string ElasticSearchUrl => Config["AppConfig:ElasticSearchUrl"];

        private static IConfigurationRoot _config = null;
        private static IConfigurationRoot Config =>  _config ?? (_config = BuildConfiguration());
        private static IConfigurationRoot BuildConfiguration()
        {
            var env = PlatformServices.Default.Application;
            Log.Information("loading config from {ApplicationBasePath}", env.ApplicationBasePath);

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ApplicationBasePath);
            builder.AddJsonFile("appsettings.json");
            return builder.Build();
        }

    }
}