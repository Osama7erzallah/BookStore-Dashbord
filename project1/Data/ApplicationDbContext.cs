using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project1.Models;
namespace project1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Auther> Authers{ get; set; }
        public DbSet<Book> Books{ get; set; }
        public DbSet<BookCategory> BookCategories  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCategory>().HasKey(BC => new
            {
                BC.BookId,
                BC.CategoryId


            });

            base.OnModelCreating(builder);
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
