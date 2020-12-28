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

                int tIndex = r.Next(test.questions.Count);
                int qIndex = r.Next(possibleQuesitons.Count);

                test.questions[tIndex] = possibleQuesitons[qIndex];

            }
        }
    }
}
