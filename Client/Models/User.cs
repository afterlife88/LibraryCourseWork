using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User()
        {
            UserId = 0;
            Password = string.Empty;
            Name = string.Empty;
            Surname = string.Empty;
        }
    }
}
