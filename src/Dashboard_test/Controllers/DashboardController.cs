using Dashboard_test.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_test.Controllers
{
    public class DashboardController : Controller
    {
        private DashboardContext _context;


        public DashboardController(DashboardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateDashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDashboard(ViewModels.DashboardViewModel dashboard)
        {
            Dashboard NewDash = new Dashboard();

            NewDash.Created = DateTime.Now;
            NewDash.UserName = User.Identity.Name;
            NewDash.Name = dashboard.Name;

            _context.Dashboards.Add(NewDash);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Overview(int id)
        {

            var dashboard = _context.Dashboards
                .Include(p => p.Tables).ThenInclude(k => k.Issues)
                .First(c => c.Id == id);

            return View(dashboard);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTable(int id, int Did)
        {
            try
            {
                var table = _context.Tables.Include(c => c.Issues).First(c => c.Id == id);
                var dashboard = _context.Dashboards.First(c => c.Id == table.DashboardId);
                if (User.Identity.Name == dashboard.UserName)
                {
                    _context.Issues.RemoveRange(table.Issues);
                    _context.Remove(table);
                    _context.SaveChanges();
                }
            }
            catch
            {

            }
            
            return RedirectToAction("Overview", new { id = Did });
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateTable(int Did)
        {
            var dash = _context.Dashboards.First(c => c.Id == Did);
            dash.Tables.Add(new Table
            {
                Name = Request.Form["Name"],
                CreateDate = DateTime.Now,
                DashboardId = Did
            });
            _context.SaveChanges();
            return RedirectToAction("Overview", new { id = Did });
        }

        [HttpPost]
        public ActionResult MoveIssue(int tableID,int issueID)
        {
            var table = _context.Tables.First(c => c.Id == tableID);
            var issue = _context.Issues.First(c => c.Id == issueID);
            var oldTable = _context.Tables.First(c => c.Id == issue.TableId);
            oldTable.Issues.Remove(issue);
            issue.TableId = tableID;
            table.Issues.Add(issue);
            _context.SaveChanges();
            return RedirectToAction("Overview", new { id = table.DashboardId });
        }

        [HttpGet]
        public ViewResult CreateIssue(int id)
        {
            ViewBag.TableId = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateIssue(ViewModels.IssueViewModel issueModel)
        {
            Issue issue = new Issue()
            {
                Name = issueModel.Name,
                Description = issueModel.Description,
                Comments = issueModel.Comments,
                Created = DateTime.Now,
                TableId = issueModel.TableID
            };
            var table = _context.Tables.First(c => c.Id == issueModel.TableID);
            table.Issues.Add(issue);
            _context.SaveChanges();
            return RedirectToAction("Overview", new { id = table.DashboardId });
        }

        [HttpPost]
        public ActionResult ChangeIssue(ViewModels.IssueViewModel issueModel)
        {
            var issue = _context.Issues.FirstOrDefault(c => c.Id == issueModel.Id);
            issue.Name = issueModel.Name;
            issue.Description = issueModel.Description;
            issue.Comments = issueModel.Comments;
            _context.SaveChanges();
            var t = _context.Tables.FirstOrDefault(p => p.Id == issueModel.TableID);
            return RedirectToAction("Overview", new { id = t.DashboardId });
        }

        [HttpPost]
        public ActionResult DeleteIssue(ViewModels.IssueViewModel issueModel)
        {
            var issue = _context.Issues.FirstOrDefault(c => c.Id == issueModel.Id);
            var table = _context.Tables.FirstOrDefault(c => c.Id == issue.TableId);
            _context.Issues.Remove(issue);
            _context.SaveChanges();            
            return RedirectToAction("Overview", new { id = table.DashboardId });
        }
    }
}
