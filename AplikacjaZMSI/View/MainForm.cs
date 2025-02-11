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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AplikacjaZMSI
{
    public partial class MainForm : Form
    {
        private List<IOptimizationAlgorithm> algorithms;
        private List<TrackBar> dynamicTrackBars = new List<TrackBar>();
        public Thread thread;
        private IAsyncResult inv;

        // public string SelectedTestFunction => comboBoxTestFunctions.SelectedItem?.ToString();
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
                panel1.Visible = false;
                panel1.Enabled = false;
                panel2.Visible = true;
                panel2.Enabled = true;
                Func<int, bool> update = UpdateProgressBar;
                string json = File.ReadAllText("multitest.json");
                if (thread != null)
                    if (thread.IsAlive)
                    {
                        thread.Abort();
                    }

                thread = new Thread(() =>
                {
                    testMulti = new MultiTest(update, json);
                });
                thread.Start();
                

            }
            else if (File.Exists("test.json"))
            {
                checkBox1.Text = "Group test";
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
                else if (t.func == "TSFDE")
                {
                    TSFDE_fractional_boundary tsfde_inv = new TSFDE_fractional_boundary();
                    TestFunc = tsfde_inv.fintnessFunction;
                }
                else if (t.func == "OF")
                {
                    ObjectiveFunction of = new ObjectiveFunction();
                    TestFunc = of.FunkcjaCelu.Wartosc;
                }

                if (thread != null)
                    if (thread.IsAlive)
                    {
                        thread.Abort();
                    }

                thread = new Thread(() =>
                {
                    if (t.name == "AO")
                    {
                        AquilaOptimizer aquilaOptimizer = new AquilaOptimizer();
                        aquilaOptimizer.init(TestFunc, ConvertJaggedToRectangular(t.limits), new double[] { t.param1, t.param2, t.param3, t.popSize, t.iter });
                        aquilaOptimizer.Solve_restart(t.curIter, ConvertJaggedToRectangular(t.population), t.FBest, t.XBest);
                        this.DisplayResults(aquilaOptimizer.FBest, aquilaOptimizer.XBest, t.func);
                    }
                    else
                    {
                        BOAAlgorithm boaOptimizer = new BOAAlgorithm();
                        boaOptimizer.init(TestFunc, ConvertJaggedToRectangular(t.limits), new double[] { t.param1, t.param2, t.param3, t.popSize, t.iter });
                        boaOptimizer.Solve_restart(t.curIter, ConvertJaggedToRectangular(t.population), t.FBest, t.XBest);
                        this.DisplayResults(boaOptimizer.FBest, boaOptimizer.XBest, t.func);
                    }
                });
                thread.Start();

                


               
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevents the form from closing
            }
            else
            {
                progressBar1.EndInvoke(inv);
                if (thread != null)
                {
                    thread.Abort();
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
            btnSolve.Enabled = true;
            btnMultiSolve.Enabled = false;

            multiTestLabel.Text = "";

            comboBoxAlgorithms.SelectedIndexChanged += comboBoxAlgorithms_SelectedIndexChanged;
            //comboBoxTestFunctions.SelectedIndexChanged += comboBoxTestFunctions_SelectedIndexChanged;
            comboBoxTestFunctions1.SelectedIndexChanged += comboBoxTestFunctions1_SelectedIndexChanged;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;


            // Zdarzenie na zmianę funkcji testowej
            //comboBoxTestFunctions.SelectedIndexChanged += (sender, e) =>
            //{
            //    Console.WriteLine($"Wybrano funkcję testową: {SelectedTestFunction}");
            //};
            comboBoxTestFunctions1.SelectedIndexChanged += (sender, e) =>
            {
                Console.WriteLine($"Wybrano funkcję testową1: {SelectedTestFunctionMulti}");
            };
            checkedListBox1.Items.Add("AO");
            checkedListBox1.Items.Add("BOA");

            checkedListBoxFunctions.Items.Add("Sphere");
            checkedListBoxFunctions.Items.Add("Rastrigin");
            checkedListBoxFunctions.Items.Add("Rosenbrock");
            checkedListBoxFunctions.Items.Add("Beale");
            checkedListBoxFunctions.Items.Add("TSFDE");
            checkedListBoxFunctions.Items.Add("OF");

            LoadInstructions();
            IsStoped();
           
        }

        public List<string> SelectedTestFunctions
        {
            get
            {
                return checkedListBoxFunctions.CheckedItems.Cast<string>().ToList();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle text based on state
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Testowanie pojedyńczego algorytmu";
                panel1.Visible = false;
                panel1.Enabled = false;
                panel2.Visible = true;
                panel2.Enabled = true;
            }
            else
            {
                checkBox1.Text = "Testowanie wielu algorytmów";
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
                 inv = progressBar1.BeginInvoke(new Action(() => progressBar1.Value = value));
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
                var nameLabel = new Label
                {
                    Text = param.Name,
                    AutoSize = false,
                    Width = 80,  // Stała szerokość dla nazw parametrów
                    Height = 25,
                    Location = new Point(5, 30),
                    Font = new Font("Consolas", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                paramPanel.Controls.Add(nameLabel);

                // Suwak
                TrackBar trackBar = new TrackBar();
                if (param.IsInteger)
                {
                    trackBar.Minimum = (int)param.LowerBoundary;
                    trackBar.Maximum = (int)param.UpperBoundary;
                    trackBar.Value = (int)param.LowerBoundary;
                    trackBar.TickFrequency = 1;
                }    
                else
                {
                    trackBar.Minimum = (int)(param.LowerBoundary * 10);
                    trackBar.Maximum = (int)(param.UpperBoundary * 10);
                    trackBar.Value = (int)(param.LowerBoundary * 10);
                    trackBar.TickFrequency = 10;
                }
                trackBar.Tag = param;
                trackBar.Width = paramPanel.Width - 170; // Dopasowanie szerokości do panelu
                trackBar.Location = new Point(nameLabel.Right + 20, 30); // Suwak zaraz obok etykiety
                paramPanel.Controls.Add(trackBar);

                // Min wartość (z lewej strony suwaka)
                var minLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(trackBar.Left - 35, trackBar.Top + 25),
                    Font = new Font("Consolas", 10)
                };

                // Max wartość (z prawej strony suwaka)
                var maxLabel = new Label
                {
                    AutoSize = true,
                    Location = new Point(trackBar.Right + 2, trackBar.Top + 25), // Przesunięcie w prawo
                    Font = new Font("Consolas", 10)
                };

                if (param.IsInteger)
                {
                    minLabel.Text = ((int)param.LowerBoundary).ToString();
                    maxLabel.Text = ((int)param.UpperBoundary).ToString();
                }
                else
                {
                    minLabel.Text = $"{param.LowerBoundary:F1}";
                    maxLabel.Text = $"{param.UpperBoundary:F1}";
                }
                paramPanel.Controls.Add(minLabel);
                paramPanel.Controls.Add(maxLabel);


                // Aktualna wartość (nad suwakiem)
                var valueLabel = new Label
                {
                    // Text = $"{param.LowerBoundary:F1}",
                    AutoSize = true,
                    Location = new Point(trackBar.Left, trackBar.Top - 20),
                    Font = new Font("Consolas", 10),
                    BackColor = Color.LightYellow // Opcjonalnie dla lepszej widoczności
                };


                if (param.IsInteger)
                    valueLabel.Text = trackBar.Value.ToString();
                else
                    valueLabel.Text = (trackBar.Value / 10.0).ToString("F1");

                paramPanel.Controls.Add(valueLabel);

                // Dynamiczne przesuwanie etykiety wartości
                trackBar.Scroll += (sender, e) =>
                {
                    var tb = sender as TrackBar;
                    if (tb.Tag is ParamInfo p)
                    {
                        if (p.IsInteger)
                        {
                            valueLabel.Text = tb.Value.ToString();
                            int relPos = (int)(((tb.Value - tb.Minimum) / (double)(tb.Maximum - tb.Minimum)) * (tb.Width - 10));
                            int labelCenterX = tb.Left + relPos - (valueLabel.Width / 2);
                            valueLabel.Location = new Point(labelCenterX, tb.Top - 20);
                        }
                        else
                        {
                            double currentValue = tb.Value / 10.0;
                            valueLabel.Text = currentValue.ToString("F1");
                            int trackBarRange = tb.Maximum - tb.Minimum;
                            int trackBarWidth = tb.Width - 10;
                            int relPos = (int)(((tb.Value - tb.Minimum) / (double)trackBarRange) * trackBarWidth);
                            int labelCenterX = tb.Left + relPos - (valueLabel.Width / 2) + 5;
                            valueLabel.Location = new Point(labelCenterX, tb.Top - 20);
                        }
                    }
                };

                // Dodaj do głównego kontenera
                panelParameters.Controls.Add(paramPanel);
                dynamicTrackBars.Add(trackBar);
            }
        }

        private void comboBoxTestFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnSolve.Enabled = comboBoxTestFunctions.SelectedItem != null;
        }




        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (comboBoxAlgorithms.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać algorytm przed rozpoczęciem testowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parameterValues = dynamicTrackBars.Select(tb =>
            {
                var p = tb.Tag as ParamInfo;
                return p.IsInteger ? (double)tb.Value : tb.Value / 10.0;
            }).ToArray();

            OnSolve?.Invoke(parameterValues);
        }

        // Metoda do wyświetlania wyników

        public void ClearResults()
        {
            lblResult.Text = "";
        }

        public bool UpdateDisplayResults(string value)
        {
            if (lblResult.InvokeRequired)
            {
                lblResult.Invoke(new Action(() => lblResult.Text += value));
            }
            else
            {
                lblResult.Text += value;
            }
            return true;
        }

        public void DisplayResults(double fBest, double[] xBest, string functionName)
        {
            lblResult.Text += $"Funkcja: {functionName} Najlepsze f(X): {fBest}\n";
        }

        private void btnMultiSolve_Click(object sender, EventArgs e)
        {
            string sss = SelectedTestFunctionMulti;
            if(thread != null)
            if (thread.IsAlive)
            {
                thread.Abort();
                    }
          
            thread = new Thread(() =>
            {
                Func<int, bool> update = UpdateProgressBar;
                testMulti = new MultiTest(update);
                List<string> checkedItemsList = new List<string>();
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    checkedItemsList.Add(item.ToString());
                }
                testMulti.run(sss, checkedItemsList);
                multiTestLabel.Text = "";
                foreach (var test in testMulti.getbest())
                {
                    multiTestLabel.Text += "Nazwa algorytmu: " + test.name + " Najlepszy wynik: " + test.FBest + "\n";
                }
            }
            );
            thread.Start();

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
            // Wyczyść RichTextBox przed dodaniem nowej treści
            richTextBoxInstructions.Clear();

            // Ustawienie formatu dla tytułu
            richTextBoxInstructions.SelectionFont = new Font("Arial", 16, FontStyle.Bold);
            richTextBoxInstructions.SelectionColor = Color.DarkBlue;
            richTextBoxInstructions.AppendText("Instrukcja obsługi systemu optymalizacji metaheurystycznych\n\n");

            // Sekcja: Testowanie pojedynczego algorytmu
            richTextBoxInstructions.SelectionFont = new Font("Arial", 14, FontStyle.Bold);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("1. Testowanie pojedynczego algorytmu\n\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Underline);
            richTextBoxInstructions.SelectionColor = Color.DarkGreen;
            richTextBoxInstructions.AppendText("Wybór Algorytmu i Konfiguracja Parametrów\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("✔ Wybierz algorytm metaheurystyczny z listy i naciśnij \"Dalej\".\n✔ Ustaw parametry algorytmu (zakres każdego parametru jest ustalony ze stałym krokiem).\n✔ Zatwierdź konfigurację, klikając \"Dalej\".\n\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Underline);
            richTextBoxInstructions.SelectionColor = Color.DarkGreen;
            richTextBoxInstructions.AppendText("Testowanie Pojedynczego Algorytmu\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("✔ Wybierz funkcję testową (fitness function).\n✔ Kliknij \"Testuj\".\n✔ Po zakończeniu generowany jest raport wyników.\n\n");

            // Sekcja: Testowanie wielu algorytmów
            richTextBoxInstructions.SelectionFont = new Font("Arial", 14, FontStyle.Bold);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("2. Testowanie wielu algorytmów\n\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Underline);
            richTextBoxInstructions.SelectionColor = Color.DarkGreen;
            richTextBoxInstructions.AppendText("Wybór algorytmów do testowania\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("✔ Wybierz algorytmy, które chcesz testować.\n✔ Wybierz funkcję testową (fitness function).\n✔ System automatycznie dobierze najlepsze parametry dla każdego algorytmu.\n✔ Kliknij \"Rozpocznij test\".\n✔ Po zakończeniu testu wygenerowany zostanie raport.\n\n");

            // Sekcja: Przerwanie i wznowienie obliczeń
            richTextBoxInstructions.SelectionFont = new Font("Arial", 14, FontStyle.Bold);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("3. Przerwanie i wznowienie obliczeń\n\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("✔ Stan obliczeń zapisywany jest automatycznie.\n✔ W przypadku zamknięcia aplikacji można wznowić test od ostatniego zapisanego etapu.\n\n");

            // Sekcja: Generowanie raportów
            richTextBoxInstructions.SelectionFont = new Font("Arial", 14, FontStyle.Bold);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("4. Generowanie Raportów\n\n");

            richTextBoxInstructions.SelectionFont = new Font("Arial", 12, FontStyle.Regular);
            richTextBoxInstructions.SelectionColor = Color.Black;
            richTextBoxInstructions.AppendText("✔ Po zakończeniu testów system automatycznie wygeneruje raport w formacie czytelnym dla użytkownika.\n✔ Raport zawiera wyniki testów, parametry wejściowe i wykresy wynikowe.\n");

        }

        private void btnCloseInst_Click(object sender, EventArgs e)
        {
            panelInstruction.Visible = false;
            panelInstruction.Enabled = false;
        }

        private void btnSingleReport_Click(object sender, EventArgs e)
        {
            foreach (string uuu in SelectedTestFunctions)
            {
                try
                {
                    Process.Start("rapor_"+uuu+".pdf");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void btnMultiReport_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("multiraport.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
