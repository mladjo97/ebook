namespace EBook.API.Elasticsearch.Mappings
{
    using EBook.Domain;
    using Nest;

    public static class EBookMapping
    {
        public static IElasticClient ConfigureEBookMapping(this IElasticClient client)
        {
            client.Indices.Create("ebooks", c => c
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
                        .Number(n => n
                            .Name(na => na.Id)
                            .Type(NumberType.Integer)
                        )
                    )
                )
            );

            return client;
        }
    }
}
