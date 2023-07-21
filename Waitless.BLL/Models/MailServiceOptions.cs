namespace Waitless.BLL.Models
{
    public class MailServiceOptions
    {
        public string SMTP { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public bool SSL { get; set; }
    }
}
