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
            return new Test(new List<Question>(questions), Length); ;
        }
        
       
        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(questions[geneIndex]);
        }

        public double UkupnaTezinaTesta()
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

        //Proveriti..
        public double ProcenatPitanjaKojaSadrzeOblast(int domainId)
        {
            return Convert.ToDouble(questions.Count(q => q.ContainsDomain(domainId))) / Length;
        }

        //Proveriti..
        public List<int> VratiDomeneKojeSadrziTest()
        {
            List<List<Difficulty>> sveTezine = questions.Select(x => x.Difficulties).ToList();
            List<Difficulty> ids = new List<Difficulty>();
            sveTezine.ForEach(lista => ids.AddRange(lista));
            return ids.Select(x=>x.DomainID).Distinct().ToList();
        }
      

        public bool HasDuplicate()
        {
            bool duplikat = false;
            if (questions.Count < Length)
                duplikat = true;
            int distinctCount = questions.Distinct().ToList().Count;
            duplikat = distinctCount != Length;
            return duplikat;
        }

    }
}
