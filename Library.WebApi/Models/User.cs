using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Library.WebApi.Models
{
    /// <summary>
    /// Класс юзера
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

     
    }

}