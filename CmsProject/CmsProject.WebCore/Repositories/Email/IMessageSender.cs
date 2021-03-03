using System.Threading.Tasks;

namespace CmsProject.WebCore.Repositories.Email
{
    public interface IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}