using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<User> Users { get; set; }

        public ICommand AttachBookToUserCommand { get; private set; }

        public AttachBookToUserViewModel()
        {
            GetUsers();

            AttachBookToUserCommand = new RelayCommand(ExecuteAttachBookToUserCommand);
        }

        private async void GetUsers()
        {
            Users = new ObservableCollection<User>(await UsersDAO.GetUsers());
            AttachBookToUserView?.SetListBox(Users);
        }

        private async void ExecuteAttachBookToUserCommand()
        {
            
        }
    }
}
