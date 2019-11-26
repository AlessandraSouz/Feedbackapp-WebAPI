using SQLite;

namespace FeedbackApp_WebAPI.Models
{
    public class QuestionDB
    {
        private int id;
        private string pergunta;
        private decimal badPercent;
        private decimal regularPercent;
        private decimal goodPercent;
        private decimal excellentPercent;
        private string pin;
        private string nomeAluno;

        [PrimaryKey]
        public int Id { get => id; set => id = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public string PIN { get => pin; set => pin = value; }
        public string NomeAluno { get => nomeAluno; set => nomeAluno = value; }

        public decimal BadPercent { get => badPercent; set => badPercent = value; }
        public decimal RegularPercent { get => regularPercent; set => regularPercent = value; }
        public decimal GoodPercent { get => goodPercent; set => goodPercent = value; }
        public decimal ExcellentPercent { get => excellentPercent; set => excellentPercent = value; }

        public QuestionDB(int id, string pergunta, string pin, string nomeAluno)
        {
            Id = id;
            Pergunta = pergunta;
            PIN = pin;
            NomeAluno = nomeAluno;
        }

        public QuestionDB(Question question)
        {
            Id = question.Id;
            Pergunta = question.Pergunta;
            PIN = question.PIN;
            NomeAluno = nomeAluno;

            BadPercent = question.BadPercent;
            RegularPercent = question.RegularPercent;
            GoodPercent = question.GoodPercent;
            ExcellentPercent = question.ExcellentPercent;
        }

        public QuestionDB() : this(0, "", "", "")
        {
        }
    }
}