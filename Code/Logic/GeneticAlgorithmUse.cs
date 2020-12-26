using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Linq;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Reinsertions;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;

namespace Logic
{
    public class GeneticAlgorithmUse
    {

        public Test UseAlgorithm()
        {
            Random r = new Random(10);
            IDataAccess dataAccess = DataAccess.DataAccess.GetInstance();

            int Test_Lenght = 5;

            List<Question> qs = new List<Question>();

            for (int i = 0; i < Test_Lenght; i++)
                qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));

            Test adamTest = new Test(qs, Test_Lenght);

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

            

            int num = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomains(oblasti).Count;
            Console.WriteLine($"Broj pitanja koja sadrze samo ove oblasti {num}");
            Console.WriteLine();


            var fitness = new TestFitness(oblasti, zastupljenost, 0);

            IGenerationStrategy generationStrategy = new PerformanceGenerationStrategy(3);
            var population = new TestPopulation(20, 50, adamTest, oblasti)
            {
                GenerationStrategy = generationStrategy
            };


            ISelection selection = new EliteSelection();



            // Crossover => TwoPoint 
            //ICrossover crossover = new TwoPointCrossover();
            //ICrossover crossover = new OnePointCrossover(Convert.ToInt32(0.6*Test_Lenght));
            //ICrossover crossover = new UniformCrossover();
            //ICrossover crossover = new ThreeParentCrossover();
            //ICrossover crossover = new PositionBasedCrossover();
            ICrossover crossover = new TestCrossover(oblasti, zastupljenost,4,2);


            // Menjamo jedno pitanje nasumicnim pitanjem iz baze podataka
            IMutation mutation = new TestMutation(oblasti,zastupljenost);


            ITermination termination = new OrTermination(new ITermination[] { new TestTermination(100),
                                                                              new FitnessThresholdTermination(oblasti.Count),
                                                                              new GenerationNumberTermination(3000) });


            GeneticAlgorithm ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = termination,
                CrossoverProbability = 1f,
                MutationProbability = 0.7f
            };

            Console.WriteLine("Fitness change:");

            // Callback, prikazuje kada dodje do promene fitnessa
            double oldFitness = 0;
            List<Test> tests = new List<Test>();
            ga.GenerationRan += (sender, arg) =>
            {
                if (ga.BestChromosome.Fitness >= oldFitness)
                {
                    oldFitness = ga.BestChromosome.Fitness.Value;
                    tests.Add(ga.BestChromosome as Test);
                    Console.WriteLine($"Current fitness: {ga.BestChromosome.Fitness} for generation : {ga.GenerationsNumber}");
                }

            };
            Console.WriteLine("=================================================");

            ga.Start();

            if (oldFitness == 0)
                return null;
            var lista = tests.Where(x => !x.HasDuplicate()).OrderByDescending(x => x.Fitness.Value).ToList();
            Test bestChromosome = lista.FirstOrDefault();


            return bestChromosome;
        }

    }
}
