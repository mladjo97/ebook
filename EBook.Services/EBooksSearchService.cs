namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using EBook.Services.Contracts.Query;
    using EBook.Services.Queries;
    using EBook.Services.Queries.Fuzzy;
    using EBook.Services.Queries.Match;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBooksSearchService : IEBooksSearchService
    {
        private readonly IEBooksRepository _eBooksRepository;

        public EBooksSearchService(IEBooksRepository eBooksRepository)
            => _eBooksRepository = eBooksRepository;

        public async Task<IEnumerable<Book>> Search(IEBookSearchOptions options)
        {
            var filterQueries = new List<SearchRequestSpecification<Book>>();

            if (!string.IsNullOrEmpty(options.Author))
                filterQueries.Add(new EBookAuthorQuery(options.Author));

            if (!string.IsNullOrEmpty(options.Title))
                filterQueries.Add(new EBookTitleQuery(options.Title));

            if (!string.IsNullOrEmpty(options.Category))
                filterQueries.Add(new EBookCategoryQuery(options.Category));

            if (!string.IsNullOrEmpty(options.Language))
                filterQueries.Add(new EBookLanguageQuery(options.Language));

            if (!string.IsNullOrEmpty(options.Keywords))
                filterQueries.Add(new EBookKeywordsQuery(options.Keywords));

            var andQuery = new AndSearchRequestSpecification<Book>(filterQueries);
            var higlightQuery = new HighlightSearchRequestSpecification<Book>(andQuery);

            return await Search(higlightQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearch(IEBookSearchOptions options)
        {
            var filterQueries = new List<SearchRequestSpecification<Book>>();

            if (!string.IsNullOrEmpty(options.Author))
                filterQueries.Add(new EBookAuthorFuzzyQuery(options.Author));

            if (!string.IsNullOrEmpty(options.Title))
                filterQueries.Add(new EBookTitleFuzzyQuery(options.Title));

            if (!string.IsNullOrEmpty(options.Category))
                filterQueries.Add(new EBookCategoryFuzzyQuery(options.Category));

            if (!string.IsNullOrEmpty(options.Language))
                filterQueries.Add(new EBookLanguageFuzzyQuery(options.Language));

            if (!string.IsNullOrEmpty(options.Keywords))
                filterQueries.Add(new EBookKeywordsFuzzyQuery(options.Keywords));

            var andQuery = new AndSearchRequestSpecification<Book>(filterQueries);
            var higlightQuery = new HighlightSearchRequestSpecification<Book>(andQuery);
            
            return await Search(higlightQuery);
        }

        private async Task<IEnumerable<Book>> Search(SearchRequestSpecification<Book> query)
        {
            try
            {
                var response = await _eBooksRepository.Search(query.IsSatisfiedBy());

                // @Note:
                // - we can apply some other models like Paginated or Highlighted 
                //   with additional api response information here
                //   or change the function alltogether (its private)
                return response.Documents;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
