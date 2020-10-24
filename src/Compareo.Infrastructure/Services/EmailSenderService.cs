using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Compareo.Infrastructure.Common.Options;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
{
    public class EmailSenderService : IEmailSender
    {

        private readonly SmtpClient _smtpClient;
        private  EmailSettings EmailOptions { get; set; }
        public EmailSenderService(SmtpClient smtpClient,IOptions<EmailSettings>emailOptions)
        {
            _smtpClient = smtpClient;
            EmailOptions = emailOptions.Value;
        }
        public async Task SendEmailAsync(string destinyEmail, string title, string body)
        {
            var from = new MailAddress(EmailOptions.Username, "Support Products Evaluation");

            var to = new MailAddress(destinyEmail);

            var message = new MailMessage(from, to)
            {
                Body = body,
                Subject = title,
                IsBodyHtml = true
            };

            await _smtpClient.SendMailAsync(message);
            message.Dispose();
        }

    }
}
