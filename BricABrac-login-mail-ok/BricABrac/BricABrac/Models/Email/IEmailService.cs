using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models.Email
{
    /// <summary>
    /// Simple interface to use when we work with email
    /// </summary>
    public interface IEmailService
    {
        void Send(EmailMessage message);
    }
}
