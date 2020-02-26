namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookTitleQuery : SearchRequestSpecification<Book>
    {
        private readonly string _title;

        public EBookTitleQuery(string title)
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
                    )
                );
    }
}
