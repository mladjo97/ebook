using Nest;

namespace EBook.API.Extensions
{
    using EBook.Domain;

    public static class ElasticsearchMappingExtensions
    {
        public static IElasticClient ConfigureMappings(this IElasticClient client)
        {
            var indexSettings = new IndexSettings
            {
                NumberOfReplicas = 0,
                NumberOfShards = 1
            };

            // @TODO:
            // - Research mappings between multiple indexes
            // - Should the models be like sql or nosql
            // - Reference loop
            client.Indices.Create("ebooks", c => c.Map<Book>(m => m.AutoMap()));
            client.Indices.Create("categories", c => c.Map<Category>(m => m.AutoMap()));
            client.Indices.Create("languages", c => c.Map<Language>(m => m.AutoMap()));
            client.Indices.Create("users", c => c.Map<User>(m => m.AutoMap()));

            return client;
        }
    }
}
