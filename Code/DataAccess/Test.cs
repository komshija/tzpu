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
        #region Attributes
        public List<Question> questions { get; protected set; }
        #endregion

        #region Constructors
        public Test(List<Question> qs, int lenght) : base(lenght)
        {
            questions = qs;
            this.CreateGenes();
        }
        #endregion

        #region Overrides
        public override IChromosome CreateNew()
        {
            return new Test(new List<Question>(questions), Length); ;
        }

        public override Gene GenerateGene(int geneIndex)
        {
            return new Gene(questions[geneIndex]);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var q in questions)
                result.AppendLine(q.ToString());
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            List<Question> pitanja = new List<Question>();
            Test test = obj as Test;

            foreach (var q in this.questions)
            {
                pitanja.Add(q);
            }

            foreach (var q in test.questions)
            {
                pitanja.Add(q);
            }

            if (pitanja.Distinct().ToList().Count == test.questions.Count)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int id = 0;
            foreach (var q in this.questions)
            {
                id = (id + q.Id) % 1013;
            }

            return id;
        }
        #endregion

        #region Methods
     
        public double BrojPitanjaKojaSadrzeOblast(int domainId)
        {
            return Convert.ToDouble(questions.Count(q => q.ContainsDomain(domainId)));
        }

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

        #endregion
    }
}
