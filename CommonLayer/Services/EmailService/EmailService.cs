using System;
using System.Net;
using System.Net.Mail;
using static CommonLayer.Constants;

namespace CommonLayer.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public bool SendEmailWithoutTemplate(string to, string subject, string body, bool isBodyHtml = false)
        {
            var smtp = new SmtpClient
            {
                Host = EmailConfiguration.Host,
                Port = Convert.ToInt32(EmailConfiguration.Port),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailConfiguration.Email, EmailConfiguration.Password),
                Timeout = 10000
            };
            using (var message = new MailMessage(EmailConfiguration.Email, to)
            {
                IsBodyHtml = isBodyHtml,
                Subject = subject,
                Body = body,
            })
            {
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch (SmtpException e)
                {
                    string er = e.Message;
                }
            }

            return false;
        }
    }
}
