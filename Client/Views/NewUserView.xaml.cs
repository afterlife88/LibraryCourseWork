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
using Client.ViewModel;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for NewUserView.xaml
    /// </summary>
    public partial class NewUserView : UserControl, IPasswordProperty
    {
        public NewUserView()
        {
            InitializeComponent();

            (DataContext as NewUserViewModel).NewUserView = this as IPasswordProperty;
        }

        public string GetPassword()
        {
            return PassBox.Password;
        }

        public void SetPassword(string pass)
        {
            PassBox.Password = pass;
        }
    }
}
