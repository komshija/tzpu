using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MiSe.Shuffle;
using GeneticSharp.Infrastructure.Framework.Threading;

namespace Logic
{
    class TestCrossover : CrossoverBase
    {
        List<int> oblasti;
        List<double> zastupljenost;
        public TestCrossover(List<int> oblasti, List<double> zastupljenost, int parentsNumber = 10, int childrenNumber = 5) : base(parentsNumber, childrenNumber)
        {
            this.oblasti = oblasti;
            this.zastupljenost = zastupljenost;
        }


        protected override IList<IChromosome> PerformCross(IList<IChromosome> parents)
        {
            List<IChromosome> tests = new List<IChromosome>();
            Random r = new Random();


            #region Permutaicje Od 7
            for (int i = 0; i < ParentsNumber - 1; i += 2)
            {
                Test test1 = parents[i] as Test;
                Test test2 = parents[i + 1] as Test;

                List<Question> allQuestions = new List<Question>();
                allQuestions.AddRange(test1.questions);
                allQuestions.AddRange(test2.questions);
                allQuestions = allQuestions.Distinct().ToList();

                // Od 10 pitanja, moze da se naprave 252 kombinacije bez ponavljanja
                // Od 7 pitanja, moze da se naprave 21 kombinacija bez ponavljanja

                Test bestChild = null;
                TestFitness fFunc = new TestFitness(oblasti, zastupljenost, 0);
				int nasumicanBroj = test1.questions.Count * 50 * r.Next();
                for (int j = 0; j < nasumicanBroj; j++)
                {
                    MiSe.Shuffle.ShuffleOps.ShuffleInPlace(allQuestions, r);
                    Test temp = new Test(allQuestions.Take(test1.questions.Count).ToList(), test1.questions.Count);
                    if (bestChild == null)
                        bestChild = temp;
                    else
                    {
                        if (fFunc.Evaluate(temp) > fFunc.Evaluate(bestChild))
                            bestChild = temp;
                    }
                }

                tests.Add(bestChild);
            }


            #endregion

            #region NadjiStaFali
            /*
            TestFitness fFunc = new TestFitness(oblasti, zastupljenost, 0);

            for (int i = 0; i < ParentsNumber - 1; i += 2)
            {
                Test test1 = parents[i] as Test;
                Test test2 = parents[i + 1] as Test;
                List<Question> allQuestions = new List<Question>();

                for (int j = 0; j < oblasti.Count; j++)
                    Console.WriteLine($"Oblast: {oblasti[j]} Zastupljenost: {zastupljenost[j]}");

                Console.WriteLine(test1);
                Console.WriteLine(test2);

                allQuestions.AddRange(test1.questions);
                allQuestions.AddRange(test2.questions);
                allQuestions = allQuestions.OrderBy(x=> x.Difficulties.Count).Distinct().ToList();


                if(fFunc.Evaluate(test1) < fFunc.Evaluate(test2))
                {
                    Test pom = test1;
                    test1 = test2;
                    test2 = pom;
                }

                List<int> potpunoPoklapanje = new List<int>();
                potpunoPoklapanje = 
                for (int j = 0; j < oblasti.Count; j++)
                {
                    if(test1.ProcenatPitanjaKojaSadrzeOblast(oblasti[j]) == zastupljenost[j])
                    {
                        test1.questions.Where(q => q.ContainsDomain(oblasti[j])).ToList();
                    }
                }



            }
            */

            #endregion

            return tests;
        }



        // Koristi se da dobijes sve permutacije duzine Length
        private Test GetAllCombos(List<Question> list, int Length)
        {

            TestFitness fFunc = new TestFitness(oblasti, zastupljenost, 0);
            int comboCount = (int)Math.Pow(2, list.Count) - 1;
            Test bestTest = null;

            for (int i = 1; i < comboCount + 1; i++)
            {
                List<Question> q = new List<Question>();
                for (int j = 0; j < list.Count; j++)
                {
                    if ((i >> j) % 2 != 0)
                        q.Add(list[j]);
                }
                if (q.Count == Length)
                {

                    Test temp = new Test(q, Length);
                    if (bestTest == null)
                        bestTest = temp;
                    else
                    {
                        if (fFunc.Evaluate(temp) > fFunc.Evaluate(bestTest))
                            bestTest = temp;
                    }
                }
            }


            return bestTest;
        }

    }
}
