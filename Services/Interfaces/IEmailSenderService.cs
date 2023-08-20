using System.Net.Mail;

namespace ComplaintSystem.Services.Interfaces
{
    public interface IEmailSenderService
    {
        public Task<bool> SendEmail(string receiverEmail, string userName, string message);
       
    }
}
