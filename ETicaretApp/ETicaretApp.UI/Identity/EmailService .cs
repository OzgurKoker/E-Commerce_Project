using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ETicaretApp.UI.Identity
{
    public class EmailService : IEmailSender
    {
        private readonly EmailSenderOptions _emailOptions;

        public EmailService(IOptions<EmailSenderOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }

    public class EmailSenderOptions
    {
        public string SendGridApiKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }
}
