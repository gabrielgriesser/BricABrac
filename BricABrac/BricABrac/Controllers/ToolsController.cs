using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BricABrac.Models;
using BricABrac.Data;
using System.Net.Http;
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
            
            return View();
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
                    model.Gradeexam = Decimal.Parse(Request.Form["Subject.Gradeexam"]);
                    model.Coefficientexam = Decimal.Parse(Request.Form["Subject.Coefficientexam"]);
                    model.Moduleid = Int32.Parse(Request.Form["Subject.Module.Id"]);

                    Db.Subjects.Update(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }

            return View(smvm);
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
                    model.Subjectid = Int32.Parse(Request.Form["Grade.Subject.Id"]);

                    Db.Grades.Update(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }

            return View(gsvm);
        }

        public IActionResult PdfReader()
        {
            return View();
        }
    }
}