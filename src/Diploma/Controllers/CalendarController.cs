using Diploma.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;

namespace Diploma.Controllers
{
    public class CalendarController: Controller
    {
        [Authorize]
        public ViewResult Overview()
        {
            return View("Calendar");
        }
    }

    public class CalendarEventController: ApiController
    {
        private DashboardContext _context;
        private UserManager<User> _userManager;
        public CalendarEventController(DashboardContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage DeleteEvent([FromBody]ViewModels.CreateEventViewModel _event)
        {
            var ev = _context.Events.FirstOrDefault(t => t.UserName == User.Identity.Name && 
                                                        t.start == Convert.ToDateTime(_event.start,new CultureInfo("en-US")) && 
                                                        t.end == Convert.ToDateTime(_event.end, new CultureInfo("en-US"))); 
            if (ev!= null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }            
            return new HttpResponseMessage(HttpStatusCode.NotFound);           
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage ChangeEvent([FromBody]ViewModels.ChangeEventViewModel _event)
        {
            var ev = _context.Events.FirstOrDefault(t => t.UserName == User.Identity.Name 
                                                        &&
                                                        t.title == _event.title 
                                                        &&
                                                        t.start == Convert.ToDateTime(_event.start, new CultureInfo("en-US"))
                                                        &&
                                                        t.end == Convert.ToDateTime(_event.end, new CultureInfo("en-US")));
            if (ev != null)
            {
                ev.start = Convert.ToDateTime(_event.newStartDate, new CultureInfo("en-US"));
                ev.end = Convert.ToDateTime(_event.newEndDate, new CultureInfo("en-US"));
                _context.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetEvents()
        {
            var events = _context.Events.Where(t => t.UserName == User.Identity.Name).ToList();
            var user = _context.Users.FirstOrDefault(t => t.UserName == User.Identity.Name);
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

        [Authorize]
        [HttpPost]

        public HttpResponseMessage CreateEvent([FromBody]ViewModels.CreateEventViewModel createEvent)
        {
            try
            {
                var _event = new CalendarEvent(createEvent, User.Identity.Name);
                _context.Events.Add(_event);
                _context.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
        }        
    }
}
