using DataAccess;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MiSe.Shuffle;

namespace Logic
{
    class TestCrossover : CrossoverBase
    {
        public TestCrossover(int parentsNumber = 10, int childrenNumber = 10) : base(parentsNumber, childrenNumber)
        {

        }

        // Mozda ima predispoziciju da udje u beskonacnu petlju..

        protected override IList<IChromosome> PerformCross(IList<IChromosome> parents)
        {
            List<IChromosome> tests = new List<IChromosome>();
            int gotovaDeca = 0;
            List<Question> allQuestions = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomains((parents[0] as Test).VratiDomeneKojeSadrziTest());
            Random rnd = new Random();

            while (gotovaDeca != ChildrenNumber)
            {
                List<Question> pitanjaDete = new List<Question>(parents[0].Length);
                // Shuffling algoritam
                ShuffleOps.ShuffleInPlace<Question>(allQuestions, new Random());

                for (int i = 0; i < parents[0].Length; i++)
                    pitanjaDete.Add(allQuestions[i]);

                Test potencijalni = new Test(pitanjaDete, parents[0].Length);

                while (potencijalni.HasDuplicate())
                {
                    pitanjaDete = pitanjaDete.Distinct().ToList();
                    ShuffleOps.ShuffleInPlace<Question>(allQuestions, new Random());
                    pitanjaDete.Add(allQuestions[0]);
                    potencijalni = new Test(pitanjaDete, parents[0].Length);
                }

                tests.Add(potencijalni);
                gotovaDeca++;
            }

            return tests;
        }
    }
}
