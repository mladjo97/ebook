namespace EBook.Services.Queries
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookAuthorSearchQuery : SearchRequestSpecification<Book>
    {
        private readonly string _author;

        public EBookAuthorSearchQuery(string author)
            => _author = author ?? throw new ArgumentNullException($"{nameof(author)} cannot be null.");

        // @TODO:
        // - Remove "ebooks"
        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Author)
                        .Query(_author)
                    )
                );
    }
}
