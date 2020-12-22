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
        List<float> zastupljenost;
        List<int> tezine;
        int questionsNumber;
        public TestFitness(List<int> oblasti, List<float> zastupljenost, List<int> tezine)
        {
            this.oblasti = oblasti;
            this.tezine = tezine;
            this.zastupljenost = zastupljenost;
            questionsNumber = oblasti.Count;
        }
        public double Evaluate(IChromosome chromosome)
        {
            //Test t koji se procenjuje
            Test t = chromosome as Test;


            double fitness = 0;

            int count = 0;
            double tolerance = 0.1f;
            double domainAmountCoef = 1f;

            //Ovo lepo radi, vraca testove u kojima su zastupljena tacno zastupljena pitanja
            for (int i = 0; i < questionsNumber; i++)
            {
                float domainAmount = t.GetDomainAmount(oblasti[i]);
                if (zastupljenost[i] == 0 && domainAmount == 0)
                {
                    count++;
                }
                else if (domainAmount <= zastupljenost[i] + tolerance && domainAmount >= zastupljenost[i] - tolerance)
                {
                    count++;
                    domainAmountCoef += 0.5;
                }
                else
                    domainAmountCoef -= 0.5;


            }
            fitness += Convert.ToDouble(count) * domainAmountCoef;

            ////Proverava da li oblasti  imaju tezine
            //int brojOblastiKojeImajuTrazenuTezinu = t.QuestionsDomainDifficulty(oblasti[i], tezine[i]);
            //// Ovo sam izmlatio odnos, verovatno moze da se promeni na bolje
            //fitness += Convert.ToDouble(brojOblastiKojeImajuTrazenuTezinu) / Convert.ToDouble(count);


            return fitness;
        }
    }
}
