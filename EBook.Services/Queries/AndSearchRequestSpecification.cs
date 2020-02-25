namespace EBook.Services.Queries
{
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AndSearchRequestSpecification<T> : SearchRequestSpecification<T> where T : class
    {
        private readonly IEnumerable<SearchRequestSpecification<T>> _queries;

        public AndSearchRequestSpecification(IEnumerable<SearchRequestSpecification<T>> queries)
            => _queries = queries ?? throw new ArgumentNullException($"{nameof(queries)} cannot be null.");

        public override ISearchRequest<T> IsSatisfiedBy()
            => new SearchDescriptor<T>()
                .Query(q => q
                    .Bool(b => b
                        .Must(
                            _queries.Select(qu => qu
                                .IsSatisfiedBy()
                                .Query
                            ).ToArray()
                        )
                    )
                );
    }
}
