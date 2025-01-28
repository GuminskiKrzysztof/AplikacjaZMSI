using AplikacjaZMSI.Model;
using AplikacjaZMSI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Console.WriteLine($"Uruchamiam algorytm {selectedAlgorithm} z parametrami: {string.Join(", ", parameters)}");

            // Ustawienie parametrów algorytmu
            double[,] domain = new double[,] { { -10, 10 }, { -10, 10 } }; // Przykładowy zakres
            Func<double[], double> fitnessFunction = x =>
            {
                // Przykładowa funkcja celu (np. funkcja kwadratowa)
                return Math.Pow(x[0], 2) + Math.Pow(x[1], 2);
            };

            try
            {
                // Uruchom algorytm
                selectedAlgorithm.Solve(fitnessFunction, domain, parameters);
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
