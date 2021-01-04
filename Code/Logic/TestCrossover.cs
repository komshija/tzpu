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

            for (int i = 0; i < ParentsNumber - 1; i += 2)
            {
                Test test1 = parents[i] as Test;
                Test test2 = parents[i + 1] as Test;

                List<Question> allQuestions = new List<Question>();
                allQuestions.AddRange(test1.questions);
                allQuestions.AddRange(test2.questions);
                allQuestions = allQuestions.Distinct().ToList();

                Test bestChild = null;
                TestFitness fFunc = new TestFitness(oblasti, zastupljenost, 0);
				int BrojPermutacija = test1.questions.Count * 50;
                for (int j = 0; j < BrojPermutacija; j++)
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

            return tests;
        }
    }
}
