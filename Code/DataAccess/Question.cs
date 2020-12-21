using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class Question
    {
        #region Atributtes
        private List<Difficulty> difficulties;
        private string text;
        private int id;

        #endregion


        #region Properties
        public List<Difficulty> Difficulties
        {
            get { return difficulties; }
            set { difficulties = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        #endregion

        public Question(int id,string text,List<Difficulty> difficulties)
        {
            this.id = id;
            this.text = text;
            this.difficulties = difficulties;
        }


        #region Overrides


        public override string ToString()
        {
            StringBuilder s = new StringBuilder($"{id} :: Tekst: {text} :: ");
            foreach(Difficulty d in difficulties)
                s.Append(d.ToString() + " ");
            return s.ToString();
        }

        public override bool Equals(object obj)
        {
            if(obj is Question)
            {
                Question q = (Question)obj;
                return q.id == this.id;
            }
            return false;
        }
        #endregion

        #region Methods

        public int GetDifficultyForDomain(int _domainID)
        {
            var result = difficulties.Where(q => q.DomainID == _domainID).SingleOrDefault();
            if (result == null)
                return -1;
            return result.DomainDifficulty;
        }

        public double GetOverallDifficulty()
        {
            //Algoritam je podlozan promenama, za sad samo prosek
            return difficulties.Average(x => x.DomainDifficulty);
        }

        public bool ContainsDomain(int _domainId)
        {
            return difficulties.Exists(x => x.DomainID == _domainId);
        }

        public List<int> GetDomainIds()
        {
            return difficulties.Select(x => x.DomainID).ToList();
        }
        #endregion

    }
}
