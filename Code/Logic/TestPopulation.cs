using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Infrastructure.Framework.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class TestPopulation : Population
    {


        List<int> oblasti;
        public TestPopulation(int minSize, int maxSize, IChromosome adamChromosome, List<int> oblasti) : base(minSize, maxSize, adamChromosome)
        {
            this.oblasti = oblasti;
        }

        public override void CreateInitialGeneration()
        {
            Generations = new List<Generation>();
            GenerationsNumber = 0;
            var chromosomes = new List<IChromosome>();
            for (int i = 0; i < MinSize; i++)
            {
                
                var c = (AdamChromosome as Test).GenerateRandomTest(oblasti);

                if (c == null)
                {
                    throw new InvalidOperationException("The Adam chromosome's 'CreateNew' method generated a null chromosome. This is a invalid behavior, please, check your chromosome code.");
                }
                c.ValidateGenes();
                chromosomes.Add(c);
            }
            CreateNewGeneration(chromosomes);
        }
    }
}
