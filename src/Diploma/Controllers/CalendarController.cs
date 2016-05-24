using Diploma.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Controllers
{
    public class CalendarController: Controller
    {
        private DashboardContext _context;

        public CalendarController(DashboardContext context)
        {
            _context = context;
        }

        /*[HttpGet]
        public JsonResult GetEvents(string UserName)
        {
            var events = _context.Events.Where(t => t.UserName == UserName).ToList();
            var user = _context.Users.FirstOrDefault(t => t.UserName == UserName);
            
            if (user.Teacher != null)
            {
                var user_ = user.Teacher;
                var grups = _context.Groups.Include(t => t.Schedules).Include(t => t.Teachers.Where(p => p.Teacher == user_));                
            }
                
            else
                user_ = user.Student;
            var scedules = _context.Schedules. .Where(t=>t.GroupId == )

                //var user_ = user.Student;
        }*/

    }
}
