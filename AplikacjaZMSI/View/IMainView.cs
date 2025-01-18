﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI.View
{
    internal interface IMainView
    {
        // Właściwości dla interakcji z widokiem
        string SelectedAlgorithm { get; set; } // np. AO lub BOA
        string Parameters { get; set; } // np. parametry w formie tekstu

        // Zdarzenia dla przycisków
        event EventHandler AlgorithmSelected;
        event EventHandler StartOptimization;
    }
}