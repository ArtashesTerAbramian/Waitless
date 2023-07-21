
namespace Waitless.DAL.Models;

public class MailTemplate : BaseEntity
{
    public string HtmlBody { get; set; }
    public string Subject { get; set; }
}
