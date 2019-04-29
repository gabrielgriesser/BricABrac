using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BricABrac.Models;
using BricABrac.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BricABrac.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ApplicationDbContext Db;

        public ToolsController(ApplicationDbContext Db)
        {
            this.Db = Db;
        }

        public IActionResult Todo()
        {
            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = Db.Todos.Where(m => m.UserIdTodo == userid).ToList();

            //ViewData["MyData"] = model;
            return View(model);
        }

        public IActionResult CreateTodo(TodoModel model)
        {
            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.UserIdTodo = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Db.Todos.Add(model);
                    Db.SaveChanges();
                    return RedirectToAction("Todo");
                }
            }
            return View(model);
        }

        public IActionResult EditTodo(int Id)
        {
            var model = Db.Todos
                        .Where(m => m.Id == Id)
                        .Where(m => m.UserIdTodo == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                        .FirstOrDefault();

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.Todo = Request.Form["Todo"];
                    Db.Todos.Update(model);
                    Db.SaveChanges();
                    return RedirectToAction("Todo");
                }
            }
            return View(model);
        }

        public IActionResult DeleteTodo()
        {
            if (Request.Method == "POST")
            {
                Db.Todos.Remove(Db.Todos.Find(Int32.Parse(Request.Form["Id"])));
                Db.SaveChanges();
                return RedirectToAction("Todo");
            }
            return RedirectToAction("Todo");
        }

        public ActionResult EditMode()
        {
            if(HttpContext.Session.GetInt32("editMode") == 1)
            {
                HttpContext.Session.SetInt32("editMode", 0);
            }
            else
            {
                HttpContext.Session.SetInt32("editMode", 1);
            }

            return this.RedirectToAction("Grade");
        }

        public IActionResult Grade()
        {
            
            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            StudentGradeModel sgm = new StudentGradeModel
            {
                Modules = Db.Modules.Where(m => m.UserIdModule == userid).ToList(),
                Subjects = Db.Subjects.Where(s => s.UserIdSubject == userid).ToList(),
                Grades = Db.Grades.Where(g => g.UserIdGrade == userid).ToList()
            };

            ViewBag.EditMode = HttpContext.Session.GetInt32("editMode");

            return View(sgm);
        }

        public IActionResult CreateModule(ModuleModel model)
        {
            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.UserIdModule = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Db.Modules.Add(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }
            return View(model);
        }

        public IActionResult EditModule(int Id)
        {
            var model = Db.Modules
                .Where(m => m.Id == Id)
                .Where(m => m.UserIdModule == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .FirstOrDefault();

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.Name = Request.Form["Name"];
                    model.SchoolYear = Int32.Parse(Request.Form["SchoolYear"]);
                    Db.Modules.Update(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }
            return View(model);
        }

        public IActionResult DeleteModule()
        {
            if (Request.Method == "POST")
            {
                Db.Modules.Remove(Db.Modules.Find(Int32.Parse(Request.Form["Id"])));
                Db.SaveChanges();
                return RedirectToAction("Grade");
            }
            return RedirectToAction("Grade");
        }

        public IActionResult CreateSubject(SubjectModuleViewModel model)
        {
            SubjectModuleViewModel smvm = new SubjectModuleViewModel
            {
                ModuleList = Db.Modules
                .Where(s => s.UserIdModule == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToList()
            };

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.Subject.UserIdSubject = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Db.Subjects.Add(model.Subject);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }
            return View(smvm);
        }

        public IActionResult EditSubject(int Id)
        {
            SubjectModuleViewModel smvm = new SubjectModuleViewModel
            {
                ModuleList = Db.Modules
                .Where(m => m.UserIdModule == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToList(),

                Subject = Db.Subjects
                .Where(s => s.Id == Id)
                .Where(s => s.UserIdSubject == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .FirstOrDefault()
            };

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    var model = Db.Subjects.Where(s => s.Id == Id).FirstOrDefault();

                    model.Name = Request.Form["Subject.Name"];
                    model.Coefficient = Decimal.Parse(Request.Form["Subject.Coefficient"]);
                    model.Moduleid = Int32.Parse(Request.Form["Subject.Module.Id"]);

                    Db.Subjects.Update(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }

            return View(smvm);
        }

        public IActionResult DeleteSubject()
        {
            if (Request.Method == "POST")
            {
                Db.Subjects.Remove(Db.Subjects.Find(Int32.Parse(Request.Form["Subject.Id"])));
                Db.SaveChanges();
                return RedirectToAction("Grade");
            }
            return RedirectToAction("Grade");
        }

        public IActionResult CreateGrade(GradeSubjectViewModel model)
        {
            GradeSubjectViewModel gsvm = new GradeSubjectViewModel
            {
                SubjectList = Db.Subjects
                .Where(s => s.UserIdSubject == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToList()
            };

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.Grade.UserIdGrade = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Db.Grades.Add(model.Grade);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }
            return View(gsvm);
        }

        public IActionResult EditGrade(int Id)
        {
            GradeSubjectViewModel gsvm = new GradeSubjectViewModel
            {
                SubjectList = Db.Subjects
                .Where(s => s.UserIdSubject == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToList(),

                Grade = Db.Grades
                .Where(s => s.Id == Id)
                .Where(g => g.UserIdGrade == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .FirstOrDefault()
            };

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    var model = Db.Grades.Where(s => s.Id == Id).FirstOrDefault();

                    model.Grade = Decimal.Parse(Request.Form["Grade.Grade"]);
                    model.Coefficient = Decimal.Parse(Request.Form["Grade.Coefficient"]);

                    if(Request.Form["Grade.IsExam"] == "false")
                    { model.IsExam = Convert.ToBoolean("False");  }
                    else { model.IsExam = Convert.ToBoolean("True"); }

                    model.Subjectid = Int32.Parse(Request.Form["Grade.Subject.Id"]);

                    Db.Grades.Update(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }

            return View(gsvm);
        }

        public IActionResult DeleteGrade()
        {
            if (Request.Method == "POST")
            {
                Db.Grades.Remove(Db.Grades.Find(Int32.Parse(Request.Form["Grade.Id"])));
                Db.SaveChanges();
                return RedirectToAction("Grade");
            }
            return RedirectToAction("Grade");
        }

        public IActionResult PdfReader()
        {
            return View();
        }
    }
}