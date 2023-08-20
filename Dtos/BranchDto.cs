using ComplaintSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Dtos
{
    public class BranchDto
    {
        public int Id { get; set; }
        public int? WardNumber { get; set; }
        public string? WardName { get; set; }
        public int MunicipalityId { get; set; }
    }
}
