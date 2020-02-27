namespace EBook.API.Extensions
{
    using EBook.API.Elasticsearch.Index;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Nest;
    using System;

    public static class ElasticsearchExtensions
    {
        public static void ConfigureElasticsearch(this IServiceCollection services, IConfiguration config)
        {
            var url = config
                .GetSection(ConfigurationSettings.ElasticsearchSectionKey)
                .GetValue<string>(ConfigurationSettings.UrlKey);

            var settings = new ConnectionSettings(new Uri(url))
                .ConfigureDefaultTypeIndexes(config);

            var client = new ElasticClient(settings)
                .ConfigureMappings(config);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
