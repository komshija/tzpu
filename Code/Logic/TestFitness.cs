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
        List<int> oblasti;
        List<float> zastupljenost;
        List<int> tezine;
        int questionsNumber; 
        public TestFitness(List<int> oblasti, List<float> zastupljenost, List<int> tezine, double minTezina)
        {
            this.oblasti = oblasti;
            this.tezine = tezine;
            this.zastupljenost = zastupljenost;
            questionsNumber = oblasti.Count;

            this.minTezina = minTezina;
        }
        public double Evaluate(IChromosome chromosome)
        {
            Test t = chromosome as Test;
            double fitness = 0;
            //Verzija 1
            /*
            for (int i = 0; i < oblasti.Count; i++)
            {
                int sadrzi = t.QuestionsCoitansDomain(oblasti[i]);

                fitness += sadrzi;
                fitness += t.QuestionsDomainDifficulty(oblasti[i], tezine[i]);

                if (sadrzi == 0)
                    fitness = 0;
                
            }
            */

            // Verzija 2


            int count = 0;
            double tolerance = 0.1f;
            double domainAmountCoef = 1f;

            //Prvo proverava da li se oblasti sadrze u zadatoj meri
            for (int i = 0; i < questionsNumber; i++)
            {
                float domainAmount = t.GetDomainAmount(oblasti[i]);
                if (domainAmount <= zastupljenost[i] + tolerance && domainAmount >= zastupljenost[i] - tolerance)
                {
                    count++;
                    domainAmountCoef += 0.5;
                }
                else
                    domainAmountCoef -= 0.5;
              
            }
            fitness += Convert.ToDouble(count) * domainAmountCoef;

            //Drugo bi trebalo da proveri dal ima duplikati
            //ma da to bi trebalo da se spreci kroz crossover, i mutaciju

            //bool duplikat = false;
            //for (int i = 0; i < questionsNumber && !duplikat; i++)
            //    for(int j= i+1;j<questionsNumber;j++)
            //        if (t.questions[i].Id == t.questions[j].Id)
            //            duplikat = true;

            //if (duplikat)
            //    fitness = 0;


            ////Proverava da li oblasti  imaju tezine
            //int brojOblastiKojeImajuTrazenuTezinu = t.QuestionsDomainDifficulty(oblasti[i], tezine[i]);
            //// Ovo sam izmlatio odnos, verovatno moze da se promeni na bolje
            //fitness += Convert.ToDouble(brojOblastiKojeImajuTrazenuTezinu) / Convert.ToDouble(count);


            return fitness;
        }
    }
}
