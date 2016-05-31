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

        [HttpGet]
        public ActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubject(string SubjectName)
        {
            _context.Add(new Subject()
            {
                Name = SubjectName
            });
            _context.SaveChanges();
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

        [HttpGet]
        public ActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGroup(string GroupName)
        {
            _context.Add(new Group()
            {
                GroupName = GroupName
            });
            _context.SaveChanges();
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

        public ActionResult DeleteSchedule(int Id)
        {
            var sched = _context.Schedules.FirstOrDefault(t => t.ScheduleId == Id);
            if (sched != null)
            {
                _context.Schedules.Remove(sched);
                _context.SaveChanges();
            }
            return RedirectToAction("Schedules");
        }

        [HttpGet]
        public ActionResult CreateSchedule()
        {
            ViewBag.Subjects = (from i in _context.Subjects select i.Name).ToList();
            ViewBag.Groups = (from i in _context.Groups select i.GroupName).ToList();
            ViewBag.Teachers = (from i in _context.Teachers 
                               join u in _context.Users on i.UserId equals u.Id
                               let name = u.UserName
                               select name).ToList();
            ViewBag.Time = (from i in _context.TimeTables
                           let time = i.StartDateTime.ToShortTimeString() + '_' + i.EndDateTime.ToShortTimeString()
                           select time).ToList();
            return View();
        }


        [HttpPost]
        public ActionResult CreateSchedule(ViewModels.CreateScheduleViewModel _sched)
        {
            var Schedule = new Schedule()
            {
                GroupId = _context.Groups.FirstOrDefault(t => t.GroupName == _sched.Group).GroupId,
                SubjectId = _context.Subjects.FirstOrDefault(t => t.Name == _sched.Subject).SubjectId,
                TeacherId = (from i in _context.Teachers
                             join u in _context.Users on i.UserId equals u.Id
                             where u.UserName == _sched.Teacher
                             select i.TeacherId).FirstOrDefault(),
                TimeTableId = (from i in _context.TimeTables
                               where i.StartDateTime.ToShortTimeString().Equals(_sched.Time.Split('_')[0])
                               &&
                               i.EndDateTime.ToShortTimeString().Equals(_sched.Time.Split('_')[1])
                               select i.TimeTableId).FirstOrDefault(),
                day = _sched.Day
            };
            _context.Schedules.Add(Schedule);
            var tg = _context.TeacherGroup.FirstOrDefault(t => t.TeacherId == Schedule.TeacherId && t.GroupId == Schedule.GroupId);
            if (tg == null)
            {
                _context.TeacherGroup.Add(new TeacherGroup()
                {
                    GroupId = Schedule.GroupId,
                    TeacherId = Schedule.TeacherId
                });
            }

            var ts = _context.SubjectTeacher.FirstOrDefault(t => t.TeacherId == Schedule.TeacherId && t.SubjectId == Schedule.SubjectId);
            if(ts == null)
            {
                _context.SubjectTeacher.Add(new SubjectTeacher()
                {
                    SubjectId = Schedule.SubjectId,
                    TeacherId = Schedule.TeacherId
                });
            }
            _context.SaveChanges();
            return RedirectToAction("Schedules");
        }
    }
}
