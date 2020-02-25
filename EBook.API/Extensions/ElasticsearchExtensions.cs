namespace EBook.API.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Nest;
    using System;

    public static class ElasticsearchExtensions
    {
        private static string ElasticsearchSectionKey = "elasticsearch";
        private static string UrlKey = "url";
        private static string DefaultIndexKey = "defaultIndex";

        public static void ConfigureElasticsearch(this IServiceCollection services, IConfiguration config)
        {
            var url = config.GetSection(ElasticsearchSectionKey).GetValue<string>(UrlKey);
            var defaultIndex = config.GetSection(ElasticsearchSectionKey).GetValue<string>(DefaultIndexKey);

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
