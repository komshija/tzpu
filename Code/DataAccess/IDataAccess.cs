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
        /// Vraca sva pitanja.
        /// </summary>
        /// <returns></returns>
        List<Question> GetAllQuestions();
        IChromosome GenerisiRandomTestSaOblastima(List<int> oblasti, int Length);
        List<int> GetAllDomains();
    }
}
