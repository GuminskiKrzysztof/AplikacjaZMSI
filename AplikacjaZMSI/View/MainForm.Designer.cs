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
            this.buttonAO = new System.Windows.Forms.Button();
            this.buttonBOA = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelAlgorithmSelection = new System.Windows.Forms.Panel();
            this.labelSelectAlgorithm = new System.Windows.Forms.Label();
            this.panelAlgorithmParameters = new System.Windows.Forms.Panel();
            this.labelConfiguration = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.comboBoxAlgorithms = new System.Windows.Forms.ComboBox();
            this.panelAlgorithmSelection.SuspendLayout();
            this.panelAlgorithmParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAO
            // 
            this.buttonAO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAO.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAO.Location = new System.Drawing.Point(3, 54);
            this.buttonAO.Name = "buttonAO";
            this.buttonAO.Size = new System.Drawing.Size(107, 39);
            this.buttonAO.TabIndex = 1;
            this.buttonAO.Text = "🦅 AO ";
            this.buttonAO.UseVisualStyleBackColor = true;
            this.buttonAO.Click += new System.EventHandler(this.buttonAO_Click);
            // 
            // buttonBOA
            // 
            this.buttonBOA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBOA.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBOA.Location = new System.Drawing.Point(130, 54);
            this.buttonBOA.Name = "buttonBOA";
            this.buttonBOA.Size = new System.Drawing.Size(107, 39);
            this.buttonBOA.TabIndex = 2;
            this.buttonBOA.Text = "🦋 BOA";
            this.buttonBOA.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(1002, 12);
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
            this.panelAlgorithmSelection.Controls.Add(this.buttonAO);
            this.panelAlgorithmSelection.Controls.Add(this.buttonBOA);
            this.panelAlgorithmSelection.Location = new System.Drawing.Point(1, 12);
            this.panelAlgorithmSelection.Name = "panelAlgorithmSelection";
            this.panelAlgorithmSelection.Size = new System.Drawing.Size(344, 177);
            this.panelAlgorithmSelection.TabIndex = 4;
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
            // panelAlgorithmParameters
            // 
            this.panelAlgorithmParameters.Controls.Add(this.labelConfiguration);
            this.panelAlgorithmParameters.Controls.Add(this.buttonBack);
            this.panelAlgorithmParameters.Location = new System.Drawing.Point(362, 110);
            this.panelAlgorithmParameters.Name = "panelAlgorithmParameters";
            this.panelAlgorithmParameters.Size = new System.Drawing.Size(747, 379);
            this.panelAlgorithmParameters.TabIndex = 5;
            this.panelAlgorithmParameters.Visible = false;
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfiguration.Location = new System.Drawing.Point(15, 58);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(479, 32);
            this.labelConfiguration.TabIndex = 7;
            this.labelConfiguration.Text = "Konfiguracja parametrów dla BOA";
            this.labelConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Location = new System.Drawing.Point(12, 6);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(61, 49);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "⬅";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Items.AddRange(new object[] {
            "🦅 AO ",
            "🦋 BOA"});
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(9, 107);
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(315, 35);
            this.comboBoxAlgorithms.TabIndex = 7;
            this.comboBoxAlgorithms.SelectedIndexChanged += new System.EventHandler(this.buttonAO_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 501);
            this.Controls.Add(this.panelAlgorithmParameters);
            this.Controls.Add(this.panelAlgorithmSelection);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelAlgorithmSelection.ResumeLayout(false);
            this.panelAlgorithmSelection.PerformLayout();
            this.panelAlgorithmParameters.ResumeLayout(false);
            this.panelAlgorithmParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAO;
        private System.Windows.Forms.Button buttonBOA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelAlgorithmSelection;
        private System.Windows.Forms.Panel panelAlgorithmParameters;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelSelectAlgorithm;
        private System.Windows.Forms.Label labelConfiguration;
        private System.Windows.Forms.ComboBox comboBoxAlgorithms;
    }
}

