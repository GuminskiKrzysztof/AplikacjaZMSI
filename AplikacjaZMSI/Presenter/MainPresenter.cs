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

            // Pobranie wybranej funkcji testowej z widoku
            string selectedTestFunctionName = view.SelectedTestFunction;
            Func<double[], double> fitnessFunction;

            switch (selectedTestFunctionName)
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
                    throw new InvalidOperationException("Nieznana funkcja testowa.");
            }


            Console.WriteLine($"Uruchamiam algorytm {selectedAlgorithm} z funkcją {selectedTestFunctionName} i parametrami: {string.Join(", ", parameters)}");

            // Ustawienie parametrów algorytmu
            double[,] domain = new double[,] { { -10, 10 }, { -10, 10 } }; // Przykładowy zakres
            try
            {
                // Uruchom algorytm
                selectedAlgorithm.init(fitnessFunction, domain, parameters);
                selectedAlgorithm.Solve();
                Console.WriteLine($"Najlepsze rozwiązanie: f(X) = {selectedAlgorithm.FBest}, X = [{string.Join(", ", selectedAlgorithm.XBest)}]");
                // Przekaż wyniki do widoku
                view.DisplayResults(selectedAlgorithm.FBest, selectedAlgorithm.XBest);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
            
        }


    }
}
