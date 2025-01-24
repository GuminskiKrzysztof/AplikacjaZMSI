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
        private readonly AquilaOptimizer optimizer;

        public MainPresenter(MainForm view)
        {
            this.view = view;
            optimizer = new AquilaOptimizer();

            // Subskrybuj zdarzenie Solve z widoku
            view.OnSolve += RunAlgorithm;
        }

        private void RunAlgorithm(double alpha, double delta, double beta)
        {
            Console.WriteLine($"Uruchamiam algorytm z parametrami: alpha={alpha}, delta={delta}, beta={beta}");
            // Ustawienie parametrów algorytmu
            double[,] domain = new double[,] { { -10, 10 }, { -10, 10 } }; // Przykładowy zakres
            Func<double[], double> fitnessFunction = x =>
            {
                // Przykładowa funkcja celu (np. funkcja kwadratowa)
                return Math.Pow(x[0], 2) + Math.Pow(x[1], 2);
            };

            Console.WriteLine("Rozpoczynam Aquila Optimizer...");
            try
            {
                // Uruchom algorytm
                optimizer.Solve(fitnessFunction, domain, alpha, delta, beta);
                Console.WriteLine($"Najlepsze rozwiązanie: f(X) = {optimizer.FBest}, X = [{string.Join(", ", optimizer.XBest)}]");
                // Przekaż wyniki do widoku
                view.DisplayResults(optimizer.FBest, optimizer.XBest);
                Console.WriteLine("Zakończono optymalizację.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
