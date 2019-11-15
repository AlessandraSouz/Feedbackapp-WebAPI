using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FeedbackApp_WebAPI.Models;
using SQLite;

namespace FeedbackApp_WebAPI.DBAccess
{
    public class SQLiteFunctions
    {
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sqliteDb.db3");
        private static SQLiteConnection Connection { get; set; }

        static SQLiteFunctions()
        {
            CreateTables();
        }

        private static void CreateTables()
        {
            if (!File.Exists(dbPath)) { var stream = File.Create(dbPath); stream.Dispose(); }

            Connection = new SQLiteConnection(dbPath);
            Connection.CreateTable<EvaluationDB>(CreateFlags.AutoIncPK);
            Connection.CreateTable<Question>(CreateFlags.AutoIncPK);
        }

        public static Evaluation SelectEvaluation(string pin)
        {
            var resultDb = Connection.Table<EvaluationDB>().ToList().Where(p => p.PIN == pin).FirstOrDefault();
            if (resultDb != null)
            {
                var result = new Evaluation(resultDb);
                result.Perguntas = Connection.Table<Question>().ToList().Where(p => p.PIN == pin).ToList();
                return result;
            }
            else
            {
                throw new Exception("Nenhuma avaliação com o PIN especificado!");
            }
        }

        public static List<Evaluation> SelectAllEvaluations()
        {
            var resultDb = Connection.Table<EvaluationDB>().ToList();
            if (resultDb != null)
            {
                var result = new List<Evaluation>();
                resultDb.ForEach(p => result.Add(new Evaluation(p)));
                result.ForEach(p => p.Perguntas = Connection.Table<Question>().ToList().Where(q => q.PIN == p.PIN).ToList());
                return result;
            }
            else
            {
                throw new Exception("Nenhuma avaliação!");
            }
        }

        public static int InsertEvaluation(Evaluation evaluation)
        {
            var evaluationDb = new EvaluationDB(evaluation);
            var questions = evaluation.Perguntas;
            questions.ForEach(p => p.PIN = evaluation.PIN);
            Connection.InsertAll(questions);
            return Connection.Insert(evaluationDb);
        }

        public static int UpdateEvaluation(Evaluation evaluation)
        {
            var evaluationDb = new EvaluationDB(evaluation);
            Connection.UpdateAll(evaluation.Perguntas);
            evaluationDb.Percentual = CalcularPercentual(evaluation.Perguntas);
            return Connection.Update(evaluationDb);
        }

        public static decimal CalcularPercentual(List<Question> questions)
        {
            var soma = 0;
            var qtde = questions.Count;

            questions.ForEach(p => soma += ConverterFeedback(p.Feedback));
            return soma / qtde;
        }

        public static int ConverterFeedback(string feedback)
        {
            return feedback switch
            {
                "Ruim" => 25,
                "Regular" => 50,
                "Bom" => 75,
                "Excelente" => 100,
                _ => 0,
            };
        }
    }
}