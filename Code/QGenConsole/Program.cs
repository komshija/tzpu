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
            #region Oblasti
            //0 - Nizovi Lako
            //1 - Algoritmi Lako
            //2 - Funkcije Lako
            //3 - Fajlovi Lako
            //4 - Matrice Lako

            //5 = 0 + 5 - Nizovi Srednje
            //6 = 1 + 5 - Algoritmi Srednje
            //7 = 2 + 5 - Funkcije Srednje
            //8 = 3 + 5 - Fajlovi Srednje
            //9 = 4 + 5 - Matrice Srednje

            //10 = 0 + 2*5 - Nizovi Tesko
            //11 = 1 + 2*5 - Algoritmi Tesko
            //12 = 2 + 2*5 - Funkcije Tesko
            //13 = 3 + 2*5 - Fajlovi Tesko
            //14 = 4 + 2*5 - Matrice Tesko
            #endregion
            #region Test_Primeri
            /*
            // Test 1 - Nalazi brzo - Kandidat za prezentaciji
            List<int> oblasti = new List<int> { 1, 6, 7, 14, 10 };
            List<double> zastupljenost = new List<double> { 0.6, 0.4, 0.4, 0.6, 0.4 };
            
            // Kandidat za prezentaciju
            List<int> oblasti = new List<int> { 1, 6, 7, 14, 10, 3 };
            List<double> zastupljenost = new List<double> { 0.6, 0.4, 0.4, 0.6, 0.4, 0.4 };


            // Test 2 - Nalazi brzo
            List<int> oblasti = new List<int> { 1, 6, 7, 14 };
            List<double> zastupljenost = new List<double> { 0.6, 0.4, 0.4, 0.6 };

            // Test 3 - Nalazi prebrzo
            List<int> oblasti = new List<int> { 3, 5, 8 };
            List<double> zastupljenost = new List<double> { 0.6, 0.2, 0.4 };

            //Test 4 - Nemoguce naci za 5, nalazi lako za 10
            List<int> oblasti = new List<int> { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
            List<double> zastupljenost = new List<double> { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 };
            
            //Test 5 - Nalazi
            List<int> oblasti = new List<int> { 3, 5, 8, 11 };
            List<double> zastupljenost = new List<double> { 0.6, 0.2, 0.4, 0.4 };
            */


            /*
             * POBOLJSATI
            
            // Problem kod ovoga je sto imamo 3 i 13 i odnos 0.6 i 0.4
            //List<int> oblasti = new List<int> { 3, 5, 8, 13 };
            //List<double> zastupljenost = new List<double> { 0.6, 0.2, 0.4, 0.4 };

            // Problem je sto ne moze da nadje kombinaciju 0 i 5 , 0 i 8
            //List<int> oblasti = new List<int> { 0, 5, 8, 10 };
            //List<double> zastupljenost = new List<double> { 0.6, 0.2, 0.4, 0.4 };
            */

            // TRENUTNO
            List<int> oblasti = new List<int> { 3, 5, 8, 11 };
            List<double> zastupljenost = new List<double> { 0.6, 0.2, 0.4, 0.4 };
            int testLength = 7;

            #endregion
            #region Unos
            /*
            string unos = null;
            bool stop_flag = false;
            oblasti.Clear();
            zastupljenost.Clear();
            Console.WriteLine("Unesite duzinu testa:");
            unos = Console.ReadLine();
            testLength = Convert.ToInt32(unos); ;
            do
            {
                Console.WriteLine("Unesite id oblasti:[0 - 15]");
                unos = Console.ReadLine();
                int oblast = Convert.ToInt32(unos);
                oblasti.Add(oblast);

                Console.WriteLine("Unesite zastupljenost:[0.1 - 1.0]");
                unos = Console.ReadLine();
                double zastupljeno = Convert.ToDouble(unos);

                zastupljenost.Add(zastupljeno);
                Console.WriteLine("======================================");

                for (int i = 0; i < oblasti.Count; i++)
                    Console.WriteLine($"Oblast {oblasti[i]} je zastupljena {zastupljenost[i]}.");

                Console.WriteLine("======================================");
                char input;
                
                do
                {
                    Console.WriteLine("Da li postoje jos oblasti?[y/n]");
                    input = Convert.ToChar(Console.ReadLine()[0]);
                }
                while (input != 'y' && input != 'n');

                if (input == 'n')
                {
                    if(zastupljenost.Sum(x => x) >= 1)
                        stop_flag = !stop_flag;
                    else
                        Console.WriteLine("Niste uneli dovoljnu zastupljenost! Suma zastupljenosti mora da bude vise od 100%");
                }
            }
            while (!stop_flag);

            Console.Clear();
            Console.WriteLine("======================================");

            for (int i = 0; i < oblasti.Count; i++)
                Console.WriteLine($"Oblast {oblasti[i]} je zastupljena {zastupljenost[i]}.");

            Console.WriteLine("======================================");
            */
            #endregion

            var gen = new Logic.GeneticAlgorithmUse();
            Test test = gen.UseAlgorithm(oblasti, zastupljenost, testLength);

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
