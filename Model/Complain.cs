using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Complain
    {
        public int Id { get; set; }
        public string ComplainText { get; set; }
        public virtual ComplainerInfo ComplainerInfo { get; set; }
        public virtual Token Token { get; set; }
      
    }
}
