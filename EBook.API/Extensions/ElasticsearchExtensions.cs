namespace EBook.API.Extensions
{
    using EBook.API.Elasticsearch.Index;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Nest;
    using System;

    public static class ElasticsearchExtensions
    {
        private static string ElasticsearchSectionKey = "elasticsearch";
        private static string UrlKey = "url";

        public static void ConfigureElasticsearch(this IServiceCollection services, IConfiguration config)
        {
            var url = config.GetSection(ElasticsearchSectionKey).GetValue<string>(UrlKey);

            var settings = new ConnectionSettings(new Uri(url))
                .ConfigureDefaultTypeIndexes(config);

            var client = new ElasticClient(settings)
                .ConfigureMappings();

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
