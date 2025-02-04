using AplikacjaZMSI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AplikacjaZMSI
{
    public partial class MainForm : Form
    {
        private List<IOptimizationAlgorithm> algorithms;
        private List<TrackBar> dynamicTrackBars = new List<TrackBar>();

        public string SelectedTestFunction => comboBoxTestFunctions.SelectedItem?.ToString();
        public string SelectedTestFunctionMulti => comboBoxTestFunctions1.SelectedItem?.ToString();
        public MultiTest testMulti;
        public event Action<double[]> OnSolve;
        public event Action<int> OnMulti;
        public event Action<IOptimizationAlgorithm> OnAlgorithmSelected;

        public void IsStoped()
        {
            if (File.Exists("multitest.json"))
            {
                checkBox1.Checked = true;
                checkBox1.Text = "Unit test";
                checkBox1.BackColor = Color.LightPink;
                panel1.Visible = false;
                panel1.Enabled = false;
                panel2.Visible = true;
                panel2.Enabled = true;
                Func<int, bool> update = UpdateProgressBar;
                string json = File.ReadAllText("multitest.json");
                testMulti = new MultiTest(update, json);

            }
            else if (File.Exists("test.json"))
            {
                checkBox1.Text = "Group test";
                checkBox1.BackColor = Color.LightSalmon;
                panel1.Visible = true;
                panel1.Enabled = true;
                panel2.Visible = false;
                panel2.Enabled = false;

                string json = File.ReadAllText("test.json"); 
                TestData t = new TestData();
                Func<double[], double> TestFunc = null;
                if (t.func == "Sphere")
                {
                    TestFunc = TestFunction.Sphere;
                }
                else if (t.func == "Rastrigin")
                {
                    TestFunc = TestFunction.Rastrigin;
                }
                else if (t.func == "Rosenbrock")
                {
                    TestFunc = TestFunction.Rosenbrock;
                }
                else if (t.func == "Beale")
                {
                    TestFunc = TestFunction.Beale;
                }
                if (t.name == "AO")
                {
                    AquilaOptimizer aquilaOptimizer = new AquilaOptimizer();
                    aquilaOptimizer.init(TestFunc, ConvertJaggedToRectangular(t.limits),new double[] { t.param1, t.param2, t.param3});
                    aquilaOptimizer.Solve_restart(t.curIter, ConvertJaggedToRectangular(t.population), t.FBest, t.XBest);
                    this.DisplayResults(aquilaOptimizer.FBest, aquilaOptimizer.XBest);
                }
                else
                {
                    BOAAlgorithm boaOptimizer = new BOAAlgorithm();
                    boaOptimizer.init(TestFunc, ConvertJaggedToRectangular(t.limits),new double[] { t.param1, t.param2, t.param3 });
                    boaOptimizer.Solve_restart(t.curIter, ConvertJaggedToRectangular(t.population), t.FBest, t.XBest);
                    this.DisplayResults(boaOptimizer.FBest, boaOptimizer.XBest);
                }


               
            }
        }

        static double[,] ConvertJaggedToRectangular(double[][] jaggedArray)
        {
            // Determine the dimensions of the rectangular array
            int rowCount = jaggedArray.Length;
            int columnCount = jaggedArray[0].Length;

            // Create the rectangular array (double[,])
            double[,] rectangularArray = new double[rowCount, columnCount];

            // Iterate through the jagged array and copy values to the rectangular array
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    rectangularArray[i, j] = jaggedArray[i][j];
                }
            }

            return rectangularArray;
        }

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

            LoadInstructions();

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle text and background color based on state
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Testowanie pojedyńczego algorytmu";
                checkBox1.BackColor = Color.LightPink;
                panel1.Visible = false;
                panel1.Enabled = false;
                panel2.Visible = true;
                panel2.Enabled = true;
            }
            else
            {
                checkBox1.Text = "Testowanie wielu algorytmów";
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
            Func<int, bool> update = UpdateProgressBar;
            testMulti = new MultiTest(update);
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

        private void btnInstruction_Click(object sender, EventArgs e)
        {
            panelInstruction.Visible = true;
            panelInstruction.Enabled = true;
        }

        private void LoadInstructions()
        {
            // Wypełnienie RichTextBox instrukcją obsługi
            richTextBoxInstructions.Clear();

            // Dodajemy tytuł
            richTextBoxInstructions.SelectionFont = new Font("Arial", 14, FontStyle.Bold);
            richTextBoxInstructions.AppendText("Instrukcja obsługi systemu optymalizacji metaheurystycznych\n\n");

            // Dodajemy punkt o testowaniu pojedynczego algorytmu
            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("1. Testowanie pojedynczego algorytmu:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("Wybór Algorytmu i Konfiguracja Parametrów:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("Wybierz algorytm metaheurystyczny z listy i naciśnij \"Dalej\".\n");
            richTextBoxInstructions.AppendText("Ustaw parametry algorytmu (zakres każdego parametru jest ustalony ze stałym krokiem).\n");
            richTextBoxInstructions.AppendText("Zatwierdź konfigurację, klikając \"Dalej\".\n\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("Testowanie Pojedynczego Algorytmu:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("Wybierz funkcję testową (fitness function).\n");
            richTextBoxInstructions.AppendText("Kliknij \"Testuj\".\n");
            richTextBoxInstructions.AppendText("Po zakończeniu generowany jest raport wyników.\n\n");

            // Dodajemy punkt o testowaniu wielu algorytmów
            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("2. Testowanie wielu algorytmów:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("Wybór algorytmów do testowania:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("Wybierz algorytmy, które chcesz testować.\n");
            richTextBoxInstructions.AppendText("Wybierz funkcję testową (fitness function).\n");
            richTextBoxInstructions.AppendText("System automatycznie dobierze najlepsze parametry dla każdego algorytmu.\n");
            richTextBoxInstructions.AppendText("Kliknij \"Rozpocznij test\".\n");
            richTextBoxInstructions.AppendText("Po zakończeniu testu wygenerowany zostanie raport.\n\n");

            // Dodajemy punkt o przerwaniu i wznowieniu obliczeń
            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("3. Przerwanie i wznowienie obliczeń:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("Stan obliczeń zapisywany jest automatycznie.\n");
            richTextBoxInstructions.AppendText("W przypadku zamknięcia aplikacji można wznowić test od ostatniego zapisanego etapu.\n\n");

            // Dodajemy punkt o generowaniu raportów
            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("4. Generowanie Raportów:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("Po zakończeniu testów system automatycznie wygeneruje raport w formacie czytelnym dla użytkownika.\n");
            richTextBoxInstructions.AppendText("Raport zawiera wyniki testów, parametry wejściowe i wykresy wynikowe.\n");

            // Opcjonalnie, dodanie sekcji o możliwościach rozszerzenia aplikacji
            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
            richTextBoxInstructions.AppendText("\nOpcjonalne rozszerzenia:\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.AppendText("1. Możliwość dodawania nowych algorytmów optymalizacyjnych w postaci plików .dll.\n");
            richTextBoxInstructions.AppendText("2. Możliwość dodawania nowych funkcji testowych (benchmarków).\n");
        }

        private void btnCloseInst_Click(object sender, EventArgs e)
        {
            panelInstruction.Visible = false;
            panelInstruction.Enabled = false;
        }
    }
}
