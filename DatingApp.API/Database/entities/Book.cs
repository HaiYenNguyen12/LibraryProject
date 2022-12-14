using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatingApp.API.Database.entities
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string?  Title { get; set; } 
        public string?  Description { get; set; } 
        public bool IsRead { get; set; } 
        public DateTime? DateRead {get; set;}
        public int? Rate { get; set; }
       
        public string? Genre { get; set; }
        public string? CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        //Navigation Properties

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual List<Book_Author>  Book_Authors { get; set; }
        public int? Copies_Owned { get; set; }

        public virtual List<Loan> Loans {get; set;}

       

    
    }
}