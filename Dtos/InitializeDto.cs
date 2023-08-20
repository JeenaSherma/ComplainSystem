using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.Dtos
{
    public class InitializeDto
    {
        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        public int NumberOfWards { get; set; }
        public string? Address { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? OfficialWebsite { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be a 10-digit number.")]
        public string? PhoneNumber { get; set; }

    }
}
 