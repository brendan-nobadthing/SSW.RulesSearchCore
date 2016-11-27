using Autofac;
using SSW.RulesSearchCore.Elastic;

namespace SSW.RulesSearchCore.Web
{
    public class RulesSearchWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterModule(new ElasticSearchModule(new ElasticSearchSettings()
            {
                Url = ConfigSettings.ElasticSearchUrl
            }));

            builder.RegisterType<ElasticTextSearch>()
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}