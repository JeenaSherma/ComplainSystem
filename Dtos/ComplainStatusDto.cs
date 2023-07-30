namespace ComplaintSystem.Dtos
{
    public class ComplainStatusDto
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
    }
    public enum StatusEnum
    {
        Completed,
        Halted,
        Pending
    }
}

