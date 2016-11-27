using Autofac;

namespace SSW.RulesSearchCore.Data.SharePoint
{
    public class SharePointModule : Module
    {
        private readonly SharePointClientConfig _sharePointClientConfig;

        public SharePointModule(SharePointClientConfig sharePointClientConfig)
        {
            _sharePointClientConfig = sharePointClientConfig;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_sharePointClientConfig)
                .AsSelf();

            builder.RegisterType<RulesDataSource>()
                .As<IRulesDataSource>();
        }
    }
}