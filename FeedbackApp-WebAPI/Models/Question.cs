﻿using System.Collections.Generic;
using SQLite;

namespace FeedbackApp_WebAPI.Models
{
    public class Question
    {
        private int id;
        private string pergunta;
        private List<string> feedbacks;
        private decimal badPercent;
        private decimal regularPercent;
        private decimal goodPercent;
        private decimal excellentPercent;
        private string pin;

        [PrimaryKey]
        public int Id { get => id; set => id = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public List<string> Feedbacks { get => feedbacks; set => feedbacks = value; }
        public string PIN { get => pin; set => pin = value; }

        public decimal BadPercent { get => badPercent; set => badPercent = value; }
        public decimal RegularPercent { get => regularPercent; set => regularPercent = value; }
        public decimal GoodPercent { get => goodPercent; set => goodPercent = value; }
        public decimal ExcellentPercent { get => excellentPercent; set => excellentPercent = value; }

        public Question(int id, string pergunta, List<string> feedbacks, string pin)
        {
            Id = id;
            Pergunta = pergunta;
            Feedbacks = feedbacks;
            PIN = pin;
        }

        public Question(QuestionDB question)
        {
            Id = question.Id;
            Pergunta = question.Pergunta;
            PIN = question.PIN;

            BadPercent = question.BadPercent;
            RegularPercent = question.RegularPercent;
            GoodPercent = question.GoodPercent;
            ExcellentPercent = question.ExcellentPercent;
        }

        public Question() : this(0, "", null, "")
        {
        }
    }
}