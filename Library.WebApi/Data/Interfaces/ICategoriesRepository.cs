using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.WebApi.Models;

namespace Library.WebApi.Data.Interfaces
{
    public interface ICategoriesRepository : IDisposable
    {
        Task<IEnumerable<Category>> GettAllAsync();
        Task<Category> GetAsync(int id);
        Task<Category> AddAsync(Category item);
        Task<Category> UpdateAsync(Category item);
        Task<IEnumerable> GetBooksByCategoryAsync(int id);
        Task<object> RemoveAsync(Category item);
    }
}
