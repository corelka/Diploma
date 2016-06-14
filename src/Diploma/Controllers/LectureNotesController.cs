using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Authorization;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;

namespace Diploma.Controllers
{
    public class LectureNotesController: Controller
    {
        DashboardContext _context;
        UserManager<User> _userManager;

        public LectureNotesController(DashboardContext context,UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        public ViewResult Overview()
        {            
            if (User.IsInRole("Teacher"))
            {
                var teacher = _context.Teachers.FirstOrDefault(t => t.User.UserName == User.Identity.Name);
                var lects = _context.LecctureNotes.Include(r=>r.Teacher).ThenInclude(r=>r.User).Include(r=>r.Subject).Where(t => t.TeacherId == teacher.TeacherId).ToList();
                return View(lects);
            }
            else if (User.IsInRole("Student"))
            {
                var student = _context.Students.FirstOrDefault(t => t.User.UserName == User.Identity.Name);
                var lects = _context.LecctureNotes.Include(r => r.Teacher).ThenInclude(r => r.User).Include(r => r.Subject).Where(t => t.Course == student.Course).ToList();
                return View(lects);
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateNote()
        {
            if (User.IsInRole("Teacher"))
            {
                var teacher = _context.Teachers.Include(t=>t.User).FirstOrDefault(t => t.User.UserName == User.Identity.Name);
                var subs = (from sub in _context.Subjects
                           join ts in _context.SubjectTeacher on sub.SubjectId equals ts.SubjectId
                           where ts.TeacherId == teacher.TeacherId
                           select sub.Name).ToList();
                ViewBag.Subs = subs;
                return View(new ViewModels.LectureNoteViewModel());
            }
            else return RedirectToAction("Overview");            
        }

        [HttpPost]
        public ActionResult CreateNote(ViewModels.LectureNoteViewModel lect)
        {
            if (User.IsInRole("Teacher"))
            {
                var teacher = _context.Teachers.FirstOrDefault(t => t.User.UserName == User.Identity.Name);
                var ln = new LectureNotes(lect,teacher);
                ln.Subject = _context.Subjects.FirstOrDefault(t => t.Name == lect.Subject);
                ln.Teacher = teacher;
                
                if(lect.Attachment != null)
                {
                    string nameLecNote = teacher.TeacherId + AccountController.GetFileName(lect.Attachment.ContentDisposition)[0] + '.' + AccountController.GetFileName(lect.Attachment.ContentDisposition)[1];
                    string pathForName = "wwwroot/Files/" + nameLecNote;
                    lect.Attachment.SaveAs(pathForName);
                    ln.Attachment = "/Files/"+nameLecNote;
                }
                _context.LecctureNotes.Add(ln);
                _context.SaveChanges();
            }
            return RedirectToAction("Overview");
        }
        [Authorize]
        public ActionResult DeleteLecture(int ID)
        {            
            var ln = _context.LecctureNotes.FirstOrDefault(t => t.LectureNotesId == ID);
            if (ln != null)
            {
                var usr = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                var teacher = _context.Teachers.FirstOrDefault(t => t.UserId == usr.Id);
                if (ln.TeacherId == teacher.TeacherId)
                _context.LecctureNotes.Remove(ln);
                _context.SaveChanges();
            }
            return RedirectToAction("Overview");
        }
    }
}
