namespace ComplaintSystem.Model
{
    public class Municipality
    {
        public int Id { get; set; }
        public string MunicipalityName { get; set; }
        public virtual QRinfo QRinfo { get; set; }
       
    }
}
