using System;
using SQLite;

namespace FeedbackApp_WebAPI.Models
{
    public class EvaluationDB
    {
        private int id;
        private string pin;
        private string turma;
        private string ies;
        private string curso;
        private decimal percentual;
        private string name;

        [PrimaryKey]
        public int Id { get => id; set => id = value; }
        public string PIN { get => pin; set => pin = value; }
        public string Turma { get => turma; set => turma = value; }
        public string Ies { get => ies; set => ies = value; }
        public string Curso { get => curso; set => curso = value; }
        public decimal Percentual { get => percentual; set => percentual = value; }
        public string Name { get => name; set => name = value; }

        private DateTime DataHoraPIN { get; set; }

        public EvaluationDB(Evaluation evaluation)
        {
            Id = evaluation.Id;
            PIN = evaluation.PIN;
            Turma = evaluation.Turma;
            Ies = evaluation.Ies;
            Curso = evaluation.Curso;
            Percentual = evaluation.Percentual;
            DataHoraPIN = DateTime.Now;
            Name = evaluation.Name;
        }

        public EvaluationDB(int id, string pin, string turma, string ies, string curso, decimal percentual, string name)
        {
            Id = id;
            PIN = pin;
            Turma = turma;
            Ies = ies;
            Curso = curso;
            Percentual = percentual;
            DataHoraPIN = DateTime.Now;
            Name = name;
        }

        public EvaluationDB() : this(0, "", "", "", "", 0, "")
        {
        }
    }
}