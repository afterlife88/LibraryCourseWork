using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        private List<Book> _books = new List<Book>()
        {
            new Book()
            {
                Author = new Author() { FirstName = "Чак", LastName = "Паланник" },
                BookName = "Бойцовский клуб",
                Category = new Category() { CategoryName = "Контркультура", CategoryDescription = "бла бла бла" },
                ISBN = "978-5-17-016682-4",
                NumberOfPages = 256
            },
             new Book()
            {
                Author = new Author() { FirstName = "Дэниел", LastName = "Киз" },
                BookName = "Цветы для Элджернона",
                Category = new Category() { CategoryName = "научно-фантастический рассказ", CategoryDescription = "ммоомом" },
                ISBN = "0-15-131510-8",
                NumberOfPages = 311
            },
            new Book()
            {
                Author = new Author() { FirstName = "Дэниел", LastName = "Киз" },
                BookName = "Билли милиган",
                Category =
                    new Category() { CategoryName = "научно-фантастический рассказ", CategoryDescription = "ммоомом" },
                ISBN = "0-15-131510-8",
                NumberOfPages = 223
            }
        };

        public IEnumerable GettAll()
        {
            Category scineceFantastic = new Category()
            {
                CategoryName = "научно-фантастический рассказ",
                CategoryDescription = "Научная фантастика описывает вымышленные технологии и научные открытия, "
            };
            Book billiMiligan = new Book() { BookName = "Билли милиган", ISBN = "0-15-131510-8", NumberOfPages = 223, Category = scineceFantastic };
            Author keez = new Author() { FirstName = "Дэниел", LastName = "Киз" };

            Book eldjeron = new Book()
            {
                BookName = "Цветы для Элджернона",
                ISBN = "0-15-131510-8",
                NumberOfPages = 311,
                Category = scineceFantastic
            };
            // ADD SOME DATA
            //keez.Books.Add(billiMiligan);
            //keez.Books.Add(eldjeron);
            //_dbContext.Authors.Add(keez);
            //_dbContext.SaveChanges();
            //_dbContext.Books.AddRange(_books);
            //_dbContext.SaveChanges();

            //   _dbContext.SaveChanges(); 
            //_dbContext.Authors.SingleOrDefault(r=>r.LastName == "Киз");
            return _dbContext.Books.ToArray();

        }

        public Book Get(int id)
        {
            using (var db = new LibraryDbContext())
            {
                return db.Books.FirstOrDefault(r => r.BookId == id);
            }

        }

        public Book Add(Book item)
        {
            item.BookId = _books.Count + 1;
            _books.Add(item);

            return item;
        }

        public void Remove(int it)
        {
            throw new NotImplementedException();
        }
    }
}