using SendGrid.Helpers.Mail;
using SendGrid;
using WebAppMerck.Servicios.Interfaces;

namespace WebAppMerck.Servicios
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {

            _configuration = configuration; 

        }
        public async Task EnviarEmailAsync(string to, string subject, string body, string message)
        {
            var apiKey = _configuration["SendGridSettings:ApiKeySendGrid"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_configuration["Email:FromAddress"], _configuration["Email:FromName"]);
            var toAddress = new EmailAddress(to);
            var plainTextContent = body;
            var htmlContent = body;

            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
