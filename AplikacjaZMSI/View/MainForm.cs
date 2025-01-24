using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaZMSI
{
    public partial class MainForm : Form
    {
        public event Action<double, double, double> OnSolve;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelAlgorithmParameters.Visible = false;
            panelAlgorithmSelection.Visible = true;
        }

        private void buttonNextConfiguration_Click(object sender, EventArgs e)
        {
            panelAlgorithmSelection.Visible = false;
            panelAlgorithmParameters.Visible = true;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            // Pobierz wartości z suwaków
            double alpha = trackBarAlpha.Value / 10.0; // Skalowanie
            double delta = trackBarDelta.Value / 10.0;
            double beta = trackBarBeta.Value / 10.0;

            // Wywołanie zdarzenia Solve z parametrami
            OnSolve?.Invoke(alpha, delta, beta);
        }

        // Metoda do wyświetlania wyników
        public void DisplayResults(double fBest, double[] xBest)
        {
            lblResult.Text = $"Najlepsze f(X): {fBest:F4}\nX = [{string.Join(", ", xBest)}]";
        }
    }
}
