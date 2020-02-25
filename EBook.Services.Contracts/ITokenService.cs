namespace EBook.Services.Contracts
{
    using System.Threading.Tasks;

    public interface ITokenService
    {
        string GenerateToken();
    }
}
