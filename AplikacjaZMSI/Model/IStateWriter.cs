using AplikacjaZMSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaZMSI
{
    interface IStateWriter
 {
 // Metoda zapisuj ąca do pliku tekstowego stan algorytmu (w odpowiednim formacie).
 // Stan algorytmu : numer iteracji , liczba wywo łań funkcji celu ,
 // populacja wraz z warto ścią funkcji dopasowania
 void SaveToFileStateOfAlghoritm(string path);
 }

 interface IStateReader
 {
    // Metoda wczytuj ąca z pliku stan algorytmu (w odpowiednim formacie ).
 // Stan algorytmu : numer iteracji , liczba wywo łań funkcji celu ,
 // populacja wraz z warto ścią funkcji dopasowania
 void LoadFromFileStateOfAlghoritm(string path);
     }


 interface IGeneratePDFReport
 {
    // Tworzy raport w okre ś lonym stylu w formacie PDF
 // w raporcie powinny znale źć się informacje o:
 // najlepszym osobniku wraz z warto ścią funkcji celu ,
 // liczbie wywo łań funkcji celu ,
 // parametrach algorytmu
 void GenerateReport(string path);
     }

 interface IGenerateTextReport
{
     // Tworzy raport w postaci łań cucha znak ów
 // w raporcie powinny znale źć się informacje o:
 // najlepszym osobniku wraz z warto ścią funkcji celu ,
 // liczbie wywo łań funkcji celu ,
 // parametrach algorytmu
 string ReportString { get; private set; }
 }

 // na poziomie namespace
 public delegate double fitnessFunction(params double[] arg);

// opis pojedynczego parametru algorytmu , warto ść jest zmienn ą typu double
 class ParamInfo
 {
     string Name { get; private set;}
 string Description { get; private set; }
 double UpperBoundary { get; set; }
 double LowerBoundary { get; set; }
 }

 interface IOptimizationAlgorithm
 {
   // Nazwa algorytmu
 string Name { get; set; }

 // Metoda zaczynaj ąca rozwi ą zywanie zagadnienia poszukiwania minimum funkcjicelu.
 // Jako argument przyjmuje :
 // funkcj ę celu ,
 // dziedzin ę zadania w postaci tablicy 2D,
 // list ę pozosta łych wymaganych parametr ów algorytmu ( tylko warto ści , w kolejności takiej jak w ParamsInfo ).
 // Po wykonaniu ustawia odpowiednie właś ciwo ści: XBest , Fbest ,
//NumberOfEvaluationFitnessFunction
 void Solve(fitnessFunction f, double[2, ] domain, params double[] parameters);
    
 // Lista informacji o kolejnych parametrach algorytmu
 ParamInfo[] ParamsInfo { get; set; }
    
 // Obiekt odpowiedzialny za zapis stanu algorytmu do pliku
 // Po każ dej iteracji algorytmu , powinno się wywo łać metod ę
 // SaveToFileStateOfAlghoritm tego obiektu w celu zapisania stanu algorytmu
 IStateWriter writer { get; set; }
   
 // Obiekt odpowiedzialny za odczyt stanu algorytmu z pliku
 // Na pocz ątku metody Solve , obiekt ten powinien wczyta ć stan algorytmu
 // jeśli stan zosta ł zapisany
 IStateReader reader { get; set; }
    
 // Obiekt odpowiedzialny za generowanie napisu z raportem
 IGenerateTextReport stringReportGenerator { get; set; }
    
 // Obiekt odpowiedzialny za generowanie raportu do pliku pdf
 IGeneratePDFReport pdfReportGenerator { get; set; }
    
 // Właś ciow ść zwracaj ąca tablic ę z najlepszym osobnikiem
 double[] XBest { get; set; }
    
 // Właś ciwo ść zwracaj ąca warto ść funkcji dopasowania dla najlepszego osobnika
 double FBest { get; set; }
   
 // Właś ciwo ść zwracaj ąca liczb ę wywo łań funkcji dopasowania
   //  int NumberOfEvaluationFitnessFunction { get; set; }
     }
}
