namespace EBook.API.Elasticsearch.Mappings
{
    using EBook.Domain;
    using Microsoft.Extensions.Configuration;
    using Nest;

    public static class EBookMapping
    {
        public static IElasticClient ConfigureEBookMapping(this IElasticClient client, IConfiguration config)
        {
            var eBooksIndex = config
                .GetSection(ConfigurationSettings.ElasticsearchSectionKey)
                .GetValue<string>(ConfigurationSettings.EBooksIndexKey);

            client.Indices.Create(eBooksIndex, c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(aa => aa
                            .Standard("standard_english", sa => sa
                                .StopWords("_english_")
                            )
                        )
                    )
                )
                .Map<Book>(m => m
                    .AutoMap()
                    .Properties(p => p
                        .Text(t => t
                            // should we exclude 'The', 'and' etc. from ebook title?
                            .Name(n => n.Title)
                            .Analyzer("standard_english")
                        )
                        .Text(t => t
                            .Name(n => n.Author)
                            .Analyzer("standard_english")
                        )
                        .Text(t => t
                             .Name(n => n.Keywords)
                             .Analyzer("standard_english")
                        )
                        .Number(n => n
                            .Name(na => na.Id)
                            .Type(NumberType.Integer)
                        )
                        .Text(t => t
                            .Name(n => n.File.Content)
                            .Analyzer("standard")
                        )
                    )
                )
            );

            return client;
        }
    }
}
