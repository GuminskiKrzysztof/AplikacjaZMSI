using AplikacjaZMSI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaZMSI
{
    public partial class MainForm : Form
    {
        private List<IOptimizationAlgorithm> algorithms;
        private List<TrackBar> dynamicTrackBars = new List<TrackBar>();

        public string SelectedTestFunction => comboBoxTestFunctions.SelectedItem?.ToString();
        public string SelectedTestFunctionMulti => comboBoxTestFunctions1.SelectedItem?.ToString();

        public event Action<double[]> OnSolve;
        public event Action<IOptimizationAlgorithm> OnAlgorithmSelected;

        public MainForm()
        {
            InitializeComponent();

            algorithms = new List<IOptimizationAlgorithm>
            {
                new AquilaOptimizer(),
                new BOAAlgorithm()
            };

            comboBoxAlgorithms.SelectedIndexChanged -= comboBoxAlgorithms_SelectedIndexChanged;

            comboBoxAlgorithms.DataSource = algorithms;
            comboBoxAlgorithms.DisplayMember = "Name";

            comboBoxAlgorithms.SelectedIndex = -1;

            comboBoxAlgorithms.SelectedIndexChanged += comboBoxAlgorithms_SelectedIndexChanged;

            // Zdarzenie na zmianę funkcji testowej
            comboBoxTestFunctions.SelectedIndexChanged += (sender, e) =>
            {
                Console.WriteLine($"Wybrano funkcję testową: {SelectedTestFunction}");
            };
            comboBoxTestFunctions1.SelectedIndexChanged += (sender, e) =>
            {
                Console.WriteLine($"Wybrano funkcję testową1: {SelectedTestFunctionMulti}");
            };
            checkedListBox1.Items.Add("AO");
            checkedListBox1.Items.Add("BOA");
        }

 

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle text and background color based on state
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Unit test";
                checkBox1.BackColor = Color.LightPink;
                panel1.Visible = false;
                panel1.Enabled = false;
                panel2.Visible = true;
                panel2.Enabled = true;
            }
            else
            {
                checkBox1.Text = "Group test";
                checkBox1.BackColor = Color.LightSalmon;
                panel1.Visible = true;
                panel1.Enabled = true;
                panel2.Visible = false;
                panel2.Enabled = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelAlgorithmConfiguration.Visible = false;
            panelAlgorithmSelection.Visible = true;
        }

        private void buttonNextConfiguration_Click(object sender, EventArgs e)
{
    panelAlgorithmSelection.Visible = false;
    panelAlgorithmConfiguration.Visible = true;

    var selectedAlgorithm = (IOptimizationAlgorithm)comboBoxAlgorithms.SelectedItem;

    // Używamy nazwy algorytmu jako labelText
    var labelText = $"Konfiguracja parametrów dla {selectedAlgorithm.Name}";

    // Parametry algorytmu do przekazania (odwołanie do ParamsInfo)
    var parameters = selectedAlgorithm.ParamsInfo;

    // Wywołanie UpdateParameterConfiguration z dwoma wymaganymi argumentami
    UpdateParameterConfiguration(labelText, parameters);
}

        private bool UpdateProgressBar(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = value));
            }
            else
            {
                progressBar1.Value = value;
            }
            return true;
        }


        private void comboBoxAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedAlgorithm = (IOptimizationAlgorithm)comboBoxAlgorithms.SelectedItem;
            Console.WriteLine($"Wybrano algorytm: {selectedAlgorithm.Name}");
            OnAlgorithmSelected?.Invoke(selectedAlgorithm);
        }

        public void UpdateParameterConfiguration(string labelText, ParamInfo[] parameters)
        {
            labelConfiguration.Text = labelText;

            panelParameters.Controls.Clear();
            dynamicTrackBars.Clear();

            foreach (var param in parameters)
            {
                var panel = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 50
                };

                var label = new Label
                {
                    Text = param.Name,
                    AutoSize = true,
                    Location = new Point(0, 5)
                };
                panel.Controls.Add(label);

                var minLabel = new Label
                {
                    Text = $"{param.LowerBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(0, 25)
                };
                panel.Controls.Add(minLabel);

                var trackBar = new TrackBar
                {
                    Minimum = (int)(param.LowerBoundary * 10),
                    Maximum = (int)(param.UpperBoundary * 10),
                    Value = (int)(param.LowerBoundary * 10),
                    TickFrequency = 10,
                    Tag = param,
                    Width = 200,
                    Location = new Point(80, 10)
                };
                panel.Controls.Add(trackBar);

                var maxLabel = new Label
                {
                    Text = $"{param.UpperBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(trackBar.Width + 100, 25)
                };
                panel.Controls.Add(maxLabel);

                // Etykieta z aktualną wartością - ustawiona obok suwaka
                var valueLabel = new Label
                {
                    Text = $"{param.LowerBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(trackBar.Right + 10, 15) // Na prawo od suwaka
                };
                panel.Controls.Add(valueLabel);

                // Aktualizacja wartości i przesuwanie etykiety
                trackBar.Scroll += (sender, e) =>
                {
                    var tb = sender as TrackBar;
                    double currentValue = tb.Value / 10.0;
                    valueLabel.Text = currentValue.ToString("F1");

                    // Przesunięcie etykiety dynamicznie zgodnie z pozycją suwaka
                    valueLabel.Location = new Point(tb.Left + tb.Width + 10, tb.Top + 5);
                };

                panelParameters.Controls.Add(panel);
                dynamicTrackBars.Add(trackBar);
            }
        }


        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (comboBoxAlgorithms.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać algorytm przed rozpoczęciem testowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parameterValues = dynamicTrackBars.Select(tb => tb.Value / 10.0).ToArray();
            OnSolve?.Invoke(parameterValues);
        }

        // Metoda do wyświetlania wyników
        public void DisplayResults(double fBest, double[] xBest)
        {
            lblResult.Text = $"Najlepsze f(X): {fBest:F4}\nX = [{string.Join(", ", xBest)}]";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Func<int, bool> update = UpdateProgressBar;
            MultiTest testMulti = new MultiTest(update);
            List<string> checkedItemsList = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                checkedItemsList.Add(item.ToString());
            }

            testMulti.run(SelectedTestFunctionMulti, checkedItemsList);
        }
    }
}
