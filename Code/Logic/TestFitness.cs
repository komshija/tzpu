using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class TestFitness : IFitness
    {
        List<int> oblasti;
        List<double> zastupljenost;
        double tolerance;
        int brojOblasti;

        public TestFitness(List<int> oblasti, List<double> zastupljenost, double tolerance)
        {
            this.oblasti = oblasti;
            this.zastupljenost = zastupljenost;
            this.tolerance = tolerance;
            brojOblasti = oblasti.Count;
        }
        public double Evaluate(IChromosome chromosome)
        {
            Test test = chromosome as Test;
            double fitness = 0;

            for (int i = 0; i < brojOblasti; i++)
            {
                double domainAmount = test.BrojPitanjaKojaSadrzeOblast(oblasti[i]);
                fitness += domainAmount == zastupljenost[i] ? 1 : 0;
            }


            return fitness;
        }
    }
}
