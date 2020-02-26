namespace EBook.Services.Contracts
{
    using EBook.Domain;
    using EBook.Services.Contracts.Query;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEBooksSearchService
    {
        Task<IEnumerable<Book>> SearchByTitle(string title);
        Task<IEnumerable<Book>> SearchByAuthor(string author);
        Task<IEnumerable<Book>> SearchByKeywords(string keywords);
        Task<IEnumerable<Book>> SearchByLanguage(string language);
        Task<IEnumerable<Book>> SearchByCategory(string category);

        Task<IEnumerable<Book>> FuzzySearchByTitle(string title);
        Task<IEnumerable<Book>> FuzzySearchByAuthor(string author);
        Task<IEnumerable<Book>> FuzzySearchByKeywords(string keywords);
        Task<IEnumerable<Book>> FuzzySearchByLanguage(string language);


        Task<IEnumerable<Book>> Search(IEBookSearchOptions options);
        Task<IEnumerable<Book>> FuzzySearch(IEBookSearchOptions options);
    }
}
