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

            // Ovi parametri se podesavaju sta se trazi da vrati
            // Oblasti po ID-jevima koje treba da uvrsti
            List<int> oblasti = new List<int> { 1, 6, 7, 14 };
            int num = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomains(oblasti).Count;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Broj pitanja koja sadrze samo ove oblasti {num}");
            Console.WriteLine();
            Console.WriteLine();

            // Zastupljenost po oblastima koja odgovara poziciji gore
            List<double> zastupljenost = new List<double> { 0.4, 0.2, 0.2, 0.2 };


            var fitness = new TestFitness(oblasti, zastupljenost, 0);

            /*
             * Nekako da se napravi da inicijalna generacija sadrzi sva pitanja koja imaju te zastupljenosti 
             * npr ako treba na test da ima 0.5 neke oblasti
             * Inicijalna populacija da ima pitanja koja moze da imaju max zastupljenost te oblasti od 0.5 na celom testu
             * 
             * 
             * */



            //Inicjalno kreira 20 test-a nasumicno 
            //Maksimalno u generaciji moze da ima 100 testa i od njih bira najbolji

            var population = new TestPopulation(20, 100, adamTest, oblasti);

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
            //ICrossover crossover = new TwoPointCrossover();
            ICrossover crossover = new OnePointCrossover();


            // Menjamo jedno pitanje nasumicnim pitanjem iz baze podataka
            IMutation mutation = new TestMutation(oblasti);


            // Uslov za prekid genetskog algoritma
            // 1. Kad fitness stagnira, tj 150 generacije za redom daju isti fitness 
            // 2. Ako napravimo 1000 generacija
            //ITermination termination = new OrTermination(new ITermination[] { new FitnessThresholdTermination(30),
            //                                                                  new GenerationNumberTermination(1000) });
            ITermination termination = new FitnessThresholdTermination(10*oblasti.Count);



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
                //if (ga.GenerationsNumber % 100 == 0)
                //    Console.WriteLine($"Current generation number: {ga.GenerationsNumber}");
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
