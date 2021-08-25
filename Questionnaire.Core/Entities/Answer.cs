namespace Questionnaire.Core.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public decimal Score { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}