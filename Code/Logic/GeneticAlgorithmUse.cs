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

            Test t = new Test(5);

            t.AddQuestion(dataAccess.GetQuestionById(1 + r.Next(1000)));
            t.AddQuestion(dataAccess.GetQuestionById(1 + r.Next(1000)));
            t.AddQuestion(dataAccess.GetQuestionById(1 + r.Next(1000)));
            t.AddQuestion(dataAccess.GetQuestionById(1 + r.Next(1000)));
            t.AddQuestion(dataAccess.GetQuestionById(1 + r.Next(1000)));

            // Chromosome => TEST
            // Inicijalna populacija => dva random testa
            // Generacija => ??
            // Fitnes Func => Treba da bude po tome sta unese korisnik
            // Crossover => Implementiramo, 60% parent 40% ostali
            // Mutation => Implementiramo menjamo 1 pitanje u 1% slucajeva
            // Termination => Ima vec,koristi se OR, max 1000 generacija ili zadovoljena fitness funkcija


            var population = new Population(2, 2, t);

            // Kolko odgovara, ovde samo uzme ukupnu tezinu testa i vrati je
            var fitness = new FuncFitness((c) =>
            {
                var fc = c as Test;
                var values = fc.GetSumDiff();
                return values;
            });

            var selection = new TournamentSelection();

            var crossover = new UniformCrossover(0.5f);
            var mutation = new PartialShuffleMutation();
            var termination = new GenerationNumberTermination(1000);
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
