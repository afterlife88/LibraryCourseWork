using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class UserRepository : IUserRepository
    {
        private bool _disposed;
        private readonly LibraryDbContext _dbContext;
        public UserRepository()
        {
            _dbContext = new LibraryDbContext();
        }
        public async Task<User> RegistrateUser(User user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User> ValidateUser(User user)
        {

            // Возвращает объект юзера или нал, по этому проверку на нал дальше не делаю 
            var findedUser = await _dbContext.Users.FirstOrDefaultAsync(r => r.Surname == user.Surname
                                                            && r.Password == user.Password);
            return findedUser;
        }

        public async Task<User> GetUser(int id)
        {
            return null;
            // return await _dbContext.Users.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<User> AddBook(int id, Book book)
        {
           // var obj  = _dbContext.Users
            var findedUser = await _dbContext.Users.FirstOrDefaultAsync(r => r.UserId == id);
            if (findedUser != null)
            {
                var bookDb = new Book();
                bookDb.OwnersUsers.Add(findedUser);
                _dbContext.Books.Add(bookDb);

                //findedUser.Books.Add(new Book()
                //{
                //    BookName = book.BookName
                //});
                //_dbContext.Users.Add(findedUser);
                await _dbContext.SaveChangesAsync();
                return findedUser;

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