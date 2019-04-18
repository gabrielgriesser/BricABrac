using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BricABrac.Models;
using BricABrac.Data;

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
            StudentGradeModel sgm = new StudentGradeModel();
            sgm.Modules = Db.Modules.ToList();
            sgm.Subjects = Db.Subjects.ToList();
            sgm.Grades = Db.Grades.ToList();

            return View(sgm);
        }

        public IActionResult CreateModule()
        {
            return View();
        }

        public IActionResult EditModule(int Id)
        {
            var module = Db.Modules.Where(s => s.Id == Id).FirstOrDefault();
            return View(module);
        }

        [HttpPost]
        public ActionResult CreateEditModule(ModuleModel model)
        {
            if (ModelState.IsValid)
            {
                // No id so we add it to database
                if (model.Id <= 0)
                {
                    Db.Modules.Add(model);
                }
                // Has Id, therefore it's in database so we update
                else
                {
                    Db.Entry(model).State = EntityState.Modified;
                }
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult AddSubject()
        {
            return View();
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