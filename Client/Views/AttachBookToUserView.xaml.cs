using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.Interfaces;
using Client.Models;
using Client.ViewModel;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for AttachBookToUserView.xaml
    /// </summary>
    public partial class AttachBookToUserView : UserControl, IAttachBookToUserView
    {
        public AttachBookToUserView()
        {
            InitializeComponent();

            (DataContext as AttachBookToUserViewModel).AttachBookToUserView = this as IAttachBookToUserView;
        }

        public void SetUsers(IEnumerable<User> collection)
        {
            ListBoxUsers.ItemsSource = collection;
        }

        public void SetBooks(IEnumerable<Book> collection)
        {
            ListBoxBooks.ItemsSource = collection;
        }

        public void SetUsersThatHaveBook(IEnumerable<User> collection)
        {
            ListBoxUsersThatHaveBook.ItemsSource = collection;
        }
    }
}
