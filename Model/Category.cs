using System.ComponentModel.DataAnnotations.Schema;

namespace ComplaintSystem.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
