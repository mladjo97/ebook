namespace EBook.Services.Contracts
{
    using EBook.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEBooksService
    {
        // @TODO:
        // - Add other repository methods

        Task<IEnumerable<Book>> SearchByTitle(string title);
        Task<IEnumerable<Book>> SearchByAuthor(string author);
        Task<IEnumerable<Book>> SearchByKeywords(string keywords);
        Task<IEnumerable<Book>> SearchByLanguage(string language);
        Task<IEnumerable<Book>> SearchByCategory(string category);
    }
}
