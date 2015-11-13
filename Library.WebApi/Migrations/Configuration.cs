using Library.WebApi.Models;

namespace Library.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.WebApi.Data.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Library.WebApi.Data.LibraryDbContext";
        }

        protected override void Seed(Library.WebApi.Data.LibraryDbContext context)
        {
           // context.Database.Delete();
            // context.Database.Delete();
            //Author keenKeze = new Author()
            //{
            //    FirstName = "Кен",
            //    LastName = "Кизи"
            //};
            //Category category = new Category()
            //{
            //    CategoryName = "научная-фантастика",
            //    CategoryDescription = "бла бла бал бла"
            //};
            //context.Books.Add(new Book()
            //{
            //    Category = category,
            //    Author = keenKeze,
            //    BookName = "Цветы для Элджерона",
            //    BooksLeft = 48,
            //    NumberOfPages = 255,
            //    ISBN = "some-string-123",

            //});
            //context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
