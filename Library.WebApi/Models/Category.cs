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
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}