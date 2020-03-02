namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using EBook.Services.Contracts.Filter;
    using EBook.Services.Contracts.Query;
    using EBook.Services.Models;
    using EBook.Services.Queries;
    using EBook.Services.Queries.Fuzzy;
    using EBook.Services.Queries.Match;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EBooksFilterService : IEBooksFilterService
    {
        private IEBooksRepository _eBooksRepository;

        public EBooksFilterService(IEBooksRepository eBooksRepository)
            => _eBooksRepository = eBooksRepository;

        public async Task<IEBookElasticQueryable> Filter(IEBookFilterOptions options)
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

            return await Search(orQuery, options.Page, options.Size);
        }

        public async Task<IEBookElasticQueryable> FuzzyFilter(IEBookFilterOptions options)
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

            return await Search(orQuery, options.Page, options.Size);
        }

        private async Task<IEBookElasticQueryable> Search(SearchRequestSpecification<Book> query, int page, int size)
        {
            try
            {
                var highlightQuery = new HighlightSearchRequestSpecification<Book>(query);
                var paginationQuery = new PaginatedSearchRequestSpecification<Book>(highlightQuery, page, size);

                var response = await _eBooksRepository.Search(highlightQuery.IsSatisfiedBy());

                return new EBookElasticQueryable
                {
                    Items = response.Hits.Select(h => MapBook(h)),
                    Total = (int)response.Total,
                    Page = page + 1,
                    Size = response.Documents.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        // @TODO:
        // - place this map elsewhere
        private HighlightableEBook MapBook(IHit<Book> hit)
            => new HighlightableEBook
            {
                Author = hit.Source.Author,
                Category = hit.Source.Category,
                File = hit.Source.File,
                Id = hit.Source.Id,
                Keywords = hit.Source.Keywords,
                Language = hit.Source.Language,
                PublicationYear = hit.Source.PublicationYear,
                Title = hit.Source.Title,
                Highlights = hit.Highlight
            };

    }
}
