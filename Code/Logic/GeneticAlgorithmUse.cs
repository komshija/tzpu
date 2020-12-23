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

            int Test_Lenght = 5;

            List<Question> qs = new List<Question>();

            for (int i = 0; i < Test_Lenght; i++)
                qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));



            Test adamTest = new Test(qs, Test_Lenght);
            /*
            Console.WriteLine("=================== ADAM TEST ===================");
            Console.WriteLine(adamTest);
            Console.WriteLine("=================================================");
            Console.WriteLine();
            Console.WriteLine("Starting genetic algorithm...");
            Console.WriteLine();
            Console.WriteLine("=================================================");
            Console.WriteLine();
            */

            //1 - Nizovi
            //2 - Algoritmi
            //3 - Funkcije
            //4 - Fajlovi
            //5 - Matrice

            // Ovi parametri se podesavaju sta se trazi da vrati
            // Oblasti po ID-jevima koje treba da uvrsti
            List<int> oblasti = new List<int> { 1, 2, 3 };

            // Zastupljenost po oblastima koja odgovara poziciji gore
            List<double> zastupljenost = new List<double> { 0.6, 0.2, 0.2 };

            // Tezine za oblasti
            List<int> tezine = new List<int> { 3, 4 };

            var fitness = new TestFitness(oblasti, zastupljenost, tezine, 0);







            /*
             * Nekako da se napravi da inicijalna generacija sadrzi sva pitanja koja imaju te zastupljenosti 
             * npr ako treba na test da ima 0.5 neke oblasti
             * Inicijalna populacija da ima pitanja koja moze da imaju max zastupljenost te oblasti od 0.5 na celom testu
             * 
             * 
             * */



            //Inicjalno kreira 10 test-a nasumicno 
            //Maksimalno u generaciji moze da ima 50 testa i od njih bira najbolji

            var population = new TestPopulation(10, 50, adamTest, oblasti);


            // Selekcija => Bira najbolji iz generacije tj. onaj koji ima najveci fitness
            ISelection selection = new EliteSelection();


            // Crossover => TwoPoint 
            /*
             * parent1 = (1 2 3 4 5 6)
             * parent2 = (7 8 9 10 11 12)
             * 
             * i = 2 j = 5
             * child1 = (1 2 9 10 11 6)
             * child2 = (7 8 3 4 5 12)
             * 
            */
            ICrossover crossover = new TwoPointCrossover();


            // Menjamo jedno pitanje nasumicnim pitanjem iz baze podataka
            IMutation mutation = new TestMutation(oblasti);


            // Uslov za prekid genetskog algoritma
            // 1. Kad fitness stagnira, tj 150 generacije za redom daju isti fitness 
            // 2. Ako napravimo 1000 generacija
            ITermination termination = new OrTermination(new ITermination[] { new FitnessStagnationTermination(400),
                                                                              new GenerationNumberTermination(1000) });



            GeneticAlgorithm ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
            {
                Termination = termination,
                CrossoverProbability = 0.9f,
                MutationProbability = 0.4f
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
                    Console.WriteLine($"Current fitness: {ga.BestChromosome.Fitness} for generation : {ga.GenerationsNumber}");
                }

            };
            Console.WriteLine("=================================================");

            ga.Start();
            Test bestChromosome = ga.BestChromosome as Test;

            return bestChromosome;
        }

    }
}
