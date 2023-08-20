using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Ward
    {
        public int Id {  get; set; }
        public string WardNameInEnglish { get; set; }
        public string WardNameInNepali { get; set; }
       
        [ForeignKey("Municipality")]
        public int MunicipalityId { get; set; }
        public virtual Municipality Municipality { get; set; }
       
    }
}
