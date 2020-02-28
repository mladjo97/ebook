namespace EBook.Services.Queries.Fuzzy
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookContentFuzzyQuery : SearchRequestSpecification<Book>
    {
        private readonly string _content;

        public EBookContentFuzzyQuery(string content)
            => _content = content ?? throw new ArgumentNullException($"{nameof(content)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.File.Content)
                        .Query(_content)
                        .Fuzziness(Fuzziness.Auto)
                    )
                );
    }
}
