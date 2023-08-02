using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Complain
    {
        public int Id { get; set; }

        public string ComplainText { get; set; }     
        public virtual ComplainerInfo ComplainerInfo { get; set; }
        public virtual Token Token { get; set; }

        [ForeignKey("ComplainStatus")]
        public int ComplainStatusId { get; set; }
        public virtual ComplainStatus ComplainStatus { get; set; }

         [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }         
    }
}
