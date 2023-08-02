﻿using System.ComponentModel.DataAnnotations;

namespace ComplaintSystem.Dtos
{
    public class ComplainerInfoDto
    {
        public int Id { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? Name { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int ComplainId { get; set; }
        public string? ComplainText { get; set; }
    }
}
