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
        private int m_stagnantGenerationsCount;
        public int ExpectedStagnantGenerationsNumber { get; set; }
        public TestTermination()
        {
            ExpectedStagnantGenerationsNumber = 100;
        }

        public TestTermination(int expectedStagnantGenerationsNumber)
        {
            ExpectedStagnantGenerationsNumber = expectedStagnantGenerationsNumber;
        }

        protected override bool PerformHasReached(IGeneticAlgorithm geneticAlgorithm)
        {
            var bestFitness = geneticAlgorithm.BestChromosome.Fitness.Value;

            if (bestFitness == 0)
            {
                m_stagnantGenerationsCount++;
            }
            else
            {
                m_stagnantGenerationsCount = 1;
            }

            return m_stagnantGenerationsCount >= ExpectedStagnantGenerationsNumber;
        }
    }
}
