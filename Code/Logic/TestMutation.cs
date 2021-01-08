using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class TestMutation : MutationBase
    {
        IDataAccess dataAccess;
        List<int> oblasti;
        List<double> zastupljenost;

        public TestMutation(List<int> domains, List<double> zastupljenost)
        {
            dataAccess = DataAccess.DataAccess.GetInstance();
            this.oblasti = domains;
            this.zastupljenost = zastupljenost;
        }

        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            Random r = new Random();
            if (r.NextDouble() <= probability)
            {
                var test = chromosome as Test;

                var possibleQuesitons = dataAccess.GetQuestionsWhichContainDomains(oblasti);
                var fFunc = new TestFitness(oblasti, zastupljenost, 0);
                double fitness = fFunc.Evaluate(test);


                int bestIndex = -1;
                int qIndex;
                do
                {
                    qIndex = r.Next(possibleQuesitons.Count);
                    for (int index = 0; index < test.questions.Count; index++)
                    {
                        var q = test.CreateNew() as Test;

                        q.questions[index] = possibleQuesitons[qIndex];
                        if (!q.HasDuplicate() && fFunc.Evaluate(q) >= fitness)
                            bestIndex = index;

                    }

                } while (bestIndex == -1);

                test.questions[bestIndex] = possibleQuesitons[qIndex];
            }

        }
    }
}
