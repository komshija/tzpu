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

        protected override IList<IChromosome> PerformCross(IList<IChromosome> parents)
        {
            List<IChromosome> tests = new List<IChromosome>();
            Random rnd = new Random();
            // Kombinuje testove koji su izabrani za roditelje i pravi decu

            //Od svakog roditelja prvog roditelja uzme 60%
            //A od ostalih kombinuje ostatak

            parents = parents.OrderBy(p => p.Fitness).ToList();

            int gotovaDeca = 0;

            List<Question> allQuestions = new List<Question>();
            foreach (var p in parents)
            {
                allQuestions.AddRange((p as Test).questions);
            }
            allQuestions = allQuestions.Distinct().ToList();

            /*
            while (gotovaDeca != ChildrenNumber)
            {
                List<Question> pitanjaDete = new List<Question>(parents[0].Length);

                Test prvi = parents.FirstOrDefault() as Test;
                parents.Remove(prvi);

                for (int i = 0; i < Convert.ToInt32((double)prvi.Length * 0.6); i++)
                    pitanjaDete.Add(prvi.questions[i]);

                pitanjaDete = pitanjaDete.Distinct().ToList();

                int indexRoditelj = 0;
                int indexPitanje = 0;
                while (pitanjaDete.Count != parents[0].Length)
                {
                    Test roditelj = parents[indexRoditelj] as Test;
                    pitanjaDete.Add(roditelj.questions[indexPitanje]);
                    indexPitanje++;
                    if (indexPitanje == parents[0].Length)
                    {
                        indexPitanje = 0;
                        indexRoditelj++;
                    }
                }

                Test potencijalni = new Test(pitanjaDete, parents[0].Length);

                Random r = new Random();
                while (potencijalni.HasDuplicate())
                {
                    pitanjaDete = pitanjaDete.Distinct().ToList();
                    pitanjaDete.Add(allQuestions[r.Next(allQuestions.Count)]);
                }
                gotovaDeca++;
            }
            */

            while (gotovaDeca != ChildrenNumber)
            {
                List<Question> pitanjaDete = new List<Question>(parents[0].Length);
                // Shuffling algoritam
                ShuffleOps.ShuffleInPlace<Question>(allQuestions, new Random());

                for (int i = 0; i < parents[0].Length; i++)
                    pitanjaDete.Add(allQuestions[i]);

                Test potencijalni = new Test(pitanjaDete, parents[0].Length);
                
                while(potencijalni.HasDuplicate())
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
