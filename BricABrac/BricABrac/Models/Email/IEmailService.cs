using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BricABrac.Models.Email
{
    public interface IEmailService
    {
        void Send(EmailMessage message);
    }
}
