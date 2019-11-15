using System;
using System.Collections.Generic;
using SQLite;

namespace FeedbackApp_WebAPI.Models
{
    public class Evaluation
    {
        private int id;
        private string pin;
        private string turma;
        private string ies;
        private string curso;
        private List<Question> pergunta;
        private decimal percentual;
        private string name;

        [PrimaryKey]
        public int Id { get => id; set => id = value; }
        public string PIN { get => pin; set => pin = value; }
        public string Turma { get => turma; set => turma = value; }
        public string Ies { get => ies; set => ies = value; }
        public string Curso { get => curso; set => curso = value; }
        public List<Question> Perguntas { get => pergunta; set => pergunta = value; }
        public decimal Percentual { get => percentual; set => percentual = value; }
        public string Name { get => name; set => name = value; }

        private DateTime DataHoraPIN { get; set; }

        public Evaluation(EvaluationDB evaluation)
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

        public Evaluation(int id, string pin, string turma, string ies, string curso, List<Question> pergunta, decimal percentual, string name)
        {
            Id = id;
            PIN = pin;
            Turma = turma;
            Ies = ies;
            Curso = curso;
            Perguntas = pergunta;
            Percentual = percentual;
            DataHoraPIN = DateTime.Now;
            Name = name;
        }

        public Evaluation() : this(0, "", "", "", "", null, 0, "")
        {
        }
    }
}