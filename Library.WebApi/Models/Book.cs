using System;
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
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        //ForeignKey bookauthor
        [JsonIgnore]
        public int AuthorId { get; set; }
        //foreignkey catgory
        [JsonIgnore]
        public int CategoryId { get; set; }
        [Required]
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        [Column(TypeName = "image")]
        [JsonIgnore]
        public byte[] ImageOfBook { get; set; }
        [JsonIgnore]
        public byte[] FileTxt { get; set; }
        public string ISBN { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }

    }
}