using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BricABrac.Models;
using BricABrac.Models.Email;

namespace BricABrac.Controllers
{
    public class HomeController : Controller
    {
        private List<EmailAddress> ToEmailAddress;
        private List<EmailAddress> FromEmailAddress;
        private IEmailService EmailService;

        public HomeController(IEmailService _emailService)
        {
            ToEmailAddress = new List<EmailAddress>();
            FromEmailAddress = new List<EmailAddress>();

            ToEmailAddress.Add(new EmailAddress
            {
                Name = "Gabriel Griesser",
                Address = "gabriel.griesser@he-arc.com"

            });

            ToEmailAddress.Add(new EmailAddress
            {
               
                Name = "Julien Feuillade",
                 Address = "julien.feuillade@he-arc.ch"
            });


            EmailService = _emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                FromEmailAddress.Add(new EmailAddress
                {
                    Name = model.Name,
                    Address = model.Email

                });
                EmailMessage msgToSend = new EmailMessage
                {
                    // AJOUTER CONFIRMATION !!
                    FromAddresses = ToEmailAddress,

                    ToAddresses = FromEmailAddress,
                    Content = $"Here is your message: Name: {model.Name}, " +
                        $"Email: {model.Email}, Message: {model.Message}",
                    Subject = $"Subject: {model.Subject}"
                };

                EmailService.Send(msgToSend);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
