using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.WebApi.Models
{
    [Serializable]
    public class Book
    {

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        //ForeignKey bookauthor

        public int AuthorId { get; set; }
        //foreignkey catgory
        public int CategoryId { get; set; }
        [Required]
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

    }
}