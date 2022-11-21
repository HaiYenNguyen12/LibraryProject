using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class LoanDto
    {
        public string BookName { get; set; }
        public string Username {get; set;}
         public DateTime  Loan_Date { get; set; }

    }

    // public class AuthorWithBookDto 
    // {
    //     public string FullName { get; set; }
    //     public List<string> BookTitles {get; set;}
    // }
}