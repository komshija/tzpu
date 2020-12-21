using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Test
    {

        List<Question> questions;

        public Test(int lenght)
        {
            questions = new List<Question>(lenght);
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
    }
}
