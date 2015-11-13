using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Library.WebApi.Models
{
    [Serializable]
    public class Book
    {
        public Book()
        {
            OwnersUsers = new HashSet<User>();
        }
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        //ForeignKey bookauthor
        [JsonIgnore]
        public int AuthorId { get; set; }
        //foreignkey catgory
        [JsonIgnore]
        public int CategoryId { get; set; }
        [Required]
       // [DataType()]
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        /// <summary>
        /// Количество книг которые остались
        /// </summary>
        public int BooksLeft { get; set; }
        [Column(TypeName = "image")]
        [JsonIgnore]
        public byte[] ImageOfBook { get; set; }
        public string ISBN { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<User> OwnersUsers { get; set; }
        public virtual Category Category { get; set; }

    }
}