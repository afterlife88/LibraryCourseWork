using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("name=LibraryDbContext")
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<LibraryDbContext>());
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Author> Authors { get; set; }

    }
}