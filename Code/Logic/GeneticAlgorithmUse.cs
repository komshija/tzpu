using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
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

            int Test_Lenght = 10;

            List<Question> qs = new List<Question>();

            for (int i = 0; i < Test_Lenght; i++)
                qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));



            Test t = new Test(qs, Test_Lenght);

            Console.WriteLine("=================== ADAM TEST ===================");
            Console.WriteLine(t.ToString());
            Console.WriteLine("=================================================");
            Console.WriteLine();
            Console.WriteLine("Starting genetic algorithm...");
            Console.WriteLine();
            Console.WriteLine("=================================================");
            Console.WriteLine();




            //Inicjalno na osnovu test-a kreira t kreira 15 testa koja su slicna 
            //Maksimalno u generaciji moze da ima 50 testa i od njih bira najbolji
            var population = new TestPopulation(15, 50, t);

            //1 - Nizovi
            //2 - Algoritmi
            //3 - Funkcije
            //4 - Fajlovi
            //5 - Matrice

            // Ovi parametri se podesavaju sta se trazi da vrati
            // Oblasti po ID-jevima koje treba da uvrsti
            List<int> oblasti = new List<int> { 1, 2, 3, 4, 5 };
            // Zastupljenost po oblastima koja odgovara poziciji gore
            List<float> zastupljenost = new List<float> { 0.6f, 0.2f, 0.2f, 0.4f, 0.2f };
            // Tezine za oblasti
            List<int> tezine = new List<int> { 3, 2, 5 ,4 };




            var fitness = new TestFitness(oblasti, zastupljenost, tezine); 
            // Selekcija => Bira najbolji iz generacije
            ISelection selection = new EliteSelection();

            // Crossover => Shuffle crossover, od 10 roditelj dobijamo 10 deteta koja su unikatna i ne ponavljaju se
            ICrossover crossover = new TestCrossover();

            // Menjamo jedno pitanje nasumicnim pitanjem iz baze podataka
            IMutation mutation = new TestMutation();   

            // Uslov za prekid genetskog algoritma
            // 1. Kad fitness stagnira, tj 500 generacije za redom daju isti fitness 
            // 2. Ako napravimo 1000 generacija
            ITermination termination = new OrTermination(new ITermination[] { new FitnessStagnationTermination(250), new GenerationNumberTermination(1000) }) ;
            GeneticAlgorithm ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = termination
            };

            Console.WriteLine("Fitness change:");
            // Callback, prikazuje kada dodje do promene fitnessa
            double oldFitness = 0;
            ga.GenerationRan += (sender, arg) =>
            {
                if (ga.GenerationsNumber % 100 == 0)
                    Console.WriteLine($"Current generation number: {ga.GenerationsNumber}");
                if (ga.BestChromosome.Fitness > oldFitness)
                {
                    oldFitness = ga.BestChromosome.Fitness.Value;
                    Console.WriteLine($"Current fitness: {ga.BestChromosome.Fitness}");
                }

            };
            Console.WriteLine("=================================================");

            ga.Start();
            Test bestChromosome = ga.BestChromosome as Test;

            return bestChromosome;
        }

    }
}
