namespace EBook.Services.Contracts
{
    using EBook.Domain;
    using EBook.Services.Contracts.Filter;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEBooksService
    {
        // @TODO:
        // - Add other repository methods
        // - Do we need all these SearchBy methods now that we have a Filter one?
        Task<IEnumerable<Book>> SearchByTitle(string title);
        Task<IEnumerable<Book>> SearchByAuthor(string author);
        Task<IEnumerable<Book>> SearchByKeywords(string keywords);
        Task<IEnumerable<Book>> SearchByLanguage(string language);
        Task<IEnumerable<Book>> SearchByCategory(string category);

        Task<IEnumerable<Book>> FuzzySearchByTitle(string title);
        Task<IEnumerable<Book>> FuzzySearchByAuthor(string author);
        Task<IEnumerable<Book>> FuzzySearchByKeywords(string keywords);
        Task<IEnumerable<Book>> FuzzySearchByLanguage(string language);

        Task<IEnumerable<Book>> Filter(IEBooksFilterOptions options);
        Task<IEnumerable<Book>> FuzzyFilter(IEBooksFilterOptions options);
    }
}
