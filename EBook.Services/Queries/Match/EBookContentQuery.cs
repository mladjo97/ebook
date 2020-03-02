namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookContentQuery : SearchRequestSpecification<Book>
    {
        private readonly string _content;

        public EBookContentQuery(string content)
            => _content = content ?? throw new ArgumentNullException($"{nameof(content)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.File.Content)
                        .Query(_content)
                    )
                );
    }
}
