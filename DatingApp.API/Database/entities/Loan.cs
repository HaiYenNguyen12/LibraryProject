using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Database.entities
{
    [Table("Loan")]
    public class Loan
    {
        [Key]
        public int Id { get; set; }

       public int BookId    { get; set; }
       public int UserId { get; set; }
       public User User { get; set; }
       public Book Book { get; set; }
       public DateTime  Loan_Date { get; set; }

        


        
    }
}