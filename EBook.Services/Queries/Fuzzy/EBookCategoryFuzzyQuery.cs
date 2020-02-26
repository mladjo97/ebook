namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookCategoryFuzzyQuery : SearchRequestSpecification<Book>
    {
        private readonly string _category;

        public EBookCategoryFuzzyQuery(string category)
            => _category = category ?? throw new ArgumentNullException($"{nameof(category)} cannot be null.");

        // @TODO:
        // - Read "ebooks" from config?
        // - Find a way to decorate existing IMatchQuery with .Fuzziness()
        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Category.Name)
                        .Query(_category)
                        .Fuzziness(Fuzziness.Auto)
                    )
                );
    }
}
