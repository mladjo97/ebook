namespace EBook.Services.Contracts
{
    using EBook.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEBookRepositoryService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> Get(int id);
        Task<Book> Create(Book book);
        Task<Book> Update(int id, Book book);
        Task<int> Delete(int id);
    }
}
