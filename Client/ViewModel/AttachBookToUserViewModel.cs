using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.DAO;
using Client.Interfaces;
using Client.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Client.ViewModel
{
    public class AttachBookToUserViewModel : ViewModelBase
    {
        public IAttachBookToUserView AttachBookToUserView { get; set; }

        private Book _selectedBook;

        public User SelectedUser { get; set; }

        public Book SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                if (_selectedBook != null)
                {
                    UsersThatHaveBook = new ObservableCollection<User>(_selectedBook.OwnersUsers);
                    AttachBookToUserView?.SetUsersThatHaveBook(UsersThatHaveBook);
                }
            }
        }

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<User> UsersThatHaveBook { get; set; }  

        public ICommand AttachBookToUserCommand { get; private set; }

        public AttachBookToUserViewModel()
        {
            GetUsers();
            GetBooks();

            AttachBookToUserCommand = new RelayCommand(ExecuteAttachBookToUserCommand);
        }

        private async void GetUsers()
        {
            Users = new ObservableCollection<User>(await UsersDAO.GetUsers());
            AttachBookToUserView?.SetUsers(Users);
        }

        private async void GetBooks()
        {
            Books = new ObservableCollection<Book>(await BooksDAO.GetBooks());
            AttachBookToUserView?.SetBooks(Books);
        }

        private async void ExecuteAttachBookToUserCommand()
        {
            await UsersDAO.AddBookToUser(SelectedUser.UserId, SelectedBook);

            GetUsers();
            GetBooks();
        }
    }
}
