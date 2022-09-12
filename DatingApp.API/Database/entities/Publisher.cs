using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Database.entities
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string? Name  { get; set; } 


        //Add navigation properties

        public List<Book>  Books { get; set; }
        
    }
}