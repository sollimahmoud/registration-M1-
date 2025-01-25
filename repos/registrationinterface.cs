using registration_M1_.Models;

namespace registration_M1_.repos
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Register(User user);
        Task<bool> ForgotPassword(string email);

    }
}
