namespace EBook.API.Extensions
{
    using Nest;
    using EBook.API.Elasticsearch.Mappings;
    using EBook.Domain;
    using Microsoft.Extensions.Configuration;

    public static class ElasticsearchMappingExtensions
    {
        public static IElasticClient ConfigureMappings(this IElasticClient client, IConfiguration config)
        { 
            var indexSettings = new IndexSettings()
            {
                NumberOfReplicas = 0,
                NumberOfShards = 1
            };

            // @TODO:
            // - Research mappings between multiple indexes
            client.ConfigureEBookMapping(config);

            // testing elasticsearch dynamic mapping
            client.Indices.Create("users", c => c.Map<User>(m => m.AutoMap()));

            return client;
        }
    }
}
