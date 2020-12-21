using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class DataAccess : IDataAccess
    {
        #region Singleton
        private static DataAccess _instance = null;

        public static DataAccess GetInstance()
        {
            if (_instance == null)
                _instance = new DataAccess();
            return _instance;
        }
        protected DataAccess()
        {
            questions = new List<Question>();
            InitQuestionsRandom();
        }

        #endregion

        #region Properties


        private List<Question> questions;

        public List<Question> Questions
        {
            get { return questions; }
        }

        #endregion

        #region Methods

        public Question GetQuestionById(int id)
        {
            return questions.Find(q => q.Id == id);
        }

        public List<Question> GetQuestionsByOverallDifficulty(double difficulty, double tolerance)
        {
            var result = questions.Where(q => (q.GetOverallDifficulty() >= difficulty - tolerance && q.GetOverallDifficulty() <= difficulty + tolerance)).ToList();
            return result;
        }

        public List<Question> GetQuestionsWhichContainsDomain(int domainId)
        {
            var result = questions.Where(q => q.ContainsDomain(domainId)).ToList();
            return result;
        }

        public List<Question> GetQuestionsWhichContainDomains(List<int> domainIds)
        {
            List<Question> result = new List<Question>();
            foreach (int domainId in domainIds)
            {
                result.AddRange(questions.Where(q => q.ContainsDomain(domainId)).ToList());
            }
            return result.Distinct().ToList();
        }

        public List<Question> GetQuestionsHarderThen(Question question)
        {
            var result = questions.Where(q => q.GetOverallDifficulty() >= question.GetOverallDifficulty()).ToList();
            return result;
        }

        public List<Question> GetQuestionsEasierThen(Question question)
        {
            var result = questions.Where(q => q.GetOverallDifficulty() <= question.GetOverallDifficulty()).ToList();
            return result;
        }

        public List<Question> GetQuestionsEqualDifficultyWith(Question question, double tolerance)
        {
            double difficulty = question.GetOverallDifficulty();
            var result = questions.Where(q => (q.GetOverallDifficulty() >= difficulty - tolerance && q.GetOverallDifficulty() <= difficulty + tolerance)).ToList();
            return result;
        }

        public List<Question> GetQuestionsDomainDifficulty(int domainId, int difficulty)
        {
            var result = questions.Where(q => q.ContainsDomain(domainId) && q.GetDifficultyForDomain(domainId) == difficulty).ToList();
            return result;
        }


        public List<Question> GetAllQuestions()
        {
            return questions;
        }

        #endregion

        #region Private Methods
        private void InitQuestionsRandom()
        {
            Dictionary<int, string> namesOfDomains = new Dictionary<int, string>(5);
            namesOfDomains.Add(1, "Nizovi");
            namesOfDomains.Add(2, "Algoritmi");
            namesOfDomains.Add(3, "Funkcije");
            namesOfDomains.Add(4, "Fajlovi");
            namesOfDomains.Add(5, "Matrice");
            Random rnd = new Random(69420);
            int NumOfQuestions = 1000;
            for (int i = 0; i < NumOfQuestions; i++)
            {
                int numOfDomains = 1 + rnd.Next(5); // random oblasti od 1 do 5
                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domainId = 1 + rnd.Next(5);
                    if (!difficulties.Exists(d => d.DomainID == domainId))
                    {
                        int domainDifficulty = 1 + rnd.Next(5);
                        difficulties.Add(new Difficulty(domainId, namesOfDomains[domainId], domainDifficulty));
                    }
                }
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }

        }
        #endregion
    }
}
