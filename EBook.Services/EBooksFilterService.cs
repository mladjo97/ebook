namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using EBook.Services.Contracts.Filter;
    using EBook.Services.Queries;
    using EBook.Services.Queries.Fuzzy;
    using EBook.Services.Queries.Match;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBooksFilterService : IEBooksFilterService
    {
        private IEBooksRepository _eBooksRepository;

        public EBooksFilterService(IEBooksRepository eBooksRepository)
            => _eBooksRepository = eBooksRepository;

        public async Task<IEnumerable<Book>> Filter(IEBookFilterOptions options)
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

            var orQuery = new OrSearchRequestSpecification<Book>(filterQueries);

            return await Search(orQuery);
        }

        public async Task<IEnumerable<Book>> FuzzyFilter(IEBookFilterOptions options)
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

            var orQuery = new OrSearchRequestSpecification<Book>(filterQueries);

            return await Search(orQuery);
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
