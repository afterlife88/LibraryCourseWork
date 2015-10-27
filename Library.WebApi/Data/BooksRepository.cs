using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class BooksRepository : IBooksRepository
    {
        private bool _disposed;
        private readonly LibraryDbContext _dbContext;
        public BooksRepository()
        {
            _dbContext = new LibraryDbContext();
        }
        public async Task<IEnumerable<Book>> GettAllAsync()
        {
            //byte[] picBytes = File.ReadAllBytes("F:\\eldjeron.jpg");
            //byte[] fileTxtBytes = File.ReadAllBytes("F:\\цветы для элджерона.txt");
            //Author keez = new Author { FirstName = "Дэниел", LastName = "Киз" };
            //Category scineceFantastic = new Category()
            //{
            //    CategoryName = "научно-фантастический рассказ",
            //    CategoryDescription = "Научная фантастика описывает вымышленные технологии и научные открытия, "
            //};
            //Book billiMiligan = new Book()
            //{
            //    BookName = "Билли милиган",
            //    ISBN = "0-15-131510-8",
            //    NumberOfPages = 223,
            //    Category = scineceFantastic,
            //    ImageOfBook = picBytes,
            //    FileTxt = fileTxtBytes,
            //    Author = keez,
            //};
            //Book eldjeron = new Book()
            //{
            //    BookName = "Цветы для Элджернона",
            //    ISBN = "0-15-131510-8",
            //    NumberOfPages = 311,
            //    Category = scineceFantastic,
            //    Author = keez,
            //};
            return await _dbContext.Books.ToArrayAsync();
            // ADD SOME DATA
            //_dbContext.Books.Add(billiMiligan);
            //_dbContext.Books.Add(eldjeron);
            //_dbContext.SaveChanges();

            // КОСТЫЛЬ
            //List<Book> books = new List<Book>();
            //var ave =  _dbContext.Authors.ToList();
            //foreach (var author in ave)
            //{
            //   var collection =  author.Books.ToArray();
            //    foreach (var a in collection)
            //    {

            //        books.Add(new Book()
            //        {
            //           Author = a.Author,
            //           BookId = a.BookId,
            //           ImageOfBook =  a.ImageOfBook,
            //           FileTxt = a.FileTxt,
            //           Category = a.Category,
            //           AuthorId = a.AuthorId,
            //           BookName = a.BookName,
            //           CategoryId = a.CategoryId,
            //           ISBN = a.ISBN,
            //           NumberOfPages = a.NumberOfPages
            //        });
            //    }
            //}
            //return books;
        }
        public async Task<Book> GetAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(r => r.BookId == id);
        }
        public async Task<Book> AddAsync(Book item)
        {
            Author existingAuthor = await _dbContext.Authors.SingleOrDefaultAsync(r =>
               r.FirstName.ToUpper() == item.Author.FirstName.ToUpper() &&
               r.LastName.ToUpper() == item.Author.LastName.ToUpper());
            Category category = await _dbContext.Categories.SingleOrDefaultAsync(r =>
                r.CategoryName.ToUpper() == item.Category.CategoryName.ToUpper());
            if (existingAuthor != null && category != null)
            {
                item.Author = existingAuthor;
                item.Category = category;
                _dbContext.Books.Add(item);
                _dbContext.SaveChanges();
            }
            Author newAuthor = new Author()
            {
                FirstName = item.Author.FirstName,
                LastName = item.Author.LastName
            };
            Category newCategory = new Category()
            {
                CategoryName = item.Category.CategoryName,
                CategoryDescription = item.Category.CategoryName,
            };
            item.Author = newAuthor;
            item.Category = newCategory;
            _dbContext.Books.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        //геморно юзать это
        public async Task<Book> UpdateAsync(Book item)
        {
            var updateValue = await _dbContext.Books.SingleOrDefaultAsync(r => r.BookId == item.BookId);
            if (updateValue != null)
            {
                updateValue.Author = item.Author;
                updateValue.BookName = item.BookName;
                updateValue.Category = item.Category;
                updateValue.ISBN = item.ISBN;
                updateValue.NumberOfPages = updateValue.NumberOfPages;
                updateValue.FileTxt = updateValue.FileTxt;
                updateValue.ImageOfBook = updateValue.ImageOfBook;
                _dbContext.Books.Attach(updateValue);
                _dbContext.Entry(updateValue).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return updateValue;
            }
            return null;
        }
        public async Task<object> RemoveAsync(int id)
        {
            var item = await _dbContext.Books.FirstOrDefaultAsync(r => r.BookId == id);
            if (item != null)
            {
                _dbContext.Books.Remove(item);
                return await _dbContext.SaveChangesAsync();
            }
            return null;

        }
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}