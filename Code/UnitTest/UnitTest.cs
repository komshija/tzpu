using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        protected GeneticAlgorithmUse gen;
        protected List<Test> testovi;
        protected List<int> oblasti;
        protected List<double> zastupljenost;
        protected int testLength;

        [TestInitialize]
        public virtual void Inicijalizacija()
        {
            #region Oblasti
            //0 - Nizovi Lako
            //1 - Algoritmi Lako
            //2 - Funkcije Lako
            //3 - Fajlovi Lako
            //4 - Matrice Lako

            //5 = 0 + 5 - Nizovi Srednje
            //6 = 1 + 5 - Algoritmi Srednje
            //7 = 2 + 5 - Funkcije Srednje
            //8 = 3 + 5 - Fajlovi Srednje
            //9 = 4 + 5 - Matrice Srednje

            //10 = 0 + 2*5 - Nizovi Tesko
            //11 = 1 + 2*5 - Algoritmi Tesko
            //12 = 2 + 2*5 - Funkcije Tesko
            //13 = 3 + 2*5 - Fajlovi Tesko
            //14 = 4 + 2*5 - Matrice Tesko
            #endregion

            oblasti = new List<int> { 3, 5, 8, 11, 14 };
            zastupljenost = new List<double> { 0.6, 0.2, 0.4, 0.4, 0.4 };
            testLength = 6;
            gen = new GeneticAlgorithmUse();
            testovi = new List<Test>();
            
            List<Question> pitanja = DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomainsAndAreSelected(oblasti);
            if (pitanja.Count != 0)
                foreach (var p in pitanja)
                    p.Izabrano = false;
            
            for (int i = 0; i < 50; i++)
                testovi.Add(gen.UseAlgorithm(oblasti,zastupljenost,testLength));
        }
        [TestMethod]
        public void Kreirano_Je_50_Testova()
        {
            testovi.RemoveAll(t => t == null);
            if (testovi.Count == 0)
                Assert.IsTrue(false, "Lista testova je prazna!");

            Assert.AreEqual(50, testovi.Count, "Nije generisano 50 testova!");
        }

        [TestMethod]
        public void Nijedan_Test_Nije_Null()
        {
            CollectionAssert.AllItemsAreNotNull(testovi, "Postoji test koji je null!");
        }
        [TestMethod]
        public void Svi_Testovi_Su_Tipa_Test()
        {
            testovi.RemoveAll(t => t == null);
            if (testovi.Count == 0)
                Assert.IsTrue(false, "Lista testova je prazna!");
            else
                CollectionAssert.AllItemsAreInstancesOfType(testovi, typeof(Test),"Neki test nije tipa Test!");
        }

        [TestMethod]
        public void Svaki_Test_Ima_Zadatu_Duzinu()
        {
            testovi.RemoveAll(t => t == null);
            if (testovi.Count == 0)
                Assert.IsTrue(false, "Lista testova je prazna!");

            bool flag = true;

            foreach (var test in testovi)
            {
                if (test.Length != 5)
                    flag = false;
            }
            Assert.IsTrue(flag,"Neki test nije zadate duzine!");
        }

        [TestMethod]
        public void Svi_Testovi_Su_Jedinstveni()
        {
            CollectionAssert.AllItemsAreUnique(testovi,"Neki testovi su se pojavili vise puta!");
        }

        [TestMethod]
        public void Nema_Duplikata_Na_Testovima()
        {
            testovi.RemoveAll(t => t == null);
            if (testovi.Count == 0)
                Assert.IsTrue(false, "Lista testova je prazna!");

            bool flag = true;

            foreach (var test in testovi)
            {
                if (test.HasDuplicate())
                    flag = false;
            }

            Assert.IsTrue(flag,"Na nekim testovima ima duplikata!");
        }

        [TestMethod]
        public void Nema_Ponavljanja_Pitanja_U_Skupu_Testova()
        {
            testovi.RemoveAll(t => t == null);
            if (testovi.Count == 0)
                Assert.IsTrue(false, "Lista testova je prazna!");

            List<Question> pitanja = new List<Question>();
            foreach (var test in testovi)
            {
                foreach (var q in test.questions)
                {
                    pitanja.Add(q);
                }
            }
            int ponovljena = testovi.Count * testovi[0].questions.Count - pitanja.Distinct().ToList().Count;
            Assert.AreEqual(0, ponovljena,"Od ukupno "+ testovi.Count * testovi[0].questions.Count + " pitanja na svim testovima, ponovilo se " + ponovljena);
        }
        [TestMethod]
        public void Iskoriscena_Su_Sva_Moguca_Pitanja_Sa_Zadatim_Oblastima()
        {
            List<Question> svaMogucaPitanja = ((DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomains(oblasti)).Union(DataAccess.DataAccess.GetInstance().GetQuestionsWhichContainDomainsAndAreSelected(oblasti))).ToList();
            List<Question> pitanja = new List<Question>();

            foreach (var test in testovi)
            {
                foreach (var q in test.questions)
                {
                    pitanja.Add(q);
                }
            }

            Assert.AreEqual(svaMogucaPitanja.Count, pitanja.Distinct().ToList().Count,"Od mogucih " + svaMogucaPitanja.Count +" pitanja , iskoriscena su "+ pitanja.Distinct().ToList().Count);
        }
        [TestMethod]
        public void Nijedno_Pitanje_Na_Testovima_Nije_Null()
        {
            bool flag = true;

            foreach (var test in testovi)
            {
                if (test.questions.Contains(null))
                {
                    flag = false;
                    break;
                }
            }

            Assert.IsTrue(flag, "Neki test ima pitanje koje je null!");
        }
        [TestMethod]
        public void Svi_Testovi_Zadovoljavaju_Kriterijume()
        {
            TestFitness tf = new TestFitness(oblasti, zastupljenost, 0);
            bool flag = true;
            foreach (var test in testovi)
            {
                if (tf.Evaluate(test) != oblasti.Count)
                {
                    flag = false;
                    break;
                }
            }

            Assert.IsTrue(flag, "Neki test ne ispunjava kriterijume!");
        }
    }
}
