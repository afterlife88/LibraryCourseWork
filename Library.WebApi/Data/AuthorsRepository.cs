using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private bool _disposed;
        private readonly LibraryDbContext _dbContext;
        public AuthorsRepository()
        {
            _dbContext = new LibraryDbContext();
        }
        public async Task<IEnumerable<Author>> GettAllAsync()
        {
            return await _dbContext.Authors.ToArrayAsync();
        }
        public async Task<Author> GetAsync(int id)
        {
            return await _dbContext.Authors.SingleOrDefaultAsync(r => r.AuthorId == id);
        }
        public async Task<IEnumerable> GetBooksByAuthor(int id)
        {
            var item = await _dbContext.Authors.SingleOrDefaultAsync(r => r.AuthorId == id);
            return item.Books.ToArray();
        }

        public async Task<IEnumerable> GetBooksByAuthor(string lastName)
        {
            var item = await _dbContext.Authors.SingleOrDefaultAsync(r => r.LastName == lastName);
            return item.Books.ToArray();
        }

        public async Task<IEnumerable<Book>> GetOrderByAsc()
        {
            var list = await _dbContext.Books.ToArrayAsync();
            return list.OrderBy(r => r.Author.FirstName);
        }

        public async Task<Author> AddAsync(Author item)
        {
            Author existingAuthor = await _dbContext.Authors.SingleOrDefaultAsync(r =>
                 r.FirstName.ToUpper() == item.FirstName.ToUpper() &&
                 r.LastName.ToUpper() == item.LastName.ToUpper());
            if (existingAuthor != null)
            {
                return null;
            }
            Author newAuthor = new Author()
            {
                FirstName = item.FirstName,
                LastName = item.LastName
            };
            _dbContext.Authors.Add(newAuthor);
            await _dbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Author> UpdateAsync(Author item)
        {
            var updateAuthor = await _dbContext.Authors.SingleOrDefaultAsync(r => r.AuthorId == item.AuthorId);

            if (updateAuthor != null)
            {
                updateAuthor.FirstName = item.FirstName;
                updateAuthor.LastName = item.LastName;
                await _dbContext.SaveChangesAsync();
                return updateAuthor;
            }
            return null;
        }
        public async Task<object> RemoveAsync(int id)
        {
            var item = await _dbContext.Authors.FirstOrDefaultAsync(r => r.AuthorId == id);
            if (item != null)
            {
                _dbContext.Authors.Remove(item);
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