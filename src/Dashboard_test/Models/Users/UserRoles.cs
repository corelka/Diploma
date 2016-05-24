using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dashboard_test.Models
{
    public class UserRoles : IdentityRole
    {
        public UserRoles(string name)
            :base(name)
        {

        }
        public UserRoles()
        {
        
        }

        public string Description { get; set; }
    }
}
