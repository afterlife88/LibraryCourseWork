using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Library.WebApi.Data.Interfaces;
using Library.WebApi.Models;

namespace Library.WebApi.Data
{
    public class UsersRepository : IUserRepository
    {
        private bool _disposed;
        private readonly LibraryDbContext _dbContext;
        public UsersRepository()
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
            var findedUser = await _dbContext.Users.FirstOrDefaultAsync(r => r.Surname == user.Surname
                                                            && r.Password == user.Password);
            return findedUser;
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(r => r.UserId == id);
        }
        /// <summary>
        /// Add a book to current user selected by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Book> AddBook(int id, Book item)
        {
            // var obj  = _dbContext.Users
            var findedUser = await _dbContext.Users.FirstOrDefaultAsync(r => r.UserId == id);
            if (findedUser != null)
            {
                var book = await _dbContext.Books.FirstOrDefaultAsync(r => r.BookName == item.BookName);
                book.OwnersUsers.Add(findedUser);
                book.BooksLeft--;
                findedUser.Books.Add(book);
                _dbContext.Books.Attach(book);
                _dbContext.Users.Attach(findedUser);
                _dbContext.Entry(findedUser).State = EntityState.Modified;;
                _dbContext.Entry(book).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return book;
            }
            return null;
        }
        public async Task<Book> RemoveBook(int id, Book item)
        {
            // var obj  = _dbContext.Users
            var findedUser = await _dbContext.Users.FirstOrDefaultAsync(r => r.UserId == id);
            if (findedUser != null)
            {
                var book = await _dbContext.Books.FirstOrDefaultAsync(r => r.BookName == item.BookName);
                book.BooksLeft++;
                _dbContext.Entry(book).State = EntityState.Modified;
                book.OwnersUsers.Remove(findedUser);
                findedUser.Books.Remove(book);
                //_dbContext.Books.Attach(book);
                //_dbContext.Users.Attach(findedUser);
                //_dbContext.Entry(findedUser).State = EntityState.Modified; ;
                //_dbContext.Entry(book).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return book;
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