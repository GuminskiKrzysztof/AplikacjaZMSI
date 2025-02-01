using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI.View
{
    internal interface IMainView
    {
        //// Właściwości dla interakcji z widokiem
        //string SelectedAlgorithm { get; set; } // np. AO lub BOA
        //string Parameters { get; set; } // np. parametry w formie tekstu

        //// Zdarzenia dla przycisków
        //event EventHandler AlgorithmSelected;
        //event EventHandler StartOptimization;

        // Zdarzenia
        event Action<double[]> OnSolve;
        event Action<IOptimizationAlgorithm> OnAlgorithmSelected;

        // Metody do aktualizacji widoku
        void UpdateParameterConfiguration(string labelText, ParamInfo[] parameters);
        void DisplayResults(double fBest, double[] xBest);


    }
}
