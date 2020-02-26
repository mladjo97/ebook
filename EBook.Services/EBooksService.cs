namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using EBook.Services.Queries;
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
            var searchByAuthorQuery = new EBookAuthorSearchQuery(author);

            return await Search(searchByAuthorQuery);
        }

        public async Task<IEnumerable<Book>> SearchByCategory(string category)
        {
            var searchByCategoryQuery = new EBookCategorySearchQuery(category);

            return await Search(searchByCategoryQuery);
        }

        public async Task<IEnumerable<Book>> SearchByKeywords(string keywords)
        {
            var searchByKeywordsQuery = new EBookKeywordsSearchQuery(keywords);

            return await Search(searchByKeywordsQuery);
        }

        public async Task<IEnumerable<Book>> SearchByLanguage(string language)
        {
            var searchByLanguageQuery = new EBookLanguageSearchQuery(language);

            return await Search(searchByLanguageQuery);
        }

        public async Task<IEnumerable<Book>> SearchByTitle(string title)
        {
            // this is a quick test, not the actual implementation
            var searchByTitleQuery = new EBookTitleSearchQuery(title);
            var searchByLanguageQuery = new EBookLanguageSearchQuery("Serbian");

            var andQuery = new AndSearchRequestSpecification<Book>(
                new List<SearchRequestSpecification<Book>>
                {
                    searchByTitleQuery,
                    searchByLanguageQuery,
                }
            );

            return await Search(andQuery);
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
