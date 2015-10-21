using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.WebApi.Models;

namespace Library.WebApi.Data.Interfaces
{
    public interface IBooksRepository : IDisposable
    {
        Task<IEnumerable<Book>> GettAllAsync();
        Task<Book> GetAsync(int id);
        Task<Book> AddAsync(Book item);
        Task<Book> UpdateAsync(Book item);
        Task<object> RemoveAsync(int id);
    }
}