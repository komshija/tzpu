using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MiSe.Shuffle;

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
            Test result = null;
            Random r = new Random();
            do
            {
                //Uzme polovinu slicnih pitanja nalik na trenutna pitanja 
                foreach (var existingQuestion in ShuffleOps.ShuffleCopy<Question>(questions,r).Take(this.Length / 2))
                {
                    var sameQ = da.GetQuestionsWhichContainDomains(existingQuestion.GetDomainIds());
                    questionsNova.Add(sameQ[r.Next(sameQ.Count)]);
                }

                //Ostatk pitanja uzme iz celokupne banke nasumicno
                questionsNova.AddRange(ShuffleOps.ShuffleCopy<Question>(da.GetAllQuestions(), r).Take(this.Length));

                questionsNova = questionsNova.Distinct().ToList();
                ShuffleOps.ShuffleInPlace<Question>(questionsNova, r);
                questionsNova = questionsNova.Take(Length).ToList();

                result = new Test(questionsNova, Length);
            }
            while (result.HasDuplicate());

            return result;
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

        public int QuestionsCoitansDomain(int domainId)
        {
            int res = 0;
            foreach (var q in questions)
            {
                if (q.ContainsDomain(domainId))
                    res++;
            }
            return res;
        }
        public int QuestionsDomainDifficulty(int domainId, int difficulty)
        {
            int res = 0;
            foreach (var q in questions)
            {
                if (q.GetDifficultyForDomain(domainId) == difficulty)
                    res++;
            }
            return res;
        }

        public float GetDomainAmount(int domainId)
        {
            float result = 0;
            foreach (var q in questions)
            {
                if (q.ContainsDomain(domainId))
                    result += 1;
            }
            result /= questions.Count;

            return result;
        }

        public bool HasDuplicate()
        {
            bool duplikat = false;
            if (questions.Count < Length)
                duplikat = true;
            for (int i = 0; i < questions.Count && !duplikat; i++)
                for (int j = i + 1; j < questions.Count; j++)
                    if (questions[i].Id == questions[j].Id)
                        duplikat = true;
            return duplikat;
        }

    }
}
