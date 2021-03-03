using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CmsProject.WebCore.Repositories.Email
{
    public class MessageSender : IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            /*
             * تنظیمات فعال سازی حساب گوگل برای ارسال ایمیل
             * http://www.digcode.com/posts/t13906/Solved-Failed-to-send-email-through-Gmail-The-SMTP-server-requires-a-secure-connection-or-the-client-was-not-authenticated-The-server-response-was-5-7-0-Authentication-Required
             */

            using (var client = new SmtpClient())
            {
                var credentials = new NetworkCredential()
                {
                    UserName = "SystemJameh", // without @gmail.com
                    Password = "SystemJameh147852@"
                };

                client.Credentials = credentials;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                using var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toEmail) },
                    From = new MailAddress("SystemJameh@gmail.com"), // with @gmail.com
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml,
                    Priority = MailPriority.High
                };

                client.Send(emailMessage);
            }

            return Task.CompletedTask;
        }
    }
}