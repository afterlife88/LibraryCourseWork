using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class BooksRepository : IBooksRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BooksRepository()
        {
            _dbContext = new LibraryDbContext();
        }
        public IEnumerable GettAll()
        {
            byte[] picBytes = File.ReadAllBytes("F:\\eldjeron.jpg");
            byte[] fileTxtBytes = File.ReadAllBytes("F:\\цветы для элджерона.txt");
            Author keez = new Author() { FirstName = "Дэниел", LastName = "Киз" };
            Category scineceFantastic = new Category()
            {
                CategoryName = "научно-фантастический рассказ",
                CategoryDescription = "Научная фантастика описывает вымышленные технологии и научные открытия, "
            };
            Book billiMiligan = new Book()
            {
                BookName = "Билли милиган",
                ISBN = "0-15-131510-8",
                NumberOfPages = 223,
                Category = scineceFantastic,
                ImageOfBook = picBytes,
                FileTxt = fileTxtBytes,
                Author = keez,
            };

            Book eldjeron = new Book()
            {
                BookName = "Цветы для Элджернона",
                ISBN = "0-15-131510-8",
                NumberOfPages = 311,
                Category = scineceFantastic,
                Author = keez,
            };
            // ADD SOME DATA
            //_dbContext.Books.Add(billiMiligan);
            //_dbContext.Books.Add(eldjeron);
            //_dbContext.SaveChanges();

            return _dbContext.Books.ToArray();

        }


        public Book Get(int id)
        {
            //var a = _dbContext.Books.OrderByDescending(r => r.BookId).Include(r => r.Category);
            //return a.FirstOrDefault(r => r.BookId == 1);
            return _dbContext.Books.FirstOrDefault(r => r.BookId == id);
        }
        public Book Add(Book item)
        {
            Author existingAuthor = _dbContext.Authors.SingleOrDefault(r =>
                r.FirstName.ToUpper() == item.Author.FirstName.ToUpper() &&
                r.LastName.ToUpper() == item.Author.LastName.ToUpper());
            if (existingAuthor != null)
            {
                item.Author = existingAuthor;
                _dbContext.Books.Add(item);
                _dbContext.SaveChanges();
            }
            Author newAuthor = new Author()
            {
                FirstName = item.Author.FirstName,
                LastName = item.Author.LastName
            };
            item.Author = newAuthor;
            _dbContext.Books.Add(item);
            _dbContext.SaveChanges();
            return item;
        }
        public void Remove(int id)
        {

            var item = this.Get(id);
            if (item != null)
                _dbContext.Books.Remove(item);
            _dbContext.SaveChanges();
        }
    }
}