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
        public TestMutation()
        {
            dataAccess = DataAccess.DataAccess.GetInstance();
        }

        protected override void PerformMutate(IChromosome chromosome, float probability)
        {
            Random r = new Random();
            if (r.NextDouble() >= probability)
            {
                var test = chromosome as Test;
                int index = r.Next(test.questions.Count);
                int id = 1 + r.Next(1000);
                test.questions[index] = dataAccess.GetQuestionById(id);
            }
        }
    }
}
