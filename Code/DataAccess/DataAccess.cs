using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using MiSe.Shuffle;

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


        public IChromosome GenerisiRandomTestSaOblastima(List<int> oblasti,int Length)
        {
            List<Question> questionsNova = new List<Question>();
            Test result = null;
            Random r = new Random();
            do
            {
                //Bira iz banke nasumicno pitanja samo koja sadrze te oblasti
                var questionsDomain = GetQuestionsWhichContainDomains(oblasti);

                questionsNova.AddRange(ShuffleOps.ShuffleCopy<Question>(questionsDomain, r).Take(Length - questionsNova.Count));
                result = new Test(questionsNova, Length);
            }
            while (result.HasDuplicate());

            return result;
        }

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
            result.AddRange(questions.Where(q => q.Difficulties.Count <= domainIds.Count && q.HaveAllDomains(domainIds) ).ToList());
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

        public List<Question> GetQuestionsDomainDifficulty(int domainBase, int difficulty)
        {
            var result = questions.Where(q => q.ContainsDomain(domainBase + 5 * difficulty)).ToList();
            return result;
        }

        public List<Question> GetAllQuestions()
        {
            return questions;
        }

        public List<int> GetAllDomains()
        {
            List<int> result = new List<int>(15);
            for (int i = 1; i < 16; i++)
                result.Add(i);
            return result;
        }
        #endregion

        #region Private Methods
        private void InitQuestionsRandom()
        {
            Dictionary<int, string> namesOfDomains = new Dictionary<int, string>(5*3);
            namesOfDomains.Add(0, "Nizovi Lako");
            namesOfDomains.Add(1, "Algoritmi Lako");
            namesOfDomains.Add(2, "Funkcije Lako");
            namesOfDomains.Add(3, "Fajlovi Lako");
            namesOfDomains.Add(4, "Matrice Lako");

            namesOfDomains.Add(5, "Nizovi Srednje");
            namesOfDomains.Add(6, "Algoritmi Srednje");
            namesOfDomains.Add(7, "Funkcije Srednje");
            namesOfDomains.Add(8, "Fajlovi Srednje");
            namesOfDomains.Add(9, "Matrice Srednje");

            namesOfDomains.Add(10, "Nizovi Tesko");
            namesOfDomains.Add(11, "Algoritmi Tesko");
            namesOfDomains.Add(12, "Funkcije Tesko");
            namesOfDomains.Add(13, "Fajlovi Tesko");
            namesOfDomains.Add(14, "Matrice Tesko");

            Random rnd = new Random(69420);
            int NumOfQuestions = 5000;

            for (int i = 0; i < NumOfQuestions; i++)
            {
                int numOfDomains = 1+rnd.Next(5); // random oblasti od 1 do 5

                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);

                List<int> domeni = new List<int>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domen = rnd.Next(5);// 0 - 4 
                    if (!domeni.Exists(x => x == domen))
                        domeni.Add(domen);
                    else
                        j--;
                }

                for (int j = 0; j < numOfDomains; j++)
                {
                    int tezina = rnd.Next(3);
                    difficulties.Add(new Difficulty(domeni[j] + 5 * tezina, namesOfDomains[domeni[j] + 5 * tezina], tezina));
                }

                difficulties = difficulties.OrderBy(x => x.DomainID).ToList();
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }



            for (int i = NumOfQuestions; i < NumOfQuestions + 250; i++)
            {
                int numOfDomains = 1;

                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);

                List<int> domeni = new List<int>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domen = rnd.Next(5);// 0 - 4 
                    if (!domeni.Exists(x => x == domen))
                        domeni.Add(domen);
                    else
                        j--;
                }

                for (int j = 0; j < numOfDomains; j++)
                {
                    int tezina = rnd.Next(3);
                    difficulties.Add(new Difficulty(domeni[j] + 5 * tezina, namesOfDomains[domeni[j] + 5 * tezina],tezina));
                }

                difficulties = difficulties.OrderBy(x => x.DomainID).ToList();
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }

            for (int i = NumOfQuestions + 250 ; i < NumOfQuestions + 500; i++)
            {
                int numOfDomains = 2;

                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);

                List<int> domeni = new List<int>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domen = rnd.Next(5);// 0 - 4 
                    if (!domeni.Exists(x => x == domen))
                        domeni.Add(domen);
                    else
                        j--;
                }

                for (int j = 0; j < numOfDomains; j++)
                {
                    int tezina = rnd.Next(3);
                    difficulties.Add(new Difficulty(domeni[j] + 5 * tezina, namesOfDomains[domeni[j] + 5 * tezina],tezina));
                }

                difficulties = difficulties.OrderBy(x => x.DomainID).ToList();
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }

            for (int i = NumOfQuestions + 500; i < NumOfQuestions + 750; i++)
            {
                int numOfDomains = 3;

                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);

                List<int> domeni = new List<int>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domen = rnd.Next(5);// 0 - 4 
                    if (!domeni.Exists(x => x == domen))
                        domeni.Add(domen);
                    else
                        j--;
                }

                for (int j = 0; j < numOfDomains; j++)
                {
                    int tezina = rnd.Next(3);
                    difficulties.Add(new Difficulty(domeni[j] + 5 * tezina, namesOfDomains[domeni[j] + 5 * tezina],tezina));
                }

                difficulties = difficulties.OrderBy(x => x.DomainID).ToList();
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }

            for (int i = NumOfQuestions + 750; i < NumOfQuestions + 1000; i++)
            {
                int numOfDomains = 4;

                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);

                List<int> domeni = new List<int>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domen = rnd.Next(5);// 0 - 4 
                    if (!domeni.Exists(x => x == domen))
                        domeni.Add(domen);
                    else
                        j--;
                }

                for (int j = 0; j < numOfDomains; j++)
                {
                    int tezina = rnd.Next(3);
                    difficulties.Add(new Difficulty(domeni[j] + 5 * tezina, namesOfDomains[domeni[j] + 5 * tezina],tezina));
                }

                difficulties = difficulties.OrderBy(x => x.DomainID).ToList();
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }

            for (int i = NumOfQuestions + 1000; i < NumOfQuestions + 1250; i++)
            {
                int numOfDomains = 5;

                List<Difficulty> difficulties = new List<Difficulty>(numOfDomains);

                List<int> domeni = new List<int>(numOfDomains);
                for (int j = 0; j < numOfDomains; j++)
                {
                    int domen = rnd.Next(5);// 0 - 4 
                    if (!domeni.Exists(x => x == domen))
                        domeni.Add(domen);
                    else
                        j--;
                }

                for (int j = 0; j < numOfDomains; j++)
                {
                    int tezina = rnd.Next(3);
                    difficulties.Add(new Difficulty(domeni[j] + 5 * tezina, namesOfDomains[domeni[j] + 5 * tezina],tezina));
                }

                difficulties = difficulties.OrderBy(x => x.DomainID).ToList();
                questions.Add(new Question(i, $"Pitanje {i}", difficulties));
            }


        }


        #endregion
    }
}
