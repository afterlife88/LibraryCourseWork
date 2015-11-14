using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Models;
using Newtonsoft.Json;

namespace Client.DAO
{
    public static class BooksDAO
    {
        public static async Task<IEnumerable<Book>> GetBooks()
        {
            HttpResponseMessage response = await DAO.Client.GetAsync("api/books/");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Book>>(content);
        }

        public static async Task<Book> GetBook(int id)
        {
            HttpResponseMessage response = await DAO.Client.GetAsync($"api/books/{id}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Book>(content);
        }

        public static async Task<bool> AddBook(Book book)
        {
            string jsonObj = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAO.Client.PostAsync("api/books/", content);

            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> UpdateBook(Book book)
        {
            string jsonObj = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAO.Client.PutAsync("api/books/", content);

            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteBook(int id)
        {
            HttpResponseMessage response = await DAO.Client.DeleteAsync($"api/books/removebook/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
