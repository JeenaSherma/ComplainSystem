namespace ComplaintSystem.Model
{
    public class Question
    {
        public int Id { get; set; }
        public  string QuestionText { get; set; }
        public List<Question> Questions { get; set;}


    }
}
