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

        List<int> oblasti;
        List<double> zastupljenost;
        //List<int> tezine;
        double tolerance;
        int brojOblasti;

        public TestFitness(List<int> oblasti, List<double> zastupljenost/*, List<int> tezine*/, double tolerance)
        {
            this.oblasti = oblasti;
            // this.tezine = tezine;
            this.zastupljenost = zastupljenost;
            this.tolerance = tolerance;
            brojOblasti = oblasti.Count;
        }
        public double Evaluate(IChromosome chromosome)
        {
            //Test t koji se procenjuje
            Test test = chromosome as Test;
            double fitness = 0;

            for (int i = 0; i < brojOblasti; i++)
            {
                double domainAmount = test.ProcenatPitanjaKojaSadrzeOblast(oblasti[i]);
                fitness += domainAmount == zastupljenost[i] ? 1 : 0;
            }


            return fitness;
        }
    }
}
