using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.DAO
{
    public class DAO
    {
        public static HttpClient Client
        {
            get
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:30923/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            }
        }
    }
}
