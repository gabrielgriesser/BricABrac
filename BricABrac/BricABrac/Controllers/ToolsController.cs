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
            StudentGradeModel sgm = new StudentGradeModel
            {
                Modules = Db.Modules.ToList(),
                Subjects = Db.Subjects.ToList(),
                Grades = Db.Grades.ToList()
            };

            return View(sgm);
        }

        public IActionResult CreateModule(ModuleModel model)
        {
            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    model.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Db.Modules.Add(model);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }
            return View(model);
        }

        public IActionResult EditModule(int Id)
        {
            var model = Db.Modules.Where(s => s.Id == Id).FirstOrDefault();
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
            SubjectModuleViewModel smvm = new SubjectModuleViewModel();
            smvm.ModuleList = Db.Modules.ToList();

            if (Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    Db.Subjects.Add(model.Subject);
                    Db.SaveChanges();
                    return RedirectToAction("Grade");
                }
            }
            return View(smvm);
        }

        public IActionResult AddGrade()
        {
            return View();
        }

        public IActionResult PdfReader()
        {
            return View();
        }
    }
}