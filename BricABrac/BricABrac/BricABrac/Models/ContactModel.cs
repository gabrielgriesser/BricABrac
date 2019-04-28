using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models
{
    /// <summary>
    /// Class represents a contact.
    /// Contact is sent from the /Contact page
    /// </summary>
    public class ContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
