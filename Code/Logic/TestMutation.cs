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
        List<int> domains;
        public TestMutation(List<int> domains)
        {
            dataAccess = DataAccess.DataAccess.GetInstance();
            this.domains = domains;
        }

        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            Random r = new Random();
            if (r.NextDouble() >= probability)
            {
                var test = chromosome as Test;
                int index = r.Next(test.questions.Count);

                var possibleQuesitons = dataAccess.GetQuestionsWhichContainDomains(domains);
                int qIndex = r.Next(possibleQuesitons.Count);
                
                test.questions[index] = possibleQuesitons[qIndex];
            }
        }
    }
}
