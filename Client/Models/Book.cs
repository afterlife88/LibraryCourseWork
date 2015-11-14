using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }

        public virtual Category Category { get; set; }

        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public string BookDescription { get; set; }
        public int YearOfBook { get; set; }
        public string OriginalNameOfBook { get; set; }

        public int BooksLeft { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<User> OwnersUsers { get; set; }

        public Book()
        {
            BookId = 0;
            ISBN = string.Empty;
            Category = new Category();
            BookName = string.Empty;
            NumberOfPages = 0;
            BookDescription = string.Empty;
            YearOfBook = 0;
            OriginalNameOfBook = string.Empty;
            BooksLeft = 0;
            Author = new Author();
            OwnersUsers = new HashSet<User>();
        }
    }
}
