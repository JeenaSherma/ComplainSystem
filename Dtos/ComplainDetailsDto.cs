using ComplaintSystem.Model;
using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.Dtos
{
    public class ComplainDetailsDto
    {
        public int Id { get; set; }       
        public string ComplainText { get; set; }
        public CategoryDto? Category { get; set; }
        public ComplainStatusDto? complainStatus { get; set; }
        public ComplainerInfoDto? complainerInfo { get; set; }
    }
}
