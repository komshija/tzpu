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
        //ovde u konstruktor se zadaju parametri sta je dobar test, to treba smislimo
        double minTezina;
        public TestFitness(double minTezina)
        {
            this.minTezina = minTezina;
        }
        public double Evaluate(IChromosome chromosome)
        {
            Test t = chromosome as Test;
            double testTezina = t.GetSumDiff();
            if (testTezina > minTezina)
                return t.GetSumDiff();
            else
                return 0;
        }
    }
}
