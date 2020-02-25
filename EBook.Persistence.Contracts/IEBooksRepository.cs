namespace EBook.Persistence.Contracts
{
    using EBook.Domain;

    public interface IEBooksRepository : IRepositoryBase<int, Book>, ISearchable<Book>
    {
    }
}
