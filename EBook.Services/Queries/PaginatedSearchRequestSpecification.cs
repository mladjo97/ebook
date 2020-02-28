namespace EBook.Services.Queries
{
    using Nest;
    using System;

    public class PaginatedSearchRequestSpecification<T> 
        : SearchRequestSpecification<T> where T : class
    {
        private readonly SearchRequestSpecification<T> _query;
        private readonly int _page;
        private readonly int _size;

        public PaginatedSearchRequestSpecification(SearchRequestSpecification<T> query, int page, int size)
        {
            _query = query ?? throw new ArgumentNullException($"{nameof(query)} cannot be null.");
            _page = page > 0 ? page : 1;
            _size = size > 0 ? size : 10;
        }

        public override ISearchRequest<T> IsSatisfiedBy()
            => new SearchDescriptor<T>()
                .Query(q => _query
                    .IsSatisfiedBy()
                    .Query
                )
                .From(_page)
                .Size(_size);
    }
}
