using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Difficulty
    {
        public int DomainID;
        public string DomainName;
        public int DomainDifficulty;

        public Difficulty(int domainID,string  domainName, int domaindiff)
        {
            DomainID = domainID;
            DomainName = domainName;
            DomainDifficulty = domaindiff;
        }

        public override string ToString()
        {
            return $"{DomainName}::{DomainDifficulty}";
        }
    }
}
