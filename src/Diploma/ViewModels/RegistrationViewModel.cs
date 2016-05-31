using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Http;

namespace Diploma.ViewModels
{
    public class RegistrationViewModel
    {
        public RegistrationViewModel()
        {
            Groups = new HashSet<string>();
            Subjects = new HashSet<string>();
        }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Group { get; set; }

        public int Course { get; set; }
        
        public string StudentCard { get; set;}

        public ICollection<string> Groups { get; set; }

        public ICollection<string> Subjects { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
