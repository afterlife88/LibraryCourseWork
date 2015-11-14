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

        readonly static BooksViewModel _booksViewModel = new BooksViewModel();
        readonly static AuthorsViewModel _authorsViewModel = new AuthorsViewModel();

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

        public ICommand BooksViewCommand { get; private set; }
        public ICommand AuthorsViewCommand { get; private set; }

        public MainViewModel()
        {
            CurrentViewModel = MainViewModel._booksViewModel;

            BooksViewCommand = new RelayCommand(ExecuteBooksViewCommand);
            AuthorsViewCommand = new RelayCommand(ExecuteAuthorsViewCommand);
        }

        private void ExecuteBooksViewCommand()
        {
            CurrentViewModel = MainViewModel._booksViewModel;
        }

        private void ExecuteAuthorsViewCommand()
        {
            CurrentViewModel = MainViewModel._authorsViewModel;
        }
    }
}