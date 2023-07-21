using System.Threading.Tasks;

namespace Waitless.BLL.Services.MailService
{
    public interface IMailSenderService
    {
        Task SendEmails();
    }
}