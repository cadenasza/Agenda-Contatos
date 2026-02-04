using Microsoft.EntityFrameworkCore;
using Contact_Book.Models;


namespace Contact_Book.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
    }
}
