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

        public Test UseAlgorithm(List<int> oblasti, List<double> zastupljenost, int Test_Length)
        {
            Random r = new Random(10);
            IDataAccess dataAccess = DataAccess.DataAccess.GetInstance();

            List<Question> qs = new List<Question>();

            for (int i = 0; i < Test_Length; i++)
                qs.Add(dataAccess.GetQuestionById(1 + r.Next(1000)));

            Test adamTest = new Test(qs, Test_Length);

            int num = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomains(oblasti).Count;
            Console.WriteLine($"Broj pitanja koja sadrze samo ove oblasti {num}");
            Console.WriteLine();

            List<double> zastupljenost_kao_br_pitanja = new List<double>();
            foreach (var vrednost in zastupljenost)
                zastupljenost_kao_br_pitanja.Add(Math.Round(vrednost * Test_Length));

            var fitness = new TestFitness(oblasti, zastupljenost_kao_br_pitanja, 0);

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
            ICrossover crossover = new TestCrossover(oblasti, zastupljenost_kao_br_pitanja, 4,2);


            // Menjamo jedno pitanje nasumicnim pitanjem iz baze podataka
            IMutation mutation = new TestMutation(oblasti, zastupljenost_kao_br_pitanja);


            ITermination termination = new OrTermination(new ITermination[] { new TestTermination(100,oblasti),
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

            foreach (var q in bestChromosome.questions)
            {
                q.Izabrano = true;
            }

            return bestChromosome;
        }

    }
}
