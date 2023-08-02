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
        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Complain")]
        public int ComplainId { get; set; }
        public virtual Complain Complain { get; set; }
    }
}
