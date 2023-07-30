using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class QRinfo
    {
        public int Id { get; set; }
        public string QRImagePath { get; set; }

        [ForeignKey("Municipality")]
        public int MunicipalityId { get; set; }
        public virtual Municipality  Municipality { get; set; }
     
    }
}
