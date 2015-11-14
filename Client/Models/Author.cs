using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author()
        {
            AuthorId = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
