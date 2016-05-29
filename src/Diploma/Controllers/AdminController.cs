using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Models;
using Microsoft.AspNet.Identity;

namespace Diploma.Controllers
{
    public class AdminController: Controller
    {
        public DashboardContext _context;
        public UserManager<User> _userManager;
        public AdminController (UserManager<User> userManager, DashboardContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public ViewResult Home()
        {
            return View();
        }

        public ActionResult Accounts()
        {
            var Teachers = (from teach in _context.Teachers
                         join user in _context.Users on teach.UserId equals user.Id
                         select new
                         {
                             user.UserName,
                             user.Name,
                             user.Surname,
                             user.Roles,
                             user.CreateDate,
                             user.Birth,
                             user.Avatar
                         }).ToList();
            var Students = (from stud in _context.Students
                            join user in _context.Users on stud.UserId equals user.Id
                            select new
                            {
                                user.UserName,
                                user.Name,
                                user.Surname,
                                user.Roles,
                                user.CreateDate,
                                user.Birth,
                                user.Avatar
                            }).ToList();
            var users = Students.Union(Teachers);
            return View(users);
        }

        [HttpPost]
        public ActionResult ChangePassword(ViewModels.AdminChangePasswordViewModel model)
        {
            var user = _context.Users.FirstOrDefault(t => t.UserName == model.UserName);
            if (user != null)
            {
                _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Accounts");
        }
    }
}
