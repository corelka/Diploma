using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.ViewModels
{
    public class ChangeProfileViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IFormFile Avatar { get; set; }
    }
}