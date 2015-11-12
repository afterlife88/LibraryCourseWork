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
            return await _dbContext.Books.ToArrayAsync();
        }
        public async Task<Book> GetAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(r => r.BookId == id);
        }
        public async Task<Book> AddAsync(Book item)
        {
            Author existingAuthor = await _dbContext.Authors.FirstOrDefaultAsync(r =>
               r.FirstName.ToUpper() == item.Author.FirstName.ToUpper() &&
               r.LastName.ToUpper() == item.Author.LastName.ToUpper());
            Category category = await _dbContext.Categories.FirstOrDefaultAsync(r =>
                r.CategoryName.ToUpper() == item.Category.CategoryName.ToUpper());
            if (existingAuthor != null && category != null)
            {
                item.Author = existingAuthor;
                item.Category = category;
                _dbContext.Books.Add(item);
                _dbContext.SaveChanges();
                return item;
            }
            Author newAuthor = new Author()
            {
                FirstName = item.Author.FirstName,
                LastName = item.Author.LastName
            };
            Category newCategory = new Category()
            {
                CategoryName = item.Category.CategoryName,
                CategoryDescription = item.Category.CategoryDescription,
            };
            item.Author = newAuthor;
            item.Category = newCategory;
            _dbContext.Books.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Book> UpdateAsync(Book item)
        {
            var updateValue = await _dbContext.Books.SingleOrDefaultAsync(r => r.BookName == item.BookName);
            if (updateValue != null)
            {
                //updateValue.Author = item.Author;
                updateValue.BookName = item.BookName;
                //updateValue.Category = item.Category;
                updateValue.ISBN = item.ISBN;
                updateValue.NumberOfPages = updateValue.NumberOfPages;
                // updateValue.FileTxt = updateValue.FileTxt;
                //updateValue.ImageOfBook = updateValue.ImageOfBook;
                _dbContext.Books.Attach(updateValue);
                _dbContext.Entry(updateValue).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
                return updateValue;
            }
            return null;
        }
        public async Task<object> RemoveAsync(Book item)
        {
            _dbContext.Books.Remove(item);
            return await _dbContext.SaveChangesAsync();
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