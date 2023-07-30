namespace ComplaintSystem.Dtos
{
    public class ComplainerInfoDto
    {
        public int Id { get; set; }
        public string ComplainerEmail { get; set; }
        public int ComplainId { get; set; }
        public string? ComplainText { get; set; }
    }
}
