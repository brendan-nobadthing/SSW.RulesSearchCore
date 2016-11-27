using System;
using Autofac;
using Nest;
using SSW.RulesSearchCore.Domain;

namespace SSW.RulesSearchCore.Elastic
{
    public class ElasticSearchModule : Module
    {
        private readonly IConnectionSettingsValues _connectionSettings;

        public ElasticSearchModule(ElasticSearchSettings elasticSearchSettings)
        {
            _connectionSettings = new ConnectionSettings(new Uri(elasticSearchSettings.Url))
                .MapDefaultTypeIndices(m => m
                    .Add(typeof(Rule), "rules")
                );
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new ElasticClient(_connectionSettings))
                .AsSelf();
        }
    }
}