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
          //  foreach (var question in questions)
           //     Console.WriteLine(question.ToString());

            var gen = new Logic.GeneticAlgorithmUse();
            var test = gen.UseAlgorithm();
            Console.WriteLine(test.ToString());

        }
    }
}
