using Lav12_Async_KazanovAlexandr.Models;
using Microsoft.EntityFrameworkCore;


namespace Lab12_Async_KazanovAlexandr.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base (options) { }
        public DbSet<User> Users { get; set; }
    }
}
