using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BricABrac.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Todo()
        {
            return View();
        }

        public IActionResult Notes()
        {
            return View();
        }

        public IActionResult PdfReader()
        {
            return View();
        }
    }
}