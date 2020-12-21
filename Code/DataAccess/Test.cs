using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Test : ChromosomeBase
    {

        List<Question> questions;

        public Test(int lenght) : base(lenght)
        {
            questions = new List<Question>(lenght);
        }

        public override IChromosome CreateNew()
        {
            return new Test(Length);
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(questions[geneIndex].GetOverallDifficulty());
        }

        public double GetSumDiff()
        {
            double sum = 0;
            foreach (var q in questions)
                sum += q.GetOverallDifficulty();
            return sum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var q in questions)
                result.AppendLine(q.ToString());
            return result.ToString();
        }
        
        public void AddQuestion(Question q)
        {
            if(questions.Capacity > questions.Count)
            {
                questions.Add(q);
                int i = questions.Count - 1;
                ReplaceGene(i,GenerateGene(i));
            }
        }


    }
}
