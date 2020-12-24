using GeneticSharp.Domain.Chromosomes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataAccess 
    {
        /// <summary>
        /// Trazi pitanje po Id-ju
        /// </summary>
        /// <param name="id">Id pitanja koje se trazi</param>
        /// <returns>Vraca pitanje</returns>
        Question GetQuestionById(int id);

        /// <summary>
        /// Trazi pitanja koja imaju ukupnu tezinu sa nekom tolerancijom.
        /// </summary>
        /// <param name="difficulty">Tezina koja se trazi</param>
        /// <param name="tolerance">Tolerancija na tezinu</param>
        /// <returns>Vraca listu pitanja</returns>
        List<Question> GetQuestionsByOverallDifficulty(double difficulty,double tolerance);

        /// <summary>
        /// Trazi pitanja koja sadrze odredjenu oblast.
        /// </summary>
        /// <param name="domainId">Id oblasti</param>
        /// <returns>Lista pitanja koja sadrzi oblast</returns>
        List<Question> GetQuestionsWhichContainsDomain(int domainId);

        /// <summary>
        /// Trazi pitanja koja sadrze vise oblasti.
        /// </summary>
        /// <param name="domainIds">Lista koja sadrzi identifikatore oblasti.</param>
        /// <returns>Lista pitanja koja sadrze trazene oblasti.</returns>
        List<Question> GetQuestionsWhichContainDomains(List <int> domainIds);

        /// <summary>
        /// Trazi pitanja koja su teza od zadatog pitanja po ukupnoj tezini.
        /// </summary>
        /// <param name="question">Pitanje koje se uporedjuje</param>
        /// <returns>Lista pitanja koja su teza</returns>
        List<Question> GetQuestionsHarderThen(Question question);

        /// <summary>
        /// Trazi pitanja koja su laksa od zadatog pitanja po ukupnoj tezini.
        /// </summary>
        /// <param name="question">Pitanje koje se uporedjuje</param>
        /// <returns>Lista pitanja koja su laksa</returns>
        List<Question> GetQuestionsEasierThen(Question question);

        /// <summary>
        /// Trazi pitanja koja su otprilike iste tezine kao zadato pitanje po ukupnoj tezini.
        /// </summary>
        /// <param name="question">Pitanje koje se uporedjuje</param>
        /// <param name="tolerance">Tolerancija na tezinu</param>
        /// <returns>Lista pitanja koja su otprilike iste tezine.</returns>
        List<Question> GetQuestionsEqualDifficultyWith(Question question,double tolerance);

        /// <summary>
        /// Trazi pitanja koja za odredjnu oblast imaju zadatu tezinu
        /// </summary>
        /// <param name="domainId">Oblast koja se trazi</param>
        /// <param name="difficulty">Tezina za tu oblast</param>
        /// <returns>Lista lista pitanja koja imaju zadatu tezinu da neku oblast.</returns>
        List<Question> GetQuestionsDomainDifficulty(int domainId, int difficulty);

        /// <summary>
        /// Vraca sva pitanja.
        /// </summary>
        /// <returns></returns>
        List<Question> GetAllQuestions();
        IChromosome GenerisiRandomTestSaOblastima(List<int> oblasti, int Length);
        List<int> GetAllDomains();
    }
}
