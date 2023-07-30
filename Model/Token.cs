using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Token
    {
        public int Id { get; set; }
        public string TokenValue { get; set; }

        [ForeignKey("Complain")]
        public int ComplainId { get; set; }
        public virtual Complain Complain { get; set; }
    }
}
