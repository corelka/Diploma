using Diploma.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Diploma.Controllers
{
    public class CalendarController: Controller
    {
        private DashboardContext _context;
        private UserManager<User> _userManager;
        public CalendarController(DashboardContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ViewResult Calendar()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents(string UserName)
        {
            var events = _context.Events.Where(t => t.UserName == UserName).ToList();
            var user = _context.Users.FirstOrDefault(t => t.UserName == UserName);
            if(_userManager.IsInRoleAsync(user, "Teacher").GetAwaiter().GetResult())
            {
                var user_ = _context.Teachers.FirstOrDefault(t => t.UserId == user.Id);
                var sched = (from ct in _context.Schedules
                             join sub in _context.Subjects on ct.SubjectId equals sub.SubjectId
                             join tt in _context.TimeTables on ct.TimeTableId equals tt.TimeTableId
                             where ct.TeacherId == user_.TeacherId
                             select new
                             {
                                 title = sub.Name,
                                 start = tt.StartDateTime,
                                 end = tt.EndDateTime,
                                 day = ct.day
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
                            events.Add(new CalendarEvent()
                            {
                                title = s.title,
                                start = new DateTime(date.Year, date.Month, date.Day, s.start.Hour, s.start.Minute, s.start.Second),
                                end = s.end
                            });
                        }
                    }
                }
                return Json(events);
            }
            else
            {
                var user_ = _context.Students.FirstOrDefault(t => t.UserId == user.Id);
                var sched = (from ct in _context.Schedules
                             join sub in _context.Subjects on ct.SubjectId equals sub.SubjectId
                             join tt in _context.TimeTables on ct.TimeTableId equals tt.TimeTableId
                             where ct.TeacherId == user_.StudentId
                             select new
                             {
                                 title = sub.Name,
                                 start = tt.StartDateTime,
                                 end = tt.EndDateTime,
                                 day = ct.day
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
                            events.Add(new CalendarEvent()
                            {
                                title = s.title,
                                start = new DateTime(date.Year, date.Month, date.Day, s.start.Hour, s.start.Minute, s.start.Second),
                                end = s.end
                            });
                        }
                    }
                }
                return Json(events);
            }            
        }


        [HttpPost]
        public ViewResult CreateEvent(ViewModels.CreateEventViewModel createEvent)
        {
            var _event = new CalendarEvent()
            {
                title = createEvent.title,
                allDay = createEvent.allDay,
                start = createEvent.start,
                end = createEvent.end,
                url = createEvent.url,
                UserName = createEvent.UserName,
                durationEditable = createEvent.editable,
                startEditable = createEvent.editable,
                editable = createEvent.editable
            };
            _context.Events.Add(_event);
            _context.SaveChanges();
            return View("Calendar");
        }

        
    }
}
