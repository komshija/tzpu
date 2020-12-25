using GeneticSharp.Domain.Populations;
using GeneticSharp.Infrastructure.Framework.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    class TestGenerationStrategy : IGenerationStrategy
    {
        public int GenerationsNumber { get; set; }
        public TestGenerationStrategy(int genNum)
        {
            GenerationsNumber = genNum;
        }
        public void RegisterNewGeneration(IPopulation population)
        {
            ExceptionHelper.ThrowIfNull("population", population);

            if (population.Generations.Count > GenerationsNumber)
            {
                var lowestFitness = population.Generations.Where(z => z.BestChromosome != null).Min(x => x.BestChromosome.Fitness);
                var lowestFitnessGen = population.Generations.Where(y => y.BestChromosome != null && y.BestChromosome.Fitness == lowestFitness).FirstOrDefault();
                population.Generations.Remove(lowestFitnessGen);
            }

        }
    }
}
