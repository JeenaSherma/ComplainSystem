using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Options
    {
        public int Id { get; set; }
        public string OptionsName { get; set; }
        [ForeignKey("Questions")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }  

    }
}
