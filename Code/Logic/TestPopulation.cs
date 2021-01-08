using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Infrastructure.Framework.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class TestPopulation : Population
    {


        List<int> oblasti;
        public TestPopulation(int minSize, int maxSize, IChromosome adamChromosome, List<int> oblasti) : base(minSize, maxSize, adamChromosome)
        {
            this.oblasti = oblasti;
        }

        public override void CreateInitialGeneration()
        {
            Generations = new List<Generation>();
            GenerationsNumber = 0;
            List<Question> possibleQuestions = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomains(oblasti);
            var chromosomes = new List<IChromosome>();
            for (int i = 0; i < MinSize; i++)
            {
                var c = GenerisiTest(possibleQuestions);
                if (c == null)
                {
                    throw new InvalidOperationException("The Adam chromosome's 'CreateNew' method generated a null chromosome. This is a invalid behavior, please, check your chromosome code.");
                }
                c.ValidateGenes();
                chromosomes.Add(c);
            }
            CreateNewGeneration(chromosomes);
        }
        public override void CreateNewGeneration(IList<IChromosome> chromosomes)
        {
            base.CreateNewGeneration(chromosomes);
        }

        private Test GenerisiTest(List<Question> questions)
        {
            Random r = new Random();
            List<Question> testQuestions = new List<Question>();
            for (int i = 0; i < AdamChromosome.Length; i++)
            {
                Question q = questions[r.Next(questions.Count)];
                testQuestions.Add(q);
                questions.Remove(q);
            }

            return new Test(testQuestions, AdamChromosome.Length);
        }

    }
}
