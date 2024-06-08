using KutuphaneOtomasyon.Models.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KutuphaneOtomasyon.Repository
{
    public class RepositoryContext : IdentityDbContext<AppUser>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Writer>  Writers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts{ get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            EntityRelationsExtension.ConfigurePersonRelations(builder);
            EntityRelationsExtension.ConfigureAddressRelations(builder);
            EntityRelationsExtension.ConfigureBookRelations(builder);
            EntityRelationsExtension.ConfigurePublisherAddressRelations(builder);
            EntityRelationsExtension.ConfigureBorrowRelations(builder);
        }
    }
}
