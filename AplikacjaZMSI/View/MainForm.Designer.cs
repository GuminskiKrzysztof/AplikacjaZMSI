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
            this.panelAlgorithmParameters = new System.Windows.Forms.Panel();
            this.labelConfiguration = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.tableLayoutPanelParamters = new System.Windows.Forms.TableLayoutPanel();
            this.panelAlgorithmSelection.SuspendLayout();
            this.panelAlgorithmParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNextConfiguration
            // 
            this.buttonNextConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextConfiguration.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNextConfiguration.Location = new System.Drawing.Point(164, 100);
            this.buttonNextConfiguration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNextConfiguration.Name = "buttonNextConfiguration";
            this.buttonNextConfiguration.Size = new System.Drawing.Size(80, 32);
            this.buttonNextConfiguration.TabIndex = 1;
            this.buttonNextConfiguration.Text = "Dalej";
            this.buttonNextConfiguration.UseVisualStyleBackColor = true;
            this.buttonNextConfiguration.Click += new System.EventHandler(this.buttonNextConfiguration_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(503, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.panelAlgorithmSelection.Location = new System.Drawing.Point(2, 2);
            this.panelAlgorithmSelection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelAlgorithmSelection.Name = "panelAlgorithmSelection";
            this.panelAlgorithmSelection.Size = new System.Drawing.Size(258, 144);
            this.panelAlgorithmSelection.TabIndex = 4;
            // 
            // comboBoxAlgorithms
            // 
            this.comboBoxAlgorithms.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAlgorithms.FormattingEnabled = true;
            this.comboBoxAlgorithms.Items.AddRange(new object[] {
            "🦅 AO ",
            "🦋 BOA"});
            this.comboBoxAlgorithms.Location = new System.Drawing.Point(7, 53);
            this.comboBoxAlgorithms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxAlgorithms.Name = "comboBoxAlgorithms";
            this.comboBoxAlgorithms.Size = new System.Drawing.Size(237, 30);
            this.comboBoxAlgorithms.TabIndex = 7;
            // 
            // labelSelectAlgorithm
            // 
            this.labelSelectAlgorithm.AutoSize = true;
            this.labelSelectAlgorithm.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectAlgorithm.Location = new System.Drawing.Point(1, 9);
            this.labelSelectAlgorithm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectAlgorithm.Name = "labelSelectAlgorithm";
            this.labelSelectAlgorithm.Size = new System.Drawing.Size(269, 32);
            this.labelSelectAlgorithm.TabIndex = 6;
            this.labelSelectAlgorithm.Text = "Wybierz algorytm:";
            // 
            // panelAlgorithmParameters
            // 
            this.panelAlgorithmParameters.Controls.Add(this.tableLayoutPanelParamters);
            this.panelAlgorithmParameters.Controls.Add(this.labelConfiguration);
            this.panelAlgorithmParameters.Controls.Add(this.buttonBack);
            this.panelAlgorithmParameters.Location = new System.Drawing.Point(272, 89);
            this.panelAlgorithmParameters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelAlgorithmParameters.Name = "panelAlgorithmParameters";
            this.panelAlgorithmParameters.Size = new System.Drawing.Size(560, 308);
            this.panelAlgorithmParameters.TabIndex = 5;
            this.panelAlgorithmParameters.Visible = false;
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfiguration.Location = new System.Drawing.Point(11, 47);
            this.labelConfiguration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(384, 26);
            this.labelConfiguration.TabIndex = 7;
            this.labelConfiguration.Text = "Konfiguracja parametrów dla BOA";
            this.labelConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBack.Location = new System.Drawing.Point(9, 5);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(46, 40);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "⬅";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // tableLayoutPanelParamters
            // 
            this.tableLayoutPanelParamters.ColumnCount = 2;
            this.tableLayoutPanelParamters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.Location = new System.Drawing.Point(154, 166);
            this.tableLayoutPanelParamters.Name = "tableLayoutPanelParamters";
            this.tableLayoutPanelParamters.RowCount = 2;
            this.tableLayoutPanelParamters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanelParamters.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 407);
            this.Controls.Add(this.panelAlgorithmParameters);
            this.Controls.Add(this.panelAlgorithmSelection);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelAlgorithmSelection.ResumeLayout(false);
            this.panelAlgorithmSelection.PerformLayout();
            this.panelAlgorithmParameters.ResumeLayout(false);
            this.panelAlgorithmParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNextConfiguration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelAlgorithmSelection;
        private System.Windows.Forms.Panel panelAlgorithmParameters;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelSelectAlgorithm;
        private System.Windows.Forms.Label labelConfiguration;
        private System.Windows.Forms.ComboBox comboBoxAlgorithms;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelParamters;
    }
}

