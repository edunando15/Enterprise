using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Context
{
    public class MyDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<User> Users { get; set; }

        public MyDbContext() : base() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;Initial catalog=Enterprise;User Id=enterprise;Password=enterprise;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
