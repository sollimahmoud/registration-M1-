using Microsoft.EntityFrameworkCore;

namespace registration_M1_.Models
{
    public class AppDbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbcontext(DbContextOptions options) : base(options)
        { //
        }
    }

}
