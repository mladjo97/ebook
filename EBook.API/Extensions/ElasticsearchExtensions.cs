namespace EBook.API.Extensions
{
    using EBook.API.Elasticsearch.Index;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Nest;
    using System;
    using System.Text;

    public static class ElasticsearchExtensions
    {
        public static void ConfigureElasticsearch(this IServiceCollection services, IConfiguration config)
        {
            var url = config
                .GetSection(ConfigurationSettings.ElasticsearchSectionKey)
                .GetValue<string>(ConfigurationSettings.UrlKey);

            var settings = new ConnectionSettings(new Uri(url))
                .ConfigureDefaultTypeIndexes(config)
                // testing 
                .OnRequestCompleted((handler) => 
                { 
                    if(handler.RequestBodyInBytes != null)
                    {
                        // logger here
                        Console.WriteLine($"{handler.HttpMethod} {handler.Uri}");
                        Console.WriteLine($"{Encoding.UTF8.GetString(handler.RequestBodyInBytes)}");
                    }

                    if (handler.ResponseBodyInBytes != null)
                    {
                        // logger here
                        Console.WriteLine($"{handler.HttpMethod} {handler.Uri}");
                        Console.WriteLine($"{Encoding.UTF8.GetString(handler.ResponseBodyInBytes)}");
                    }
                });

            var client = new ElasticClient(settings)
                .ConfigureMappings(config);

            services.AddSingleton<IElasticClient>(client);
        }

    }
}
