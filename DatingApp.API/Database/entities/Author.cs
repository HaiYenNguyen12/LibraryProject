using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Database.entities
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }

        //Navigations Properties

        public List<Book_Author>  Book_Authors { get; set; }

    }
}