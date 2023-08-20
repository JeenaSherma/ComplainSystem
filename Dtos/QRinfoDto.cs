using ComplaintSystem.Model;

namespace ComplaintSystem.Dtos
{
    public class QRinfoDto
    {
        public int Id { get; set; }
        public string? QRImagePath { get; set; }
       // public IFormFile QRImage { get; set; }
        //public string? Municipalityname { get; set; }
        public int MunicipalityId { get; set; }
        public string QRCodeText { get; set; }
        public virtual Municipality? Municipality { get; set; }
    }
}
