using DataAccess;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Terminations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class TestTermination : TerminationBase
    {
        private double m_lastFitness;
        private int m_stagnantGenerationsCount1;
        private int m_stagnantGenerationsCount2;
        public int ExpectedStagnantGenerationsNumber { get; set; }
        public List<int> Oblasti { get; set; }
        public TestTermination()
        {
            ExpectedStagnantGenerationsNumber = 100;
        }

        public TestTermination(int expectedStagnantGenerationsNumber, List<int> oblasti)
        {
            ExpectedStagnantGenerationsNumber = expectedStagnantGenerationsNumber;
            Oblasti = oblasti;
        }

        protected override bool PerformHasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            var bestFitness = geneticAlgorithm.BestChromosome.Fitness.Value;

            if(bestFitness == m_lastFitness)
            {
                m_stagnantGenerationsCount2++;
            }
            else
            {
                m_stagnantGenerationsCount2 = 1;
            }

            if (m_stagnantGenerationsCount2 == 1200)
            {
                List<Question> pitanja = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomainsAndAreSelected(Oblasti);
                if (pitanja.Count != 0)
                {
                    foreach (var p in pitanja)
                        p.Izabrano = false;
                    m_stagnantGenerationsCount2 = 1;
                }
            }

            if (bestFitness == 0)
            {
                m_stagnantGenerationsCount1++;
            }
            else
            {
                m_stagnantGenerationsCount1 = 1;
            }

            m_lastFitness = bestFitness;

            return (m_stagnantGenerationsCount1 >= ExpectedStagnantGenerationsNumber) || (m_stagnantGenerationsCount2 >= 1200);
        }
    }
}
