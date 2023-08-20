using ComplaintSystem.Model;
using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.Dtos
{
    public class ComplainAndComplainInfoDto
    {
        public int Id { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string ComplainText { get; set; }
        //public string? TokenValue { get; set; }
        public string ? ComplainStatuss { get; set; }
        public int? ComplainStatusId { get; set; }
        public int? CategoryId { get; set; }
        public TokenDto? Token { get; set; }
        public ComplainStatusDto? complainStatus { get; set; }
        public ComplainerInfoDto? complainerInfo { get; set; }
    }
}
