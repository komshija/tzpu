using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class TestCrossover : CrossoverBase
    {
        public TestCrossover(int parentsNumber = 2,int childrenNumber = 1) : base(parentsNumber,childrenNumber)
        {

        }

        protected override IList<IChromosome> PerformCross(IList<IChromosome> parents)
        {
            List<IChromosome> tests = new List<IChromosome>();
            
            Test t1 = parents[0] as Test;
            Test t2 = parents[1] as Test;

            List<Question> questions = new List<Question>();

            for(int i = 0; i < Convert.ToInt32((double)t1.Length * 0.6); i++)
                questions.Add(t1.questions[i]);

            for (int i = 0; i < Convert.ToInt32((double)t2.Length * 0.4); i++)
                questions.Add(t2.questions[i]);

            Test result = new Test(questions,t1.Length);

            return tests;
        }
    }
}
