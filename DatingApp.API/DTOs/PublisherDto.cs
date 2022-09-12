using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class PublisherDto
    {
        public string Name { get; set; }
    }

     public class PublisherWithBooksandAuthorsDto
    {
        public string Name { get; set; }
        public List<BookWithAuthorDto> BookAuthors {get; set;}
    }

    public class BookWithAuthorDto 
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}