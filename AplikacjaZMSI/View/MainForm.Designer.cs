namespace AplikacjaZMSI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNextConfiguration = new System.Windows.Forms.Button();
            this.btnInstruction = new System.Windows.Forms.Button();
            this.panelAlgorithmSelection = new System.Windows.Forms.Panel();
            this.comboBoxAlgorithms = new System.Windows.Forms.ComboBox();
            this.labelSelectAlgorithm = new System.Windows.Forms.Label();
            this.panelAlgorithmConfiguration = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelParameters = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSolve = new System.Windows.Forms.Button();
            this.comboBoxTestFunctions = new System.Windows.Forms.ComboBox();
            this.labelConfiguration = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.comboBoxTestFunctions1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelInstruction = new System.Windows.Forms.Panel();
            this.btnCloseInst = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMultiSolve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxInstructions = new System.Windows.Forms.RichTextBox();
            this.btnMultiReport = new System.Windows.Forms.Button();
            this.btnSingleReport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelAlgorithmSelection.SuspendLayout();
            this.panelAlgorithmConfiguration.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelInstruction.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNextConfiguration
            // 
            this.buttonNextConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextConfiguration.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNextConfiguration.Location = new System.Drawing.Point(363, 105);
            this.buttonNextConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNextConfiguration.Name = "buttonNextConfiguration";
            this.buttonNextConfiguration.Size = new System.Drawing.Size(92, 42);
            this.buttonNextConfiguration.TabIndex = 1;
            this.buttonNextConfiguration.Text = "Dalej";
            this.buttonNextConfiguration.UseVisualStyleBackColor = true;
            this.buttonNextConfiguration.Click += new System.EventHandler(this.buttonNextConfiguration_Click);
            // 
            // btnInstruction
            // 
            this.btnInstruction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstruction.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnInstruction.Location = new System.Drawing.Point(1233, 10);
            this.btnInstruction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInstruction.Name = "btnInstruction";
            this.btnInstruction.Size = new System.Drawing.Size(107, 39);
            this.btnInstruction.TabIndex = 3;
            this.btnInstruction.Text = "instrukcja";
            this.btnInstruction.UseVisualStyleBackColor = true;
            this.btnInstruction.Click += new System.EventHandler(this.btnInstruction_Click);
            // 
            // panelAlgorithmSelection
            // 
            this.panelAlgorithmSelection.Controls.Add(this.comboBoxAlgorithms);
            this.panelAlgorithmSelection.Controls.Add(this.labelSelectAlgorithm);
            this.panelAlgorithmSelection.Controls.Add(this.buttonNextConfiguration);
            this.panelAlgorithmSelection.Location = new System.Drawing.Point(485, 51);
            this.panelAlgorithmSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAlgorithmSelection.Name = "panelAlgorithmSelection";
            this.panelAlgorithmSelection.Size = new System.Drawing.Size(461, 158);
            this.panelAlgorithmSelection.TabIndex = 4;
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgorithms.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(7, 55);
            this.comboBoxAlgorithms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(451, 35);
            this.comboBoxAlgorithms.TabIndex = 7;
            this.comboBoxAlgorithms.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithms_SelectedIndexChanged);
            // 
            // labelSelectAlgorithm
            // 
            this.labelSelectAlgorithm.AutoSize = true;
            this.labelSelectAlgorithm.Font = new System.Drawing.Font("Consolas", 15F);
            this.labelSelectAlgorithm.Location = new System.Drawing.Point(110, 11);
            this.labelSelectAlgorithm.Name = "labelSelectAlgorithm";
            this.labelSelectAlgorithm.Size = new System.Drawing.Size(251, 29);
            this.labelSelectAlgorithm.TabIndex = 6;
            this.labelSelectAlgorithm.Text = "Wybierz algorytm:";
            // 
            // panelAlgorithmConfiguration
            // 
            this.panelAlgorithmConfiguration.Controls.Add(this.label7);
            this.panelAlgorithmConfiguration.Controls.Add(this.btnSingleReport);
            this.panelAlgorithmConfiguration.Controls.Add(this.buttonBack);
            this.panelAlgorithmConfiguration.Controls.Add(this.panelParameters);
            this.panelAlgorithmConfiguration.Controls.Add(this.btnSolve);
            this.panelAlgorithmConfiguration.Controls.Add(this.comboBoxTestFunctions);
            this.panelAlgorithmConfiguration.Controls.Add(this.labelConfiguration);
            this.panelAlgorithmConfiguration.Controls.Add(this.lblResult);
            this.panelAlgorithmConfiguration.Location = new System.Drawing.Point(9, 105);
            this.panelAlgorithmConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAlgorithmConfiguration.Name = "panelAlgorithmConfiguration";
            this.panelAlgorithmConfiguration.Size = new System.Drawing.Size(1255, 526);
            this.panelAlgorithmConfiguration.TabIndex = 5;
            this.panelAlgorithmConfiguration.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Location = new System.Drawing.Point(11, 25);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(52, 54);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "⬅";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.AutoScroll = true;
            this.panelParameters.Location = new System.Drawing.Point(64, 108);
            this.panelParameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(880, 351);
            this.panelParameters.TabIndex = 9;
            // 
            // btnSolve
            // 
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSolve.Location = new System.Drawing.Point(1126, 234);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(112, 42);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "Testuj";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // comboBoxTestFunctions
            // 
            this.comboBoxTestFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestFunctions.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxTestFunctions.FormattingEnabled = true;
            this.comboBoxTestFunctions.Items.AddRange(new object[] {
            "Sphere",
            "Rastrigin",
            "Rosenbrock",
            "Beale"});
            this.comboBoxTestFunctions.Location = new System.Drawing.Point(969, 184);
            this.comboBoxTestFunctions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTestFunctions.Name = "comboBoxTestFunctions";
            this.comboBoxTestFunctions.Size = new System.Drawing.Size(271, 35);
            this.comboBoxTestFunctions.TabIndex = 9;
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfiguration.Location = new System.Drawing.Point(81, 46);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(0, 32);
            this.labelConfiguration.TabIndex = 7;
            this.labelConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(33, 478);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 23);
            this.lblResult.TabIndex = 15;
            // 
            // comboBoxTestFunctions1
            // 
            this.comboBoxTestFunctions1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestFunctions1.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxTestFunctions1.FormattingEnabled = true;
            this.comboBoxTestFunctions1.Items.AddRange(new object[] {
            "Sphere",
            "Rastrigin",
            "Rosenbrock",
            "Beale"});
            this.comboBoxTestFunctions1.Location = new System.Drawing.Point(795, 105);
            this.comboBoxTestFunctions1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTestFunctions1.Name = "comboBoxTestFunctions1";
            this.comboBoxTestFunctions1.Size = new System.Drawing.Size(315, 35);
            this.comboBoxTestFunctions1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panelAlgorithmSelection);
            this.panel1.Controls.Add(this.panelAlgorithmConfiguration);
            this.panel1.Location = new System.Drawing.Point(25, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 633);
            this.panel1.TabIndex = 16;
            // 
            // panelInstruction
            // 
            this.panelInstruction.Controls.Add(this.richTextBoxInstructions);
            this.panelInstruction.Controls.Add(this.btnCloseInst);
            this.panelInstruction.Controls.Add(this.label3);
            this.panelInstruction.Location = new System.Drawing.Point(25, 54);
            this.panelInstruction.Name = "panelInstruction";
            this.panelInstruction.Size = new System.Drawing.Size(1309, 626);
            this.panelInstruction.TabIndex = 6;
            this.panelInstruction.Visible = false;
            // 
            // btnCloseInst
            // 
            this.btnCloseInst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseInst.Font = new System.Drawing.Font("Consolas", 18F);
            this.btnCloseInst.Location = new System.Drawing.Point(1236, 16);
            this.btnCloseInst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseInst.Name = "btnCloseInst";
            this.btnCloseInst.Size = new System.Drawing.Size(53, 44);
            this.btnCloseInst.TabIndex = 20;
            this.btnCloseInst.Text = "×";
            this.btnCloseInst.UseVisualStyleBackColor = true;
            this.btnCloseInst.Click += new System.EventHandler(this.btnCloseInst_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(507, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 38);
            this.label3.TabIndex = 7;
            this.label3.Text = "Instrukcja";
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.LightGray;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 8F);
            this.checkBox1.Location = new System.Drawing.Point(95, 15);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(234, 27);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Testowanie wielu algorytmów";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8F);
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Idź do:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnMultiReport);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btnMultiSolve);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxTestFunctions1);
            this.panel2.Location = new System.Drawing.Point(25, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1315, 636);
            this.panel2.TabIndex = 19;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(285, 105);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(260, 85);
            this.checkedListBox1.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar1.Location = new System.Drawing.Point(285, 261);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(825, 48);
            this.progressBar1.TabIndex = 11;
            // 
            // btnMultiSolve
            // 
            this.btnMultiSolve.Font = new System.Drawing.Font("Consolas", 13.8F);
            this.btnMultiSolve.Location = new System.Drawing.Point(994, 165);
            this.btnMultiSolve.Margin = new System.Windows.Forms.Padding(4);
            this.btnMultiSolve.Name = "btnMultiSolve";
            this.btnMultiSolve.Size = new System.Drawing.Size(116, 42);
            this.btnMultiSolve.TabIndex = 10;
            this.btnMultiSolve.Text = "Testuj";
            this.btnMultiSolve.UseVisualStyleBackColor = true;
            this.btnMultiSolve.Click += new System.EventHandler(this.btnMultiSolve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 15F);
            this.label2.Location = new System.Drawing.Point(280, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Wybierz algorytmy:";
            // 
            // richTextBoxInstructions
            // 
            this.richTextBoxInstructions.Location = new System.Drawing.Point(17, 106);
            this.richTextBoxInstructions.Name = "richTextBoxInstructions";
            this.richTextBoxInstructions.ReadOnly = true;
            this.richTextBoxInstructions.Size = new System.Drawing.Size(1272, 517);
            this.richTextBoxInstructions.TabIndex = 21;
            this.richTextBoxInstructions.Text = "";
            // 
            // btnMultiReport
            // 
            this.btnMultiReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMultiReport.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMultiReport.Location = new System.Drawing.Point(976, 383);
            this.btnMultiReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMultiReport.Name = "btnMultiReport";
            this.btnMultiReport.Size = new System.Drawing.Size(134, 65);
            this.btnMultiReport.TabIndex = 13;
            this.btnMultiReport.Text = "Pokaż raport";
            this.btnMultiReport.UseVisualStyleBackColor = true;
            this.btnMultiReport.Click += new System.EventHandler(this.btnMultiReport_Click);
            // 
            // btnSingleReport
            // 
            this.btnSingleReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSingleReport.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSingleReport.Location = new System.Drawing.Point(978, 436);
            this.btnSingleReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSingleReport.Name = "btnSingleReport";
            this.btnSingleReport.Size = new System.Drawing.Size(134, 65);
            this.btnSingleReport.TabIndex = 16;
            this.btnSingleReport.Text = "Pokaż raport";
            this.btnSingleReport.UseVisualStyleBackColor = true;
            this.btnSingleReport.Click += new System.EventHandler(this.btnSingleReport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(420, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(611, 38);
            this.label4.TabIndex = 8;
            this.label4.Text = "Testowanie pojedynczego algorytmu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(412, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(503, 38);
            this.label5.TabIndex = 9;
            this.label5.Text = "Testowanie wielu algorytmów";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 15F);
            this.label6.Location = new System.Drawing.Point(790, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "Funkcja testowa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 15F);
            this.label7.Location = new System.Drawing.Point(964, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 29);
            this.label7.TabIndex = 15;
            this.label7.Text = "Funkcja testowa:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 754);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelInstruction);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnInstruction);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelAlgorithmSelection.ResumeLayout(false);
            this.panelAlgorithmSelection.PerformLayout();
            this.panelAlgorithmConfiguration.ResumeLayout(false);
            this.panelAlgorithmConfiguration.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelInstruction.ResumeLayout(false);
            this.panelInstruction.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNextConfiguration;
        private System.Windows.Forms.Button btnInstruction;
        private System.Windows.Forms.Panel panelAlgorithmSelection;
        private System.Windows.Forms.Panel panelAlgorithmConfiguration;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelSelectAlgorithm;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.FlowLayoutPanel panelParameters;
        private System.Windows.Forms.Label labelConfiguration;
        private System.Windows.Forms.ComboBox comboBoxTestFunctions;
        private System.Windows.Forms.ComboBox comboBoxTestFunctions1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMultiSolve;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox comboBoxAlgorithms;
        private System.Windows.Forms.Panel panelInstruction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCloseInst;
        private System.Windows.Forms.RichTextBox richTextBoxInstructions;
        private System.Windows.Forms.Button btnSingleReport;
        private System.Windows.Forms.Button btnMultiReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

