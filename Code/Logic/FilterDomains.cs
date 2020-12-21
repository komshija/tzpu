using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using GeneticSharp;

namespace Logic
{
    public class FilterDomains
    {
        private IDataAccess bank;
        public FilterDomains()
        {
            bank = DataAccess.DataAccess.GetInstance();

        }
    }
}
