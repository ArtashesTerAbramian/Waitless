using System.Threading.Tasks;

namespace Waitless.BLL.Services.MailService
{
    public interface IMailService
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}