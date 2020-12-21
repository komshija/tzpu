using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class TestPopulation : IPopulation
    {
        public DateTime CreationDate => DateTime.Now;

        public IList<Generation> Generations => new List<Generation>();

        public Generation CurrentGeneration => throw new NotImplementedException();

        public int GenerationsNumber => throw new NotImplementedException();

        public int MinSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IChromosome BestChromosome => throw new NotImplementedException();

        public IGenerationStrategy GenerationStrategy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler BestChromosomeChanged;

        public void CreateInitialGeneration()
        {
            throw new NotImplementedException();
        }

        public void CreateNewGeneration(IList<IChromosome> chromosomes)
        {
            throw new NotImplementedException();
        }

        public void EndCurrentGeneration()
        {
            throw new NotImplementedException();
        }
    }
}
