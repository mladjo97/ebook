namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookKeywordsQuery : SearchRequestSpecification<Book>
    {
        private readonly string _keywords;

        public EBookKeywordsQuery(string keywords)
            => _keywords = keywords ?? throw new ArgumentNullException($"{nameof(keywords)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Keywords)
                        .Query(_keywords)
                    )
                );
    }
}
