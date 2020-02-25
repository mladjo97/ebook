namespace EBook.Services.Contracts
{
    using System.Threading.Tasks;
    
    public interface IAuthService
    {
        public Task<bool> Authenticate(string username, string password);
    }
}
