using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:30923/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage x = await client.GetAsync("api/books/");
            string content = await x.Content.ReadAsStringAsync();

            MessageBox.Show(content);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Get();
        }
    }
}
