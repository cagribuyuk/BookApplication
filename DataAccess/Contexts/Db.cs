using DataAccess.entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Contexts
{
   public class Db:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<BookOwner> BookOwners { get; set; }
        public Db(DbContextOptions options): base(options)
        { 

        }
    }
}
