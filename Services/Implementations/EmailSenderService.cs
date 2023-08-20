using ComplaintSystem.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace ComplaintSystem.Services.Implementations
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task<bool> SendEmail(string receiverEmail, string userName, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("geenaijam@gmail.com", "Complain sys");
            var subject = "Complain Status";
            var to = new EmailAddress(receiverEmail, userName);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
}
    }