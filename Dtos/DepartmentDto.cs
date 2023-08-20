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
        public MunicipalityDto? municipality { get; set; }
        //public int BranchId { get; set; }
        //public BranchDto? branch { get; set; }

    }
}
