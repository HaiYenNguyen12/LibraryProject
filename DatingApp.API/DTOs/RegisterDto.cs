using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        [StringLength(32)]
       
        public string  Username { get; set; } = string.Empty;

        
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string  Email { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;

        public string Role { get; set; } = "user";

    }
}