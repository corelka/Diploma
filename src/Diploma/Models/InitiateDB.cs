using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class InitiateDB
    {
        private DashboardContext _context;
        private UserManager<User> _userManager;
        private RoleManager<UserRoles> _roleManager;

        public InitiateDB(DashboardContext context, UserManager<User> userManager, RoleManager<UserRoles> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public User AddTeacher(string Name)
        {
            var user_t = new User()
            {
                UserName = Name,
                Email = Name + "@gmail.com",
                Teacher = new Teacher()
            };
            user_t.Teacher.User = user_t;
            user_t.Teacher.UserId = user_t.Id;
            _context.Teachers.Add(user_t.Teacher);
            _userManager.CreateAsync(user_t, "Qwerty1!").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user_t, "Teacher").GetAwaiter().GetResult();
            return user_t;
        }
        public User AddStudent(string Name)
        {
            var user_t = new User()
            {
                UserName = Name,
                Email = Name + "@gmail.com",
                Student = new Student()
            };
            user_t.Student.User = user_t;
            user_t.Student.UserId = user_t.Id;
            _context.Students.Add(user_t.Student);
            _userManager.CreateAsync(user_t, "Qwerty1!").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user_t, "Student").GetAwaiter().GetResult();
            return user_t;
        }

        public Subject AddSubject(string Name)
        {
            var subj = new Subject()
            {
                Name = Name,
                Description = "Description of " + Name
            };
            _context.Subjects.Add(subj);
            return subj;
        }


        public async Task SeedTestDataAsync()
        {
            if (!(await _roleManager.RoleExistsAsync("Admin")))
            {
                await _roleManager.CreateAsync(new UserRoles("Admin"));
                await _roleManager.CreateAsync(new UserRoles("Student"));
                await _roleManager.CreateAsync(new UserRoles("Teacher"));
            }

            if (await _userManager.FindByEmailAsync("Admin@gmail.com") == null)
            {
                var admin = new User()
                {
                    Email = "Admin@gmail.com",
                    UserName = "Admin"
                };
                _userManager.CreateAsync(admin, "Qwerty1!").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
                _context.SaveChanges();
                
                var t1 = AddTeacher("Teacher1");
                var t2 = AddTeacher("Teacher2");
                var t3 = AddTeacher("Teacher3");
                var t4 = AddTeacher("Teacher4");
                var t5 = AddTeacher("Teacher5");

                var subj1 = AddSubject("SKS");
                var subj2 = AddSubject("TIS");
                var subj3 = AddSubject("ISEB");
                var subj4 = AddSubject("TKSP");

                subj1.Teachers = new List<SubjectTeacher>()
                {
                    new SubjectTeacher()
                    {
                        Teacher = t1.Teacher
                    },
                    new SubjectTeacher()
                    {
                        Teacher = t2.Teacher
                    }
                };

                subj2.Teachers = new List<SubjectTeacher>()
                {
                    new SubjectTeacher()
                    {
                        Teacher = t3.Teacher
                    }
                };

                subj3.Teachers = new List<SubjectTeacher>()
                {
                    new SubjectTeacher()
                    {
                        Teacher = t4.Teacher
                    },
                    new SubjectTeacher()
                    {
                        Teacher = t5.Teacher
                    }
                };

                subj4.Teachers = new List<SubjectTeacher>()
                {
                    new SubjectTeacher()
                    {
                        Teacher = t5.Teacher
                    }
                };

                _context.SubjectTeacher.AddRange(subj1.Teachers);
                _context.SubjectTeacher.AddRange(subj2.Teachers);
                _context.SubjectTeacher.AddRange(subj3.Teachers);
                _context.SubjectTeacher.AddRange(subj4.Teachers);

                var gr1 = new Group()
                {
                    GroupName = "TE401",
                    Teachers = new List<TeacherGroup>()
                    {
                        new TeacherGroup()
                        {
                            Teacher = t1.Teacher
                        },
                        new TeacherGroup()
                        {
                            Teacher = t3.Teacher
                        }
                    },
                    Students = new List<Student>()
                    {
                        AddStudent("Student").Student,
                        AddStudent("Student1").Student
                    },
                    Subjects = new List<SubjectGroups>()
                    {
                        new SubjectGroups()
                        {
                            Subject = subj1
                        },
                        new SubjectGroups()
                        {
                            Subject = subj2
                        }
                    }
                };
                foreach (var t in gr1.Teachers)
                {
                    t.Group = gr1;
                }
                _context.TeacherGroup.AddRange(gr1.Teachers);
                _context.Groups.Add(gr1);

                var gr2 = new Group()
                {
                    GroupName = "TE402",
                    Teachers = new List<TeacherGroup>()
                    {
                        new TeacherGroup()
                        {
                            Teacher = t1.Teacher
                        },
                        new TeacherGroup()
                        {
                            Teacher = t5.Teacher
                        }
                    },
                    Students = new List<Student>()
                    {
                        AddStudent("Student2").Student,
                        AddStudent("Student3").Student
                    },
                    Subjects = new List<SubjectGroups>()
                    {
                        new SubjectGroups()
                        {
                            Subject = subj4
                        },
                        new SubjectGroups()
                        {
                            Subject = subj1
                        }
                    }
                };
                foreach (var t in gr2.Teachers)
                {
                    t.Group = gr2;
                }
                _context.TeacherGroup.AddRange(gr2.Teachers);
                _context.Groups.Add(gr2);

                //----------------------------------------
                //----------GroupsSeeding-----------------
                //----------------------------------------

                var p1 = new TimeTable()
                {
                    Description = "1st pair",
                    StartDateTime = new DateTime(2000, 1, 1, 8, 0, 0),
                    EndDateTime = new DateTime(2000, 1, 1, 9, 20, 0)
                };
                var p2 = new TimeTable()
                {
                    Description = "2st pair",
                    StartDateTime = new DateTime(2000, 1, 1, 9, 45, 0),
                    EndDateTime = new DateTime(2000, 1, 1, 11, 5, 0)
                };
                var p3 = new TimeTable()
                {
                    Description = "3st pair",
                    StartDateTime = new DateTime(2000, 1, 1, 11, 30, 0),
                    EndDateTime = new DateTime(2000, 1, 1, 12, 50, 0)
                };
                var p4 = new TimeTable()
                {
                    Description = "4st pair",
                    StartDateTime = new DateTime(2000, 1, 1, 13, 13, 0),
                    EndDateTime = new DateTime(2000, 1, 1, 14, 35, 0)
                };

                _context.TimeTables.AddRange(p1, p2, p3, p4);

                var s1 = new Schedule()
                {
                    GroupId = gr1.GroupId,
                    SubjectId = subj1.SubjectId,
                    TeacherId = t1.Teacher.TeacherId,
                    TimeTableId = p1.TimeTableId,
                    day = DayOfWeek.Monday
                    
                };
                var s2 = new Schedule()
                {
                    GroupId = gr1.GroupId,
                    SubjectId = subj2.SubjectId,
                    TeacherId = t3.Teacher.TeacherId,
                    TimeTableId = p2.TimeTableId,
                    day = DayOfWeek.Wednesday
                };
                var s3 = new Schedule()
                {
                    GroupId = gr2.GroupId,
                    SubjectId = subj1.SubjectId,
                    TeacherId = t1.Teacher.TeacherId,
                    TimeTableId = p2.TimeTableId,
                    day = DayOfWeek.Friday
                };
                var s4 = new Schedule()
                {
                    GroupId = gr2.GroupId,
                    SubjectId = subj4.SubjectId,
                    TeacherId = t5.Teacher.TeacherId,
                    TimeTableId = p3.TimeTableId,
                    day = DayOfWeek.Thursday
                };

                _context.Schedules.AddRange(s1, s2, s3, s4);

                var eve = new CalendarEvent()
                {
                    UserName = t1.UserName,
                    title = "newEvent!",
                    editable = true,
                    durationEditable = true,
                    startEditable = true,
                    start = new DateTime(2016, 5, 25, 8, 0, 0),
                    end = new DateTime(2016, 5, 25, 9, 45, 0)
                };

                var eve2 = new CalendarEvent()
                {
                    UserName = t1.UserName,
                    editable = true,
                    durationEditable = true,
                    startEditable = true,
                    title = "newEvent!",                    
                    start = new DateTime(2016, 5, 25, 10, 0, 0),
                    end = new DateTime(2016, 5, 25, 11, 20, 0)
                };
                _context.Events.AddRange(eve, eve2);

                _context.SaveChanges();
            }


            //    if(!_context.Dashboards.Any())
            //    {
            //        //Fill DB with dummy Data
            //        var Dash1 = new Dashboard()
            //        {
            //            Name = "dash_test_1",
            //            Created = DateTime.Now,
            //            UserName = "Teacher1",
            //            Tables = new List<Table>()
            //            {
            //                new Table() {
            //                    Name = "table1",
            //                    CreateDate = DateTime.Now,
            //                    Issues = new List<Issue>()
            //                    {
            //                        new Issue() {
            //                            Name = "issue1",
            //                            Description = "Description of issue1",
            //                            Comments = "Comments of issue1",
            //                            Created = DateTime.Now,
            //                        },
            //                        new Issue() {
            //                            Name = "issue2",
            //                            Description = "Description of issue2",
            //                            Comments = "Comments of issue2",
            //                            Created = DateTime.Now,
            //                        }
            //                    }
            //                    },
            //                new Table() {
            //                    Name = "table2",
            //                    CreateDate = DateTime.Now,
            //                    Issues = new List<Issue>()
            //                    {
            //                        new Issue() {
            //                            Name = "issue3",
            //                            Description = "Description of issue3",
            //                            Comments = "Comments of issue3",
            //                            Created = DateTime.Now,
            //                        },
            //                        new Issue() {
            //                            Name = "issue4",
            //                            Description = "Description of issue4",
            //                            Comments = "Comments of issue4",
            //                            Created = DateTime.Now,
            //                        }
            //                    }

            //                }
            //            }
            //        };
            //        var Dash2 = new Dashboard()
            //        {
            //            Name = "dash_test_2",
            //            Created = DateTime.Now,
            //            UserName = "Student1",
            //            Tables = new List<Table>()
            //            {
            //                new Table() {
            //                    Name = "table3",
            //                    CreateDate = DateTime.Now,
            //                    Issues = new List<Issue>()
            //                    {
            //                        new Issue() {
            //                            Name = "issue5",
            //                            Description = "Description of issue5",
            //                            Comments = "Comments of issue5",
            //                            Created = DateTime.Now,
            //                        },
            //                        new Issue() {
            //                            Name = "issue6",
            //                            Description = "Description of issue6",
            //                            Comments = "Comments of issue6",
            //                            Created = DateTime.Now,
            //                        }
            //                    }
            //                    },
            //                new Table() {
            //                    Name = "table4",
            //                    CreateDate = DateTime.Now,
            //                    Issues = new List<Issue>()
            //                    {
            //                        new Issue() {
            //                            Name = "issue7",
            //                            Description = "Description of issue7",
            //                            Comments = "Comments of issue7",
            //                            Created = DateTime.Now,
            //                        },
            //                        new Issue() {
            //                            Name = "issue8",
            //                            Description = "Description of issue8",
            //                            Comments = "Comments of issue8",
            //                            Created = DateTime.Now,
            //                        }
            //                    }

            //                }
            //            }
            //        };
            //foreach (var t in Dash1.Tables)
            //{
            //    t.DashboardId = Dash1.Id;
            //    foreach (var i in t.Issues)
            //        i.TableId = t.Id;
            //}
            //_context.Dashboards.Add(Dash1);
            //_context.Tables.AddRange(Dash1.Tables);
            //foreach (Table t in Dash1.Tables)
            //{
            //    _context.Issues.AddRange(t.Issues);
            //}
            //_context.SaveChanges();

            //        foreach (var t in Dash2.Tables)
            //        {
            //            t.DashboardId = Dash2.Id;
            //            foreach (var i in t.Issues)
            //                i.TableId = t.Id;
            //        }
            //        _context.Dashboards.Add(Dash2);
            //        _context.Tables.AddRange(Dash2.Tables);
            //        foreach (Table t in Dash2.Tables)
            //        {
            //            _context.Issues.AddRange(t.Issues);
            //        }
            //        _context.SaveChanges();
            //    }
        }

    }
}
