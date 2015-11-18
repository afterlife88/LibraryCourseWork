using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.DAO;
using Client.Interfaces;
using Client.Models;
using Client.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Client.ViewModel
{
    public class NewUserViewModel : ViewModelBase
    {
        public IPasswordProperty NewUserView { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICommand CreateUserCommand { get; private set; }

        public NewUserViewModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;

            CreateUserCommand = new RelayCommand(ExecuteCreateUserCommand);
        }

        private async void ExecuteCreateUserCommand()
        {
            User user = new User()
            {
                Name = FirstName,
                Surname = LastName,
                Password = NewUserView.GetPassword()
            };

            FirstName = string.Empty;
            LastName = string.Empty;
            NewUserView.SetPassword(string.Empty);

            if (await UsersDAO.CreateUser(user))
                MessageBox.Show("Пользователь создан успешно");
        }
    }
}
