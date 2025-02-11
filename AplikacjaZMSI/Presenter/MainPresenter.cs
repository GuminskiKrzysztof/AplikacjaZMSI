using AplikacjaZMSI.Model;
using AplikacjaZMSI.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AplikacjaZMSI.Presenter
{
    public class MainPresenter
    {
        private readonly MainForm view;
        private IOptimizationAlgorithm selectedAlgorithm;

        public MainPresenter(MainForm view)
        {
            this.view = view;
            
            view.OnAlgorithmSelected += UpdateSelectedAlgorithm;

            // Subskrybuj zdarzenie Solve z widoku
            view.OnSolve += RunAlgorithm;
           
        }

        private void UpdateSelectedAlgorithm(IOptimizationAlgorithm algorithm)
        {
            selectedAlgorithm = algorithm;

            if (selectedAlgorithm != null)
            {
                view.UpdateParameterConfiguration(
                    $"Konfiguracja parametrów dla {algorithm.Name}",
                    algorithm.ParamsInfo
                );
            }
        }



        private void RunAlgorithm(double[] parameters)
{
    if (selectedAlgorithm == null)
    {
        MessageBox.Show("Nie wybrano algorytmu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // Pobranie listy wybranych funkcji testowych
    List<string> selectedTestFunctions = view.SelectedTestFunctions;

    if (selectedTestFunctions.Count == 0)
    {
        MessageBox.Show("Nie wybrano żadnej funkcji testowej!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    double[,] domain = new double[,] { { -10, 10 }, { -10, 10 } }; // Przykładowy zakres

            view.ClearResults();
            foreach (var functionName in selectedTestFunctions)
    {
                Func<double[], double> fitnessFunction;
                Console.WriteLine(functionName);

                switch (functionName)
                {
                    case "Sphere":
                        fitnessFunction = TestFunction.Sphere;
                        break;
                    case "Rastrigin":
                        fitnessFunction = TestFunction.Rastrigin;
                        break;
                    case "Rosenbrock":
                        fitnessFunction = TestFunction.Rosenbrock;
                        break;
                    case "Beale":
                        fitnessFunction = TestFunction.Beale;
                        break;
                    default:
                        throw new InvalidOperationException($"Nieznana funkcja testowa: {functionName}");
                }

                try
        {
            // Uruchomienie algorytmu dla danej funkcji testowej
            selectedAlgorithm.init(fitnessFunction, domain, parameters);
            selectedAlgorithm.Solve();

            Console.WriteLine($"Algorytm: {selectedAlgorithm.Name}, Funkcja: {functionName}");
            Console.WriteLine($"Najlepsze rozwiązanie: f(X) = {selectedAlgorithm.FBest}, X = [{string.Join(", ", selectedAlgorithm.XBest)}]");

            
            // Przekazanie wyników do widoku
            view.DisplayResults(selectedAlgorithm.FBest, selectedAlgorithm.XBest, functionName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas obliczeń dla {functionName}: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

    }
}
