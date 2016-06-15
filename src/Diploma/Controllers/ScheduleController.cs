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
                             select new ScheduleVIewModel()
                             {
                                 Name = sub.Name,
                                 Start = tt.StartDateTime.ToShortTimeString(),
                                 End = tt.EndDateTime.ToShortTimeString(),
                                 Day = ct.day,
                                 Teacher = user.UserName,
                                 Group = g.GroupName
                             }).OrderBy(s=>s.Day).ThenBy(t=>t.Start).ToList();
                events.AddRange(sched);
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
                             }).OrderBy(s => s.day).ThenBy(t=>t.start).ToList();
            }


            ViewBag.Events = events;
            return View(events);
        }
    }
}
