using ComplaintSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } 
        public int DepartmentId { get; set; }
        public virtual DepartmentDto? Department { get; set; }
        
    }
}
