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
        List<int> tezine;
        double tolerance;
        int questionsNumber;
        public TestFitness(List<int> oblasti, List<double> zastupljenost, List<int> tezine,double tolerance)
        {
            this.oblasti = oblasti;
            this.tezine = tezine;
            this.zastupljenost = zastupljenost;
            this.tolerance = tolerance;
            questionsNumber = oblasti.Count;
        }
        public double Evaluate(IChromosome chromosome)
        {
            //Test t koji se procenjuje
            Test t = chromosome as Test;
            double fitness = 0;

            List<double> p = new List<double> { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1 };

            double count = 0;
            //double ukupnoOdstupanje = 0;

            //for za sve zadate parametre
            for (int i = 0; i < questionsNumber; i++)
            {
                double domainAmount = t.GetDomainAmount(oblasti[i]);
                //Question question = t.GetGene(i).Value as Question;

                // Mora se smisli da se izracuna odstupanje od trazene tezine
                // Prosecna vrednost ne daje bas okej rezultate

                //double razlika = tezine[i];// - domainDifficulty;

                foreach (var am in p)
                {
                    if (domainAmount >= zastupljenost[i] * am)
                    {
                        count += (domainAmount * 100);
                    }
                }



            }

            fitness = count / Convert.ToDouble(questionsNumber);

            ////Proverava da li oblasti  imaju tezine
            //int brojOblastiKojeImajuTrazenuTezinu = t.QuestionsDomainDifficulty(oblasti[i], tezine[i]);
            //// Ovo sam izmlatio odnos, verovatno moze da se promeni na bolje
            //fitness += Convert.ToDouble(brojOblastiKojeImajuTrazenuTezinu) / Convert.ToDouble(count);


            return fitness;
        }
    }
}
