using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
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

            List<Question> qs = new List<Question>();

            qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));
            qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));
            qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));
            qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));
            qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));

            double sum = 0;
            foreach (var q in qs)
            {
                Console.WriteLine($"{q.ToString()}");
                sum += q.GetOverallDifficulty();
            }

              

            Console.WriteLine($"Adam chromosome overall difficulty: {sum}");

            Test t = new Test(qs, 5);
            // Chromosome => TEST
            // Inicijalna populacija => dva random testa
            // Generacija => ??
            // Fitnes Func => Treba da bude po tome sta unese korisnik
            // Crossover => Implementiramo, 60% parent 40% ostali
            // Mutation => Implementiramo menjamo 1 pitanje u 1% slucajeva
            // Termination => Ima vec,koristi se OR, max 1000 generacija ili zadovoljena fitness funkcija


            var population = new TestPopulation(5, 50, t);

            // Kolko odgovara, ovde samo uzme ukupnu tezinu testa i vrati je

            Console.WriteLine("Unesite najmanju tezinu:");
            double tezina = Convert.ToDouble(Console.ReadLine());


            var fitness = new TestFitness(tezina);
            var selection = new TournamentSelection();
            var crossover = new TestCrossover();
            var mutation = new TestMutation();


            var termination = new AndTermination(new ITermination[] { new FitnessThresholdTermination(tezina),new GenerationNumberTermination(1000) });
            var ga = new GeneticAlgorithm(
                            population,
                            fitness,
                            selection,
                            crossover,
                            mutation);

            ga.Termination = termination;

            ga.Start();

            var bestChromosome = ga.BestChromosome as Test;

            return bestChromosome;
        }

    }
}
