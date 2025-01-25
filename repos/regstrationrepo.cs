using Microsoft.EntityFrameworkCore;
using registration_M1_.Models;

namespace registration_M1_.repos
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbcontext _context;

        public UserRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<User> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) return false;

            return true;
        }
    }

}
