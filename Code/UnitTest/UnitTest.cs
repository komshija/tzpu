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

            oblasti = new List<int> { 3, 5, 8, 11 };
            zastupljenost = new List<double> { 0.6, 0.2, 0.4, 0.4 };
            testLength = 5;
            gen = new GeneticAlgorithmUse();
            testovi = new List<Test>();
            for (int i = 0; i < 5; i++)
                testovi.Add(gen.UseAlgorithm(oblasti, zastupljenost, testLength));
        }
        [TestMethod]
        public void Generisano_Je_5_Testa()
        {
            testovi.RemoveAll(t => t == null);
            if (testovi.Count == 0)
                Assert.IsTrue(false, "Lista testova je prazna!");

            Assert.AreEqual(5, testovi.Count, "Nije generisano 3 testa!");
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
                CollectionAssert.AllItemsAreInstancesOfType(testovi, typeof(Test));
        }

        [TestMethod]
        public void Svaki_Test_Ima_Zadat_Broj_Pitanja()
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
            Assert.IsTrue(flag, "Lista testova je prazna!");
        }

        [TestMethod]
        public void Svi_Testovi_Su_Jedinstveni()
        {
            CollectionAssert.AllItemsAreUnique(testovi); // treba se predifinise equal
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

            Assert.IsTrue(flag, "Lista testova je prazna!");
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
            Assert.AreEqual(testovi.Count * testovi[0].questions.Count, pitanja.Distinct().ToList().Count, "Na dva razlicita testa se javilo isto pitanje!");
        }
    }
}
