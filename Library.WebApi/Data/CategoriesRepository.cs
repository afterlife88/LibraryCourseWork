using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly LibraryDbContext _dbContext;

        private bool _disposed;
        public CategoriesRepository()
        {
            _dbContext = new LibraryDbContext();
        }

        public async Task<IEnumerable<Category>> GettAllAsync()
        {
            return await _dbContext.Categories.ToArrayAsync();
        }
        public async Task<Category> GetAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(r => r.CategoryId == id);
        }

        public async Task<IEnumerable> GetBooksByCategoryAsync(int id)
        {
            var item = await _dbContext.Categories.SingleOrDefaultAsync(r => r.CategoryId == id);
            return item?.Books.ToArray();
        }

        public async Task<Category> AddAsync(Category item)
        {
            var existingCategory =
                _dbContext.Categories.SingleOrDefaultAsync(r => r.CategoryName.ToUpper() == item.CategoryName.ToUpper());
            if (existingCategory != null)
            {
                return null;
            }
            Category category = new Category()
            {
                CategoryName = item.CategoryName,
                CategoryDescription = item.CategoryDescription
            };
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public Task<Category> UpdateAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<object> RemoveAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetOrderByAsc()
        {
            var list = await _dbContext.Books.ToArrayAsync();
            return list.OrderBy(r => r.Category.CategoryName);
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