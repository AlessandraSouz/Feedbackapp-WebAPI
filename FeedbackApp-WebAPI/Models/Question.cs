using SQLite;

namespace FeedbackApp_WebAPI.Models
{
    public class Question
    {
        private int id;
        private string pergunta;
        private string feedback;
        private string pin;

        [PrimaryKey]
        public int Id { get => id; set => id = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public string Feedback { get => feedback; set => feedback = value; }
        public string PIN { get => pin; set => pin = value; }

        public Question(int id, string pergunta, string feedback, string pin)
        {
            Id = id;
            Pergunta = pergunta;
            Feedback = feedback;
            PIN = pin;
        }

        public Question() : this(0, "", "", "")
        {
        }
    }
}