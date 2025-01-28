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
            this.button1 = new System.Windows.Forms.Button();
            this.panelAlgorithmSelection = new System.Windows.Forms.Panel();
            this.comboBoxAlgorithms = new System.Windows.Forms.ComboBox();
            this.labelSelectAlgorithm = new System.Windows.Forms.Label();
            this.panelAlgorithmConfiguration = new System.Windows.Forms.Panel();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.btnSolve = new System.Windows.Forms.Button();
            this.labelConfiguration = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.comboBoxTestFunctions = new System.Windows.Forms.ComboBox();
            this.panelAlgorithmSelection.SuspendLayout();
            this.panelAlgorithmConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNextConfiguration
            // 
            this.buttonNextConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextConfiguration.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNextConfiguration.Location = new System.Drawing.Point(219, 123);
            this.buttonNextConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNextConfiguration.Name = "buttonNextConfiguration";
            this.buttonNextConfiguration.Size = new System.Drawing.Size(107, 39);
            this.buttonNextConfiguration.TabIndex = 1;
            this.buttonNextConfiguration.Text = "Dalej";
            this.buttonNextConfiguration.UseVisualStyleBackColor = true;
            this.buttonNextConfiguration.Click += new System.EventHandler(this.buttonNextConfiguration_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(671, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "instrukcja";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panelAlgorithmSelection
            // 
            this.panelAlgorithmSelection.Controls.Add(this.comboBoxAlgorithms);
            this.panelAlgorithmSelection.Controls.Add(this.labelSelectAlgorithm);
            this.panelAlgorithmSelection.Controls.Add(this.buttonNextConfiguration);
            this.panelAlgorithmSelection.Location = new System.Drawing.Point(3, 2);
            this.panelAlgorithmSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAlgorithmSelection.Name = "panelAlgorithmSelection";
            this.panelAlgorithmSelection.Size = new System.Drawing.Size(344, 177);
            this.panelAlgorithmSelection.TabIndex = 4;
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Items.AddRange(new object[] {
            "🦅 AO ",
            "🦋 BOA"});
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(9, 65);
            this.comboBoxAlgorithms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(315, 35);
            this.comboBoxAlgorithms.TabIndex = 7;
            this.comboBoxAlgorithms.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithms_SelectedIndexChanged);
            // 
            // labelSelectAlgorithm
            // 
            this.labelSelectAlgorithm.AutoSize = true;
            this.labelSelectAlgorithm.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectAlgorithm.Location = new System.Drawing.Point(1, 11);
            this.labelSelectAlgorithm.Name = "labelSelectAlgorithm";
            this.labelSelectAlgorithm.Size = new System.Drawing.Size(323, 38);
            this.labelSelectAlgorithm.TabIndex = 6;
            this.labelSelectAlgorithm.Text = "Wybierz algorytm:";
            // 
            // panelAlgorithmConfiguration
            // 
            this.panelAlgorithmConfiguration.Controls.Add(this.comboBoxTestFunctions);
            this.panelAlgorithmConfiguration.Controls.Add(this.panelParameters);
            this.panelAlgorithmConfiguration.Controls.Add(this.btnSolve);
            this.panelAlgorithmConfiguration.Controls.Add(this.labelConfiguration);
            this.panelAlgorithmConfiguration.Controls.Add(this.buttonBack);
            this.panelAlgorithmConfiguration.Location = new System.Drawing.Point(363, 80);
            this.panelAlgorithmConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAlgorithmConfiguration.Name = "panelAlgorithmConfiguration";
            this.panelAlgorithmConfiguration.Size = new System.Drawing.Size(804, 463);
            this.panelAlgorithmConfiguration.TabIndex = 5;
            this.panelAlgorithmConfiguration.Visible = false;
            // 
            // panelParameters
            // 
            this.panelParameters.Location = new System.Drawing.Point(38, 108);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(441, 341);
            this.panelParameters.TabIndex = 9;
            // 
            // btnSolve
            // 
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSolve.Location = new System.Drawing.Point(529, 314);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(107, 39);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "Testuj";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfiguration.Location = new System.Drawing.Point(41, 57);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(0, 32);
            this.labelConfiguration.TabIndex = 7;
            this.labelConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Location = new System.Drawing.Point(12, 6);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 49);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "⬅";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(12, 542);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 32);
            this.lblResult.TabIndex = 15;
            // 
            // comboBoxTestFunctions
            // 
            this.comboBoxTestFunctions.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxTestFunctions.FormattingEnabled = true;
            this.comboBoxTestFunctions.Items.AddRange(new object[] {
                "Sphere",
                "Rastrigin",
                "Rosenbrock",
                "Beale"});
            this.comboBoxTestFunctions.Location = new System.Drawing.Point(485, 245);
            this.comboBoxTestFunctions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTestFunctions.Name = "comboBoxTestFunctions";
            this.comboBoxTestFunctions.SelectedIndex = 0;
            this.comboBoxTestFunctions.Size = new System.Drawing.Size(315, 35);
            this.comboBoxTestFunctions.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 622);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.panelAlgorithmConfiguration);
            this.Controls.Add(this.panelAlgorithmSelection);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelAlgorithmSelection.ResumeLayout(false);
            this.panelAlgorithmSelection.PerformLayout();
            this.panelAlgorithmConfiguration.ResumeLayout(false);
            this.panelAlgorithmConfiguration.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBoxAlgorithms;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Label labelConfiguration;
        private System.Windows.Forms.ComboBox comboBoxTestFunctions;
    }
}

