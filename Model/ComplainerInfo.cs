using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class ComplainerInfo
    {
        public int Id { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Name { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be a 10-digit number.")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        

        [ForeignKey("Complain")]
        public int ComplainId { get; set; }
        //public virtual Complain Complain { get; set; }
    }
}
