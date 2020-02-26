// @TODO:
// - File too long
// - Separate to EBooksMatchService and EBooksFuzzyService ?
// - or EBooksSearchService and EBooksFilterService ?

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

    public class EBooksService : IEBooksService
    {
        private readonly IEBooksRepository _eBooksRepository;

        public EBooksService(IEBooksRepository eBooksRepository)
            => _eBooksRepository = eBooksRepository;

        public async Task<IEnumerable<Book>> SearchByAuthor(string author)
        {
            var searchByAuthorQuery = new EBookAuthorQuery(author);
            return await Search(searchByAuthorQuery);
        }

        public async Task<IEnumerable<Book>> SearchByCategory(string category)
        {
            var searchByCategoryQuery = new EBookCategoryQuery(category);
            return await Search(searchByCategoryQuery);
        }

        public async Task<IEnumerable<Book>> SearchByKeywords(string keywords)
        {
            var searchByKeywordsQuery = new EBookKeywordsQuery(keywords);
            return await Search(searchByKeywordsQuery);
        }

        public async Task<IEnumerable<Book>> SearchByLanguage(string language)
        {
            var searchByLanguageQuery = new EBookLanguageQuery(language);
            return await Search(searchByLanguageQuery);
        }

        public async Task<IEnumerable<Book>> SearchByTitle(string title)
        {
            var searchByTitleQuery = new EBookTitleQuery(title);
            return await Search(searchByTitleQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByAuthor(string author)
        {
            var searchByAuthorFuzzyQuery = new EBookAuthorFuzzyQuery(author);
            return await Search(searchByAuthorFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByCategory(string category)
        {
            var searchByCategoryFuzzyQuery = new EBookCategoryFuzzyQuery(category);
            return await Search(searchByCategoryFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByKeywords(string keywords)
        {
            var searchByKeywordsFuzzyQuery = new EBookKeywordsFuzzyQuery(keywords);
            return await Search(searchByKeywordsFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByLanguage(string language)
        {
            var searchByLanguageFuzzyQuery = new EBookLanguageFuzzyQuery(language);
            return await Search(searchByLanguageFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByTitle(string title)
        {
            var searchByTitleFuzzyQuery = new EBookTitleFuzzyQuery(title);
            return await Search(searchByTitleFuzzyQuery);
        }        

        /// <summary>
        /// E-Book filter function (multi-field match search)
        /// </summary>
        /// <param name="options">Filter options for E-Books</param>
        /// <returns>Collection of E-Books that fulfil the filter reqs</returns>
        public async Task<IEnumerable<Book>> Filter(IEBooksFilterOptions options)
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

            // which one to use here ?
            // AND or OR or a combination ?
            var orQuery = new OrSearchRequestSpecification<Book>(filterQueries);

            return await Search(orQuery);
        }

        /// <summary>
        /// E-Book filter function (multi-field fuzzy search)
        /// </summary>
        /// <param name="options">Filter options for E-Books</param>
        /// <returns>Collection of E-Books that fulfil the filter reqs</returns>
        public async Task<IEnumerable<Book>> FuzzyFilter(IEBooksFilterOptions options)
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

            // which one to use here ?
            // AND or OR or a combination ?
            var orQuery = new OrSearchRequestSpecification<Book>(filterQueries);

            return await Search(orQuery);
        }

        private async Task<IEnumerable<Book>> Search(SearchRequestSpecification<Book> query)
        {
            try
            {
                var eBooks = await _eBooksRepository.Search(query.IsSatisfiedBy());
                return eBooks;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
