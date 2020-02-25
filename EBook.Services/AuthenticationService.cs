namespace EBook.Services
{
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using System;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;

        public AuthenticationService(IUsersRepository usersRepository)
            => _usersRepository = usersRepository;

        public async Task<bool> Authenticate(string username, string password)
        {
            // @TODO:
            // - Add password hashing
            // - Add hash comparison and validation
            try
            {
                var user = await _usersRepository.GetByUsername(username);

                if (user == null)
                    return false;

                return user.Password == password;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
