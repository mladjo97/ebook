namespace EBook.Services.Queries.Fuzzy
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookAuthorFuzzyQuery : SearchRequestSpecification<Book>
    {
        private readonly string _author;

        public EBookAuthorFuzzyQuery(string author)
            => _author = author ?? throw new ArgumentNullException($"{nameof(author)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Author)
                        .Query(_author)
                        // @Reference: https://qbox.io/blog/elasticsearch-optimization-fuzziness-performance
                        .Fuzziness(Fuzziness.Auto)
                    )
                );
    }
}
