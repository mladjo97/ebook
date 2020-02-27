namespace EBook.Services.Queries.Fuzzy
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookCategoryFuzzyQuery : SearchRequestSpecification<Book>
    {
        private readonly string _category;

        public EBookCategoryFuzzyQuery(string category)
            => _category = category ?? throw new ArgumentNullException($"{nameof(category)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Category.Name)
                        .Query(_category)
                        .Fuzziness(Fuzziness.Auto)
                    )
                );
    }
}
