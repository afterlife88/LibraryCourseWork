using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Newtonsoft.Json;

namespace Client.DAO
{
    public static class UsersDAO
    {
        public static async Task<User> GetUser(int id)
        {
            HttpResponseMessage response = await DAO.Client.GetAsync($"api/users/{id}");
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(content);
        }

        public static async Task<bool> CreateUser(User user)
        {
            string jsonObj = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAO.Client.PostAsync("api/users/", content);

            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> AddBookToUser(int id, Book book)
        {
            string jsonObj = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAO.Client.PostAsync($"api/users/addbook/{id}", content);

            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> RemoveBookFromUser(int id, Book book)
        {
            string jsonObj = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAO.Client.PostAsync($"api/users/removebook/{id}", content);

            return response.IsSuccessStatusCode;
        }

        public static async Task<bool> ValidateUser(User user)
        {
            string jsonObj = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await DAO.Client.PutAsync("api/users/validate", content);

            return response.IsSuccessStatusCode;
        }
    }
}
