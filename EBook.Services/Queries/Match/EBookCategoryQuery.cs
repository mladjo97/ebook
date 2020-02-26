namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookCategoryQuery : SearchRequestSpecification<Book>
    {
        private readonly string _category;

        public EBookCategoryQuery(string category)
            => _category = category ?? throw new ArgumentNullException($"{nameof(category)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Category.Name)
                        .Query(_category)
                    )
                );
    }
}
