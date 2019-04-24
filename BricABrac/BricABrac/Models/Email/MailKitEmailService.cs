using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;

namespace BricABrac.Models.Email
{
    public class MailKitEmailService : IEmailService
    {
        private readonly EmailServerConfiguration _emailConfig;

        public MailKitEmailService(EmailServerConfiguration emailConfig)
        {
            this._emailConfig = emailConfig;
        }

        public void Send(EmailMessage msg)
        {
            var message = new MimeMessage();

            message.To.AddRange(msg.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(msg.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = msg.Subject;

            message.Body = new TextPart("plain")
            {
                Text = msg.Content
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.SmtpPort);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);

                Debug.Print("AUTHENTICATION OK");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
