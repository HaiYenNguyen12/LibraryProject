using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class AuthorDto
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBookDto 
    {
        public string FullName { get; set; }
        public List<string> BookTitles {get; set;}
    }
}