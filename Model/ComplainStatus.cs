using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class ComplainStatus
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
    }
    public enum StatusEnum
    {
        Completed,
        Halted,
        Pending
    }
}
