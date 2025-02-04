using AplikacjaZMSI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
        public event Action<int> OnMulti;
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

            buttonNextConfiguration.Enabled = false;
            btnSolve.Enabled = false;
            btnMultiSolve.Enabled = false;

            comboBoxAlgorithms.SelectedIndexChanged += comboBoxAlgorithms_SelectedIndexChanged;
            comboBoxTestFunctions.SelectedIndexChanged += comboBoxTestFunctions_SelectedIndexChanged;
            comboBoxTestFunctions1.SelectedIndexChanged += comboBoxTestFunctions1_SelectedIndexChanged;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;


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
            OnMulti += aaa;

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
            var selectedAlgorithm = comboBoxAlgorithms.SelectedItem as IOptimizationAlgorithm;

            if (selectedAlgorithm != null)
            {
                Console.WriteLine($"Wybrano algorytm: {selectedAlgorithm.Name}");
                buttonNextConfiguration.Enabled = true;
            }
            else
            {
                buttonNextConfiguration.Enabled = false;
            }

            OnAlgorithmSelected?.Invoke(selectedAlgorithm);
        }

        public void UpdateParameterConfiguration(string labelText, ParamInfo[] parameters)
        {
            labelConfiguration.Text = labelText;

            panelParameters.Controls.Clear();
            dynamicTrackBars.Clear();

            // FlowLayoutPanel zapewni odpowiednie układanie parametrów w pionie
            panelParameters.AutoScroll = true; // Umożliwia przewijanie w przypadku wielu parametrów
            panelParameters.FlowDirection = FlowDirection.TopDown; // Układ w pionie
            panelParameters.WrapContents = false; // Bez zawijania (będzie przewijać się w pionie)

            foreach (var param in parameters)
            {
                // Kontener dla parametru
                var paramPanel = new Panel
                {
                    Padding = new Padding(5),
                    Margin = new Padding(5),
                    Width = panelParameters.ClientSize.Width - 30, // Cała szerokość dostępnego panelu
                    Height = 80,
                    BackColor = Color.LightGray // Zmiana na jaśniejsze tło, zamiast ramki
                };

                // Nazwa parametru (szerokość ustawiona na sztywno)
                var label = new Label
                {
                    Text = param.Name,
                    AutoSize = false,
                    Width = 80,  // Stała szerokość dla nazw parametrów
                    Height = 25,
                    Location = new Point(5, 30),
                    Font = new Font("Consolas", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                paramPanel.Controls.Add(label);

                // Suwak
                var trackBar = new TrackBar
                {
                    Minimum = (int)(param.LowerBoundary * 10),
                    Maximum = (int)(param.UpperBoundary * 10),
                    Value = (int)(param.LowerBoundary * 10),
                    TickFrequency = 10,
                    Tag = param,
                    Width = paramPanel.Width - 170, // Dopasowanie szerokości do panelu
                    Location = new Point(label.Right + 20, 30) // Suwak zaraz obok etykiety
                };
                paramPanel.Controls.Add(trackBar);

                // Min wartość (z lewej strony suwaka)
                var minLabel = new Label
                {
                    Text = $"{param.LowerBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(trackBar.Left - 35, trackBar.Top + 25),
                    Font = new Font("Consolas", 10)
                };
                paramPanel.Controls.Add(minLabel);

                // Max wartość (z prawej strony suwaka)
                var maxLabel = new Label
                {
                    Text = $"{param.UpperBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(trackBar.Right + 2, trackBar.Top + 25), // Przesunięcie w prawo
                    Font = new Font("Consolas", 10)
                };
                paramPanel.Controls.Add(maxLabel);

                // Aktualna wartość (nad suwakiem)
                var valueLabel = new Label
                {
                    Text = $"{param.LowerBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(trackBar.Left, trackBar.Top - 20),
                    Font = new Font("Consolas", 10),
                    BackColor = Color.LightYellow // Opcjonalnie dla lepszej widoczności
                };
                paramPanel.Controls.Add(valueLabel);

                // Dynamiczne przesuwanie etykiety wartości
                trackBar.Scroll += (sender, e) =>
                {
                    var tb = sender as TrackBar;
                    double currentValue = tb.Value / 10.0;
                    valueLabel.Text = currentValue.ToString("F1");

                    // Pobranie szerokości suwaka i jego przesunięcia wewnętrznego
                    int trackBarRange = tb.Maximum - tb.Minimum;
                    int trackBarWidth = tb.Width - 10; // Odejmujemy marginesy po bokach

                    // Obliczenie dokładnej pozycji
                    int relativePosition = (int)((tb.Value - tb.Minimum) / (double)trackBarRange * trackBarWidth);

                    // Wyśrodkowanie wartości nad suwakiem
                    int labelCenterX = tb.Left + relativePosition - (valueLabel.Width / 2) + 5; // Dodajemy małą korektę
                    valueLabel.Location = new Point(labelCenterX, tb.Top - 20);
                };

                // Dodaj do głównego kontenera
                panelParameters.Controls.Add(paramPanel);
                dynamicTrackBars.Add(trackBar);
            }
        }

        private void comboBoxTestFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSolve.Enabled = comboBoxTestFunctions.SelectedItem != null;
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
            lblResult.Text = $"Najlepsze f(X): {fBest}\nX = [{string.Join(", ", xBest)}]";
        }

        private void btnMultiSolve_Click(object sender, EventArgs e)
        {
            OnMulti?.Invoke(1);
           
        }
        
        private void aaa(int a)
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
       

        private void UpdateMultiSolveButtonState()
        {
            btnMultiSolve.Enabled = comboBoxTestFunctions1.SelectedItem != null && checkedListBox1.CheckedItems.Count > 0;
        }

        private void comboBoxTestFunctions1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMultiSolveButtonState();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Aktualizacja po krótkim czasie, ponieważ CheckedItems jeszcze się nie zaktualizowało
            BeginInvoke((Action)(() => UpdateMultiSolveButtonState()));
        }
    }
}
