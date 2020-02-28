namespace EBook.Services.Queries
{
    using Nest;
    using System;

    public class HighlightSearchRequestSpecification<T> : SearchRequestSpecification<T> where T : class
    {
        private readonly SearchRequestSpecification<T> _query;

        public HighlightSearchRequestSpecification(SearchRequestSpecification<T> query)
            => _query = query ?? throw new ArgumentNullException($"{nameof(query)} cannot be null.");

        public override ISearchRequest<T> IsSatisfiedBy()
            => new SearchDescriptor<T>()
                .Query(q => _query
                    .IsSatisfiedBy()
                    .Query
                )
                // This will highlight all queried fields
                .Highlight(h => h
                    .PreTags("<strong>")
                    .PostTags("</strong>")
                    .FragmentSize(150)
                    .Fields(f => f
                        .Field("*")
                    )
                );
    }
}
