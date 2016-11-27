using Autofac;
using SSW.RulesSearchCore.ConsoleRunner.Commands;
using SSW.RulesSearchCore.Data.SharePoint;
using SSW.RulesSearchCore.Elastic;

namespace SSW.RulesSearchCore.ConsoleRunner
{
    public static class AutofacContainerFactory
    {

        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new SharePointModule(new SharePointClientConfig()
            {
                Url = ConfigSettings.SharePointUrl
            }));

            builder.RegisterModule(new ElasticSearchModule(new ElasticSearchSettings()
            {
                Url = ConfigSettings.ElasticSearchUrl
            }));

            builder.RegisterType<NestIndexer>()
                .Named<ICommand>(typeof(NestIndexer).Name)
                .As<ICommand>();

            return builder.Build();
        }
    }
}