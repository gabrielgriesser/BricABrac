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

        #region attribute
        private List<EmailAddress> DevelopersEmailAddress;
        private List<EmailAddress> CustomerEmailAddress;
        private IEmailService EmailService;
        #endregion

        public HomeController(IEmailService _emailService)
        {
            DevelopersEmailAddress = new List<EmailAddress>();
            CustomerEmailAddress = new List<EmailAddress>();

            DevelopersEmailAddress.Add(new EmailAddress
            {
                Name = "Gabriel Griesser",
                Address = "gabriel.griesser@he-arc.ch"
            });

            DevelopersEmailAddress.Add(new EmailAddress
            {
                Name = "Julien Feuillade",
                Address = "julien.feuillade@he-arc.ch"
            });

            DevelopersEmailAddress.Add(new EmailAddress
            {
                Name = "Jeremy Dubois",
                Address = "jeremy.dubois@he-arc.ch"
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

        /// <summary>
        /// Contact page with GET request
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Contact page with POST request
        /// Used to send mail
        /// </summary>
        /// <param name="model">ContactModel</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            IdRequest.Id = IdRequest.Id + 1;
            if (ModelState.IsValid)
            {
                CustomerEmailAddress.Add(new EmailAddress
                {
                    Name = model.Name,
                    Address = model.Email

                });

                // Email sent to the client to confirm his request.
                EmailMessage emailConfirmationToCustomer = new EmailMessage
                {
                    FromAddresses = DevelopersEmailAddress,

                    ToAddresses = CustomerEmailAddress,
                    Content = $"Your request has been sent, thank you for contacting us. We will answer you as soon as possible. " +
                        $"\n \nHERE is your message : " +
                        $"\nName : {model.Name} " +
                        $"\nEmail: {model.Email} " +
                        $"\nSubjet :  {model.Subject} " +
                        $"\nMessage: {model.Message} ",
                    Subject = $"[BricABrac Support] Auto response to request #" + IdRequest.Id.ToString()
                };

                EmailService.Send(emailConfirmationToCustomer);

                // Email sent to developers regarding the client's request
                EmailMessage emailConfirmationToDevelopers = new EmailMessage
                {
                    FromAddresses = DevelopersEmailAddress,

                    ToAddresses = DevelopersEmailAddress,
                    Content = $"A customer has sent you a request. Here it is : " +
                        $"\nID Request : #" + IdRequest.Id.ToString() +
                        $"\nName : {model.Name} " +
                        $"\nEmail: {model.Email} " +
                        $"\nSubjet :  {model.Subject} " +
                        $"\nMessage: {model.Message} ",
                    Subject = $"[BricABrac Support] REQUEST #" + IdRequest.Id.ToString() + " FROM CUSTOMER"
                };

                EmailService.Send(emailConfirmationToDevelopers);

                return RedirectToAction("Contact");
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
