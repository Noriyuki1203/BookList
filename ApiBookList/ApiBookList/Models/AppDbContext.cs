using Microsoft.EntityFrameworkCore;

namespace ApiBookList.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}
