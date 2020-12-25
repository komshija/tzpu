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

            //foreach(var q in  questions)
            //    Console.WriteLine(q);
            /*
            int a = dataAccess.GetQuestionsWhichContainDomains(new List<int> { 3,8 }).Count;
            int b = dataAccess.GetQuestionsWhichContainDomains(new List<int> { 3,5 }).Count;
            Console.WriteLine($"3,8 :: {a} \n 3,5 :: {b}");
            */
            //            /* 
            var gen = new Logic.GeneticAlgorithmUse();
            Test test = gen.UseAlgorithm();

            Console.WriteLine();
            Console.WriteLine("Best test:");
            if (test != null)
            {
                Console.WriteLine(test.ToString());
                Console.WriteLine($"Test fitness: {test.Fitness}");
            }
            else
                Console.WriteLine("Nemoguce naci trazeni test!");
            //             */


        }
    }
}
