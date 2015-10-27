using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.WebApi.Models;

namespace Library.WebApi.Data.Interfaces
{
    public interface IAuthorsRepository : IDisposable
    {
        Task<IEnumerable<Author>> GettAllAsync();
        Task<Author> GetAsync(int id);
        Task<Author> AddAsync(Author item);
        Task<Author> UpdateAsync(Author item);
        Task<object> RemoveAsync(int id);
        Task<IEnumerable> GetBooksByAuthor(int id);
        Task<IEnumerable> GetBooksByAuthor(string lastName);
    }
}
