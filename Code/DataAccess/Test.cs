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
            return new Test(questions, Length); ;
        }
        
        public IChromosome GenerateRandomTest(List<int> oblasti)
        {
            IDataAccess da = DataAccess.GetInstance();
            List<Question> questionsNova = new List<Question>();
            Test result = null;
            Random r = new Random();
            do
            {
                //Bira iz banke nasumicno pitanja samo koja sadrze te oblasti
                var questionsDomain = da.GetQuestionsWhichContainDomains(oblasti);

                questionsNova.AddRange(ShuffleOps.ShuffleCopy<Question>(questionsDomain, r).Take(this.Length - questionsNova.Count));
                result = new Test(questionsNova, Length);
            }
            while (result.HasDuplicate());

            return result;
        }


        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(questions[geneIndex]);
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
           // result.AppendLine($"Overall difficulty sum: {GetSumDiff()}");
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

        /// <summary>
        /// Vraca onako kao sto smo pitali, celokupnu zastupljenost oblasti na testu.
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public double GetDomainAmount(int domainId)
        {
            double questionAmount = 1 / Convert.ToDouble(Length);
            double result = 0;
            foreach (var q in questions)
                if (q.ContainsDomain(domainId))
                    result += questionAmount / Convert.ToDouble(q.Difficulties.Count);
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
