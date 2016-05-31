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
            var users = _context.Users.ToList();
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




        [HttpGet]
        public ActionResult Subjects()
        {
            var subs = _context.Subjects.ToList();
            return View(subs);
        }

        public ActionResult DeleteSubject(int id)
        {
            var sub = _context.Subjects.FirstOrDefault(t => t.SubjectId == id);
            if (sub != null)
            {
                _context.Subjects.Remove(sub);
                _context.SaveChanges();
            }                
            return RedirectToAction("Subjects");
        }

        public ActionResult CreateSubject()
        {
            return RedirectToAction("Subjects");
        }


        [HttpGet]
        public ActionResult Groups()
        {
            var subs = _context.Groups.ToList();
            return View(subs);
        }

        public ActionResult DeleteGroup(int id)
        {
            var gr = _context.Groups.FirstOrDefault(t => t.GroupId == id);
            if (gr != null)
            {
                _context.Remove(gr);
                _context.SaveChanges();
            }
            return RedirectToAction("Groups");
        }

        public ActionResult CreateGroup()
        {
            return RedirectToAction("Groups");
        }

        [HttpGet]
        public ActionResult Schedules()
        {
            var _sched = (from sched in _context.Schedules
                       join s in _context.Subjects on sched.SubjectId equals s.SubjectId
                       join t in _context.Teachers on sched.TeacherId equals t.TeacherId
                       join u in _context.Users on t.UserId equals u.Id
                       join g in _context.Groups on sched.GroupId equals g.GroupId
                       join tt in _context.TimeTables on sched.TimeTableId equals tt.TimeTableId
                       select new ViewModels.ScheduleVIewModel
                       {
                           Id = sched.ScheduleId,
                           Teacher = u.UserName,
                           Name = s.Name,          
                           Group = g.GroupName,
                           Start = tt.StartDateTime,
                           End = tt.EndDateTime                 
                       }).ToList();
            return View(_sched);
        }
    }
}
