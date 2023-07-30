using ComplaintSystem.Model;

namespace ComplaintSystem.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentNumber { get; set; }
        public string DepartmentEmail { get; set; }
        public int MunicipalityId { get; set; }
        public string? MunicipalityName {get; set;}
        public List<Category>? Categories { get; set; }
    }
}
