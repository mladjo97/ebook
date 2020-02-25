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
    }
}
