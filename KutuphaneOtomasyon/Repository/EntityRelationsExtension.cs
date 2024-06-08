using KutuphaneOtomasyon.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyon.Repository
{
    public static class EntityRelationsExtension
    {
        public static void ConfigurePersonRelations(ModelBuilder builder)
        {
            // City relation
            builder.Entity<Person>()
                .HasOne(P => P.PersonCity)
                .WithMany(c => c.Persons)
                .HasForeignKey(p => p.CityID);
            
            // District Relation
            builder.Entity<Person>()
                .HasOne(p => p.PersonDistrict)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.DistrictID);

            //Neighborhood Relation

            builder.Entity<Person>()
                .HasOne(p => p.PersonNeighborhood)
                .WithMany(n => n.Persons)
                .HasForeignKey(p => p.NeighborhoodID);

            // AppUser Relation
            builder.Entity<Person>()
                .HasOne(p => p.AppUser)
                .WithOne(a => a.Person)
                .HasForeignKey<Person>(p => p.UserID);
        }
        public static void ConfigureAddressRelations(ModelBuilder builder)
        {
            builder.Entity<City>()
                .HasMany(c => c.Districts)
                .WithOne(d => d.City)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<District>()
                .HasMany(d => d.Neighborhoods)
                .WithOne(n => n.District)
                .HasForeignKey(n => n.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Neighborhood>()
                .HasOne(n => n.District)
                .WithMany(d => d.Neighborhoods)
                .HasForeignKey(n => n.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Neighborhood>()
                .HasOne(n => n.City)
                .WithMany(c => c.Neighborhoods)
                .HasForeignKey(n => n.CityId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public static void ConfigureBookRelations(ModelBuilder builder)
        {
            // book writer relation
            builder.Entity<Book>()
                .HasOne(b => b.Writer)
                .WithMany(w => w.Books)
                .HasForeignKey(b => b.WriterId);

            // book publisher relation

            builder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Book)
                .HasForeignKey(b => b.PublisherId);
        }
        public static void ConfigurePublisherAddressRelations(ModelBuilder builder)
        {
            // publisher city relation
            builder.Entity<Publisher>()
                .HasOne(p => p.PublisherCity)
                .WithMany(c => c.Publishers)
                .HasForeignKey(p => p.CityId);

            // publisher district relation
            builder.Entity<Publisher>()
                .HasOne(p => p.PublisherDistrict)
                .WithMany(c => c.Publishers)
                .HasForeignKey(p => p.DistrictId);

            // publisher neighborhood relation
            builder.Entity<Publisher>()
                .HasOne(p => p.PublisherNeighborhood)
                .WithMany(c => c.Publishers)
                .HasForeignKey(p => p.NeighborhoodId);
        }
        public static void ConfigureBorrowRelations(ModelBuilder builder)
        {
            builder.Entity<Borrow>()
                .HasOne(b => b.Person)
                .WithMany(p => p.Borrows)
                .HasForeignKey(b => b.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Borrow>()
                .HasOne(b=> b.Book)
                .WithMany(book=> book.Borrow)
                .HasForeignKey(b=> b.BookId);
        }
    }
}
