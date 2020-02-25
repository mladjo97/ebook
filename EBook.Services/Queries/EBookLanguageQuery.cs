namespace EBook.Services.Queries
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookLanguageQuery : SearchRequestSpecification<Book>
    {
        private readonly string _language;

        public EBookLanguageQuery(string language)
            => _language = language ?? throw new ArgumentNullException($"{nameof(language)} cannot be null.");

        // @TODO:
        // - Remove "ebooks"
        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Language.Name)
                        .Query(_language)
                    )
                );
    }
}
