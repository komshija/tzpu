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

            var gen = new Logic.GeneticAlgorithmUse();
            Test test = gen.UseAlgorithm();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Best test:");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(test.ToString());
            Console.WriteLine($"Test fitness: {test.Fitness}");

        }
    }
}
