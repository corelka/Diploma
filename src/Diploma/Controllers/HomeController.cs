using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Diploma.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;

namespace Diploma.Controllers
{
    public class HomeController : Controller
    {
        private DashboardContext _context;
        private UserManager<User> _userManager;
        public HomeController(DashboardContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Home", "Admin");
                }
                var dashboards = _context.Dashboards.Where(t => t.UserName == User.Identity.Name).ToList();
                return View(dashboards);
            }
            else
                return RedirectToAction("Login", "Account");
        }
        
        [Authorize]
        public ViewResult Contacts()
        {
            return View();
        }

        //public ViewResult Notes()
        //{
        //    var user = _context.Users.FirstOrDefault(t => t.Name == User.Identity.Name);
        //    var notes = new List<Note>();
        //    if (user is Teacher)
        //    {
        //        notes = _context.Notes.Where(t => t.TeacherId == ((Teacher)user).TeacherId).ToList();
        //    }
        //    else if (user is Student)
        //    {
        //        //notes = _context.Notes.Where(t => t.Groups.First(r => r == ((Student)user).Group) != null).ToList();
        //    }                
        //    return View();
        //}
        public ViewResult Error()
        {
            return View();
        }
    }
}
