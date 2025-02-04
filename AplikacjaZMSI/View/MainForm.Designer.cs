﻿namespace AplikacjaZMSI
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnMultiSolve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAlgorithmSelection.SuspendLayout();
            this.panelAlgorithmConfiguration.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNextConfiguration
            // 
            this.buttonNextConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextConfiguration.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNextConfiguration.Location = new System.Drawing.Point(89, 81);
            this.buttonNextConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNextConfiguration.Name = "buttonNextConfiguration";
            this.buttonNextConfiguration.Size = new System.Drawing.Size(69, 34);
            this.buttonNextConfiguration.TabIndex = 1;
            this.buttonNextConfiguration.Text = "Dalej";
            this.buttonNextConfiguration.UseVisualStyleBackColor = true;
            this.buttonNextConfiguration.Click += new System.EventHandler(this.buttonNextConfiguration_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(618, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "instrukcja";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panelAlgorithmSelection
            // 
            this.panelAlgorithmSelection.Controls.Add(this.comboBoxAlgorithms);
            this.panelAlgorithmSelection.Controls.Add(this.labelSelectAlgorithm);
            this.panelAlgorithmSelection.Controls.Add(this.buttonNextConfiguration);
            this.panelAlgorithmSelection.Location = new System.Drawing.Point(14, 4);
            this.panelAlgorithmSelection.Margin = new System.Windows.Forms.Padding(2);
            this.panelAlgorithmSelection.Name = "panelAlgorithmSelection";
            this.panelAlgorithmSelection.Size = new System.Drawing.Size(249, 117);
            this.panelAlgorithmSelection.TabIndex = 4;
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgorithms.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(5, 43);
            this.comboBoxAlgorithms.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(239, 30);
            this.comboBoxAlgorithms.TabIndex = 7;
            this.comboBoxAlgorithms.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithms_SelectedIndexChanged);
            // 
            // labelSelectAlgorithm
            // 
            this.labelSelectAlgorithm.AutoSize = true;
            this.labelSelectAlgorithm.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectAlgorithm.Location = new System.Drawing.Point(1, 7);
            this.labelSelectAlgorithm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectAlgorithm.Name = "labelSelectAlgorithm";
            this.labelSelectAlgorithm.Size = new System.Drawing.Size(269, 32);
            this.labelSelectAlgorithm.TabIndex = 6;
            this.labelSelectAlgorithm.Text = "Wybierz algorytm:";
            // 
            // panelAlgorithmConfiguration
            // 
            this.panelAlgorithmConfiguration.Controls.Add(this.buttonBack);
            this.panelAlgorithmConfiguration.Controls.Add(this.panelParameters);
            this.panelAlgorithmConfiguration.Controls.Add(this.btnSolve);
            this.panelAlgorithmConfiguration.Controls.Add(this.comboBoxTestFunctions);
            this.panelAlgorithmConfiguration.Controls.Add(this.labelConfiguration);
            this.panelAlgorithmConfiguration.Controls.Add(this.lblResult);
            this.panelAlgorithmConfiguration.Location = new System.Drawing.Point(7, 85);
            this.panelAlgorithmConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.panelAlgorithmConfiguration.Name = "panelAlgorithmConfiguration";
            this.panelAlgorithmConfiguration.Size = new System.Drawing.Size(941, 427);
            this.panelAlgorithmConfiguration.TabIndex = 5;
            this.panelAlgorithmConfiguration.Visible = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Location = new System.Drawing.Point(8, 20);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(39, 44);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "⬅";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.AutoScroll = true;
            this.panelParameters.Location = new System.Drawing.Point(25, 79);
            this.panelParameters.Margin = new System.Windows.Forms.Padding(2);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(660, 285);
            this.panelParameters.TabIndex = 9;
            // 
            // btnSolve
            // 
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSolve.Location = new System.Drawing.Point(750, 116);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(60, 26);
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
            this.comboBoxTestFunctions.Location = new System.Drawing.Point(750, 67);
            this.comboBoxTestFunctions.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestFunctions.Name = "comboBoxTestFunctions";
            this.comboBoxTestFunctions.Size = new System.Drawing.Size(170, 30);
            this.comboBoxTestFunctions.TabIndex = 9;
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfiguration.Location = new System.Drawing.Point(61, 37);
            this.labelConfiguration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(0, 26);
            this.labelConfiguration.TabIndex = 7;
            this.labelConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(25, 388);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 19);
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
            this.comboBoxTestFunctions1.Location = new System.Drawing.Point(364, 199);
            this.comboBoxTestFunctions1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestFunctions1.Name = "comboBoxTestFunctions1";
            this.comboBoxTestFunctions1.Size = new System.Drawing.Size(237, 30);
            this.comboBoxTestFunctions1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelAlgorithmSelection);
            this.panel1.Controls.Add(this.panelAlgorithmConfiguration);
            this.panel1.Location = new System.Drawing.Point(22, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 514);
            this.panel1.TabIndex = 16;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.LightPink;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox1.Location = new System.Drawing.Point(839, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 23);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Testowanie wielu algorytmów";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(794, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Idź do:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btnMultiSolve);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxTestFunctions1);
            this.panel2.Location = new System.Drawing.Point(19, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(986, 517);
            this.panel2.TabIndex = 19;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(86, 113);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 79);
            this.checkedListBox1.TabIndex = 12;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(485, 352);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 64);
            this.progressBar1.TabIndex = 11;
            // 
            // btnMultiSolve
            // 
            this.btnMultiSolve.Location = new System.Drawing.Point(727, 154);
            this.btnMultiSolve.Name = "btnMultiSolve";
            this.btnMultiSolve.Size = new System.Drawing.Size(75, 23);
            this.btnMultiSolve.TabIndex = 10;
            this.btnMultiSolve.Text = "Testuj";
            this.btnMultiSolve.UseVisualStyleBackColor = true;
            this.btnMultiSolve.Click += new System.EventHandler(this.btnMultiSolve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(81, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Wybierz algorytmy:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 613);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelAlgorithmSelection.ResumeLayout(false);
            this.panelAlgorithmSelection.PerformLayout();
            this.panelAlgorithmConfiguration.ResumeLayout(false);
            this.panelAlgorithmConfiguration.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNextConfiguration;
        private System.Windows.Forms.Button button1;
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
    }
}

