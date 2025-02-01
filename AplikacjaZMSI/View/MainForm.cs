using AplikacjaZMSI.Model;
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

            comboBoxAlgorithms.DataSource = algorithms;
            comboBoxAlgorithms.DisplayMember = "Name";

            comboBoxAlgorithms.SelectedIndexChanged += comboBoxAlgorithms_SelectedIndexChanged;

            // Zdarzenie na zmianę funkcji testowej
            comboBoxTestFunctions.SelectedIndexChanged += (sender, e) =>
            {
                Console.WriteLine($"Wybrano funkcję testową: {SelectedTestFunction}");
            };
            comboBoxTestFunctions1.SelectedIndexChanged += (sender, e) =>
            {
                Console.WriteLine($"Wybrano funkcję testową: {SelectedTestFunctionMulti}");
            };
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

        private void GenerateParameterControls(IOptimizationAlgorithm selectedAlgorithm)
        {
            foreach (var trackBar in dynamicTrackBars)
            {
                panelParameters.Controls.Remove(trackBar);
            }
            dynamicTrackBars.Clear();

            int yOffset = 100;
            foreach (var param in selectedAlgorithm.ParamsInfo)
            {
                var label = new Label
                {
                    Text = param.Name,
                    Location = new Point(20, yOffset),
                    Font = new Font("Consolas", 12),
                    AutoSize = true
                };
                panelParameters.Controls.Add(label);

                var trackBar = new TrackBar
                {
                    Minimum = (int)(param.LowerBoundary * 10),
                    Maximum = (int)(param.UpperBoundary * 10),
                    TickFrequency = 1,
                    Location = new Point(200, yOffset),
                    Width = 300
                };
                dynamicTrackBars.Add(trackBar);
                panelParameters.Controls.Add(trackBar);

                yOffset += 60;
            }
        }

        private void buttonNextConfiguration_Click(object sender, EventArgs e)
        {
            panelAlgorithmSelection.Visible = false;
            panelAlgorithmConfiguration.Visible = true;

            GenerateParameterControls((IOptimizationAlgorithm)comboBoxAlgorithms.SelectedItem);
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
                // Label z nazwą i zakresem
                var label = new Label
                {
                    Text = $"{param.Name} (Min: {param.LowerBoundary}, Max: {param.UpperBoundary})",
                    AutoSize = true
                };
                panelParameters.Controls.Add(label);

                // Suwak
                var trackBar = new TrackBar
                {
                    Minimum = (int)(param.LowerBoundary * 10),
                    Maximum = (int)(param.UpperBoundary * 10),
                    Value = (int)(param.LowerBoundary * 10),
                    TickFrequency = 10,
                    Tag = param // Przechowuj informacje o parametrze w suwaku
                };
                panelParameters.Controls.Add(trackBar); 

                // Label z aktualną wartością
                var valueLabel = new Label
                {
                    Text = $"{param.LowerBoundary}",
                    AutoSize = true
                };
                trackBar.Scroll += (sender, e) =>
                {
                    var tb = sender as TrackBar;
                    valueLabel.Text = (tb.Value / 10.0).ToString("F1");
                };
                panelParameters.Controls.Add(valueLabel);

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

        }
    }
}
