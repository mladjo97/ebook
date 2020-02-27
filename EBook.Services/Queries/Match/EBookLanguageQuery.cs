namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookLanguageQuery : SearchRequestSpecification<Book>
    {
        private readonly string _language;

        public EBookLanguageQuery(string language)
            => _language = language ?? throw new ArgumentNullException($"{nameof(language)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Language.Name)
                        .Query(_language)
                    )
                );
    }
}
