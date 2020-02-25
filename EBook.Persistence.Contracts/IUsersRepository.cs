namespace EBook.Persistence.Contracts
{
    using EBook.Domain;
    using System.Threading.Tasks;

    public interface IUsersRepository : IRepositoryBase<int, User>
    {
        Task<User> GetByUsername(string username);
    }
}
