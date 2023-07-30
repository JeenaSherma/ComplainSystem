using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class ComplainerInfo
    {
        public int Id { get; set; }
        public string ComplainerEmail { get; set; }

        [ForeignKey("Complain")]
        public int ComplainId { get; set; }
        public virtual Complain Complain { get; set; }
    }
}
