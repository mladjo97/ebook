using Nest;

namespace EBook.API.Extensions
{
    using EBook.Domain;

    public static class ElasticsearchMappingExtensions
    {
        public static IElasticClient ConfigureMappings(this IElasticClient client)
        {
            var indexSettings = new IndexSettings()
            {
                NumberOfReplicas = 0,
                NumberOfShards = 1
            };

            // @TODO:
            // - Research mappings between multiple indexes
            var res = client.Indices.Create("ebooks", c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(aa => aa
                            .Standard("standard_english", sa => sa
                                .StopWords("_english_") // should we exclude 'The', 'and' etc. from ebook title?
                            )
                        )
                    )
                )
                .Map<Book>(m => m
                    .AutoMap()
                    .Properties(p => p
                        .Text(t => t
                            .Name(n => n.Title)
                            .Analyzer("standard_english")
                        )
                    )
                )
            );

            client.Indices.Create("users", c => c.Map<User>(m => m.AutoMap()));

            return client;
        }
    }
}
