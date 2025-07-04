using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; } 
        public required string Author { get; set; }
        public required string ISBN { get; set; }    
    }
}
