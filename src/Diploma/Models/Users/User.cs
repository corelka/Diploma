using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNet.Identity;



namespace Diploma.Models
{
    public class User : IdentityUser
    {
        /*public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }*/

        public DateTime CreateDate { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public DateTime Birth { get; set; }

        public string Avatar { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public User()
        {
            //Dashboards = new HashSet<Dashboard>();
        }
        //public virtual ICollection<Dashboard> Dashboards { get; set; }
    }
}
