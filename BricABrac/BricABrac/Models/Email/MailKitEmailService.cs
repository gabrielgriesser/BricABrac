using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;

namespace BricABrac.Models.Email
{
    /// <summary>
    /// Email service use a NuGet package called MailKit
    /// This class represents a MailKit Service.
    /// It implements "send" method from IEmailService.
    /// </summary>
    public class MailKitEmailService : IEmailService
    {

        private readonly EmailServerConfiguration _emailConfig;

        /// <summary>
        /// Constructor who needs an EmailServerConfiguration to work.
        /// </summary>
        /// <param name="emailConfig"></param>
        public MailKitEmailService(EmailServerConfiguration emailConfig)
        {
            this._emailConfig = emailConfig;
        }

        /// <summary>
        /// Send function
        /// Used to send a message who has a EmailMessage form.
        /// </summary>
        /// <param name="msg"></param>
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
