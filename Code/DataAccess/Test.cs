using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Test : ChromosomeBase
    {

        public List<Question> questions { get; protected set; }

        public Test(List<Question> qs, int lenght) : base(lenght)
        {
            questions = qs;
            this.CreateGenes();
        }

        public override IChromosome CreateNew()
        {
            IDataAccess da = DataAccess.GetInstance();
            List<Question> questionsNova = new List<Question>();

            foreach (var existingQuestion in questions)
            {
                bool dodato = false;
                do
                {
                    double tolerance = 2;
                    var sameQ = da.GetQuestionsByOverallDifficulty(existingQuestion.GetOverallDifficulty(), tolerance);
                    dodato = sameQ.Count > 0;
                    
                    if (dodato)
                        questionsNova.Add(sameQ[new Random().Next(sameQ.Count)]);
                    else
                        tolerance += 0.5;
                }
                while (!dodato);

            }


            return new Test(questionsNova, Length);
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
            result.AppendLine($"Overall difficulty sum: {GetSumDiff()}");
            return result.ToString();
        }
        
    }
}
