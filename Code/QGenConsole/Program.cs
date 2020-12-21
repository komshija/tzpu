using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace QGenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dataAccess = DataAccess.DataAccess.GetInstance();
            var questions = dataAccess.GetAllQuestions();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================= SVA PITANJA  =================");
            Console.WriteLine();
            Console.WriteLine();
            foreach (var question in questions)
                Console.WriteLine(question.ToString());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================= PITANJA SA UKUPNOM TEZINOM 3 +- 0.1 =================");
            Console.WriteLine();
            Console.WriteLine();
            questions = dataAccess.GetQuestionsByOverallDifficulty(3, 0.1);
            foreach (var question in questions)
                Console.WriteLine(question.ToString());

        }
    }
}
