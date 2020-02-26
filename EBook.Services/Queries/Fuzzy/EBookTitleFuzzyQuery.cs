namespace EBook.Services.Queries.Fuzzy
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookTitleFuzzyQuery : SearchRequestSpecification<Book>
    {
        private readonly string _title;

        public EBookTitleFuzzyQuery(string title)
            => _title = title ?? throw new ArgumentNullException($"{nameof(title)} cannot be null.");

        // @TODO:
        // - Remove "ebooks"
        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Title)
                        .Query(_title)
                        // @Reference: https://qbox.io/blog/elasticsearch-optimization-fuzziness-performance
                        .Fuzziness(Fuzziness.EditDistance(3))
                    )
                );
    }
}
