using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Library.WebApi.Models;

namespace Library.WebApi.Data.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<User> RegistrateUser(User user);
        Task<User> ValidateUser(User user);
        Task<User> GetUser(int id);
        Task<Book> AddBook(int id, Book book);
        Task<Book> RemoveBook(int id, Book item);
        Task<IEnumerable<User>> GetAllUsers();
    }
}