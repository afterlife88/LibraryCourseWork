using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Client.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        readonly static NewUserViewModel _newUserViewModel = new NewUserViewModel();
        readonly static NewBookViewModel _newBookViewModel = new NewBookViewModel();
        readonly static AttachBookToUserViewModel _attachBookToUserViewModel = new AttachBookToUserViewModel();

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public ICommand NewUserViewCommand { get; private set; }
        public ICommand NewBookViewCommand { get; private set; }
        public ICommand AttachBookToUserCommand { get; private set; }

        public MainViewModel()
        {
            CurrentViewModel = _newUserViewModel;

            NewUserViewCommand = new RelayCommand(ExecuteNewUserViewCommand);
            NewBookViewCommand = new RelayCommand(ExecuteNewBookViewCommand);
            AttachBookToUserCommand = new RelayCommand(ExecuteAttachBookToUserCommand);
        }

        private void ExecuteNewUserViewCommand()
        {
            CurrentViewModel = MainViewModel._newUserViewModel;
        }

        private void ExecuteNewBookViewCommand()
        {
            CurrentViewModel = MainViewModel._newBookViewModel;
        }
        private void ExecuteAttachBookToUserCommand()
        {
            CurrentViewModel = MainViewModel._attachBookToUserViewModel;
        }
    }
}