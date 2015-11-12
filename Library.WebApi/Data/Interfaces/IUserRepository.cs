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
        Task<User> AddBook(int id, Book book);
    }
}