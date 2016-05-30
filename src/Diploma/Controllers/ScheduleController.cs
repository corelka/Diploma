using Diploma.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Diploma.ViewModels;
using Microsoft.Data.Entity;

namespace Diploma.Controllers
{

    public class ScheduleController: Controller
    {
        private DashboardContext _context;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public ScheduleController(DashboardContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public ViewResult Overview()
        {
            List<ScheduleVIewModel> events = new List<ScheduleVIewModel>();
            var user = _context.Users.FirstOrDefault(t => t.UserName == User.Identity.Name);
            if (_userManager.IsInRoleAsync(user, "Teacher").GetAwaiter().GetResult())
            {
                var user_ = _context.Teachers.FirstOrDefault(t => t.UserId == user.Id);
                var sched = (from ct in _context.Schedules
                             join sub in _context.Subjects on ct.SubjectId equals sub.SubjectId
                             join tt in _context.TimeTables on ct.TimeTableId equals tt.TimeTableId
                             join g in _context.Groups on ct.GroupId equals g.GroupId
                             where ct.TeacherId == user_.TeacherId
                             select new
                             {
                                 title = sub.Name,
                                 start = tt.StartDateTime,
                                 end = tt.EndDateTime,
                                 day = ct.day,
                                 teacher = user.UserName,
                                 gr = g.GroupName
                             }).ToList();
                foreach (var s in sched)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    var date = new DateTime();
                    for (int i = 1; i <= ci.Calendar.GetDaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                    {
                        date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);
                        if (date.DayOfWeek == s.day)
                        {
                            events.Add(new ScheduleVIewModel()
                            {
                                Name = s.title,
                                Start = new DateTime(date.Year, date.Month, date.Day, s.start.Hour, s.start.Minute, s.start.Second),
                                End = s.end,
                                Teacher = s.teacher,
                                Group = s.gr
                            });
                        }
                    }
                }
            }
            else
            {
                var user_ = _context.Students.FirstOrDefault(t => t.UserId == user.Id);
                var sched = (from ct in _context.Schedules
                             join sub in _context.Subjects on ct.SubjectId equals sub.SubjectId
                             join tt in _context.TimeTables on ct.TimeTableId equals tt.TimeTableId
                             join g in _context.Groups on ct.GroupId equals g.GroupId
                             join te in _context.Teachers on ct.TeacherId equals te.TeacherId
                             where ct.GroupId == user_.GroupId
                             select new
                             {
                                 title = sub.Name,
                                 start = tt.StartDateTime,
                                 end = tt.EndDateTime,
                                 day = ct.day,
                                 teacher = te.TeacherId,
                                 gr = g.GroupName
                             }).ToList();
                foreach (var s in sched)
                {
                    CultureInfo ci = new CultureInfo("en-US");
                    var date = new DateTime();
                    for (int i = 1; i <= ci.Calendar.GetDaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
                    {
                        date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);
                        if (date.DayOfWeek == s.day)
                        {
                            var teacher = _context.Teachers.Include(c => c.User).FirstOrDefault(t => t.TeacherId == s.teacher);
                            events.Add(new ScheduleVIewModel()
                            {
                                Name = s.title,
                                Start = new DateTime(date.Year, date.Month, date.Day, s.start.Hour, s.start.Minute, s.start.Second),
                                End = s.end,
                                Group = s.gr,
                                Teacher = teacher.User.Name
                            });
                        }
                    }
                }
            }


            ViewBag.Events = events;
            return View(events);
        }
    }
}
