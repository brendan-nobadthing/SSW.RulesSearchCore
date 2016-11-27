using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Serilog;

namespace SSW.RulesSearchCore.Web
{
    public static class ConfigSettings
    {
        public static string SeqUrl => ConfigRoot["AppConfig:SeqUrl"];

        public static string SharePointUrl => ConfigRoot["AppConfig:SharePointUrl"];

        public static string ElasticSearchUrl => ConfigRoot["AppConfig:ElasticSearchUrl"];

        public static IConfigurationRoot ConfigRoot { get; set; }

    }
}