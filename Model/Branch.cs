using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.Model
{
    public class Branch
    {
        public int Id { get; set; }
        public string? BranchNameInEnglish { get; set; }
        public string? BranchNameInNepali { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? OfficialWebsite { get; set; }
        public virtual BranchType? BranchType { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public virtual Municipality? Municipality { get; set; }
        public virtual RuralMunicipality? RuralMunicipality { get; set; }
        public int WardNo { get; set; }



    }
}
