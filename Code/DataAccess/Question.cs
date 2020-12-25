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
            StringBuilder s = new StringBuilder();
            if (id < 100)
                s.Append($"{id}   :: ");
            else if(id <1000)
                s.Append($"{id}  :: ");
            else
                s.Append($"{id} :: ");

            foreach(Difficulty d in difficulties.OrderBy(x => x.DomainID))
                s.Append(d.DomainID + "\t");
            //s.Append(d.ToString() + "\t"); ;
            //s.Append($" :: Overall Diff : {this.GetOverallDifficulty()}");
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


        public override int GetHashCode()
        {
            return id;
        }


        #endregion

        #region Methods


        public double GetOverallDifficulty()
        {
            return difficulties.Average(x => x.DomainDifficulty);
        }

        public bool ContainsDomain(int domainId)
        {
            return difficulties.Exists(x => x.DomainID == domainId);
        }

        public bool HaveAllDomains(List<int> domains)
        {
            List<int> ostaleOblasti = DataAccess.GetInstance().GetAllDomains().ToList().Except(domains).ToList();
            bool result = difficulties.All(d => domains.Contains(d.DomainID) && !ostaleOblasti.Contains(d.DomainID));
            return result;
        }

        public List<int> GetDomainIds()
        {
            return difficulties.Select(x => x.DomainID).ToList();
        }
        #endregion

    }
}
