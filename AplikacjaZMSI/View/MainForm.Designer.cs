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
            this.trackBarAlpha = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanelParamters = new System.Windows.Forms.TableLayoutPanel();
            this.labelConfiguration = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.trackBarDelta = new System.Windows.Forms.TrackBar();
            this.trackBarBeta = new System.Windows.Forms.TrackBar();
            this.btnSolve = new System.Windows.Forms.Button();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelDelta = new System.Windows.Forms.Label();
            this.labelBeta = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.panelAlgorithmSelection.SuspendLayout();
            this.panelAlgorithmParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBeta)).BeginInit();
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
            this.panelAlgorithmParameters.Controls.Add(this.labelBeta);
            this.panelAlgorithmParameters.Controls.Add(this.labelDelta);
            this.panelAlgorithmParameters.Controls.Add(this.labelAlpha);
            this.panelAlgorithmParameters.Controls.Add(this.btnSolve);
            this.panelAlgorithmParameters.Controls.Add(this.trackBarBeta);
            this.panelAlgorithmParameters.Controls.Add(this.trackBarDelta);
            this.panelAlgorithmParameters.Controls.Add(this.trackBarAlpha);
            this.panelAlgorithmParameters.Controls.Add(this.tableLayoutPanelParamters);
            this.panelAlgorithmParameters.Controls.Add(this.labelConfiguration);
            this.panelAlgorithmParameters.Controls.Add(this.buttonBack);
            this.panelAlgorithmParameters.Location = new System.Drawing.Point(363, 110);
            this.panelAlgorithmParameters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelAlgorithmParameters.Name = "panelAlgorithmParameters";
            this.panelAlgorithmParameters.Size = new System.Drawing.Size(747, 379);
            this.panelAlgorithmParameters.TabIndex = 5;
            this.panelAlgorithmParameters.Visible = false;
            // 
            // trackBarAlpha
            // 
            this.trackBarAlpha.Location = new System.Drawing.Point(130, 137);
            this.trackBarAlpha.Maximum = 5;
            this.trackBarAlpha.Name = "trackBarAlpha";
            this.trackBarAlpha.Size = new System.Drawing.Size(285, 56);
            this.trackBarAlpha.TabIndex = 9;
            // 
            // tableLayoutPanelParamters
            // 
            this.tableLayoutPanelParamters.ColumnCount = 2;
            this.tableLayoutPanelParamters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.Location = new System.Drawing.Point(527, 15);
            this.tableLayoutPanelParamters.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelParamters.Name = "tableLayoutPanelParamters";
            this.tableLayoutPanelParamters.RowCount = 2;
            this.tableLayoutPanelParamters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelParamters.Size = new System.Drawing.Size(160, 123);
            this.tableLayoutPanelParamters.TabIndex = 8;
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelConfiguration.Location = new System.Drawing.Point(15, 58);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(464, 32);
            this.labelConfiguration.TabIndex = 7;
            this.labelConfiguration.Text = "Konfiguracja parametrów dla AO";
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
            // trackBarDelta
            // 
            this.trackBarDelta.Location = new System.Drawing.Point(130, 199);
            this.trackBarDelta.Maximum = 5;
            this.trackBarDelta.Name = "trackBarDelta";
            this.trackBarDelta.Size = new System.Drawing.Size(285, 56);
            this.trackBarDelta.TabIndex = 10;
            // 
            // trackBarBeta
            // 
            this.trackBarBeta.Location = new System.Drawing.Point(130, 266);
            this.trackBarBeta.Maximum = 5;
            this.trackBarBeta.Name = "trackBarBeta";
            this.trackBarBeta.Size = new System.Drawing.Size(285, 56);
            this.trackBarBeta.TabIndex = 11;
            // 
            // btnSolve
            // 
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSolve.Location = new System.Drawing.Point(479, 238);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(107, 39);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "Testuj";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAlpha.Location = new System.Drawing.Point(35, 137);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(89, 32);
            this.labelAlpha.TabIndex = 12;
            this.labelAlpha.Text = "alpha";
            this.labelAlpha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDelta
            // 
            this.labelDelta.AutoSize = true;
            this.labelDelta.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDelta.Location = new System.Drawing.Point(35, 199);
            this.labelDelta.Name = "labelDelta";
            this.labelDelta.Size = new System.Drawing.Size(89, 32);
            this.labelDelta.TabIndex = 13;
            this.labelDelta.Text = "delta";
            this.labelDelta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBeta.Location = new System.Drawing.Point(35, 266);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(74, 32);
            this.labelBeta.TabIndex = 14;
            this.labelBeta.Text = "beta";
            this.labelBeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblResult.Location = new System.Drawing.Point(12, 446);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 32);
            this.lblResult.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 573);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.panelAlgorithmParameters);
            this.Controls.Add(this.panelAlgorithmSelection);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelAlgorithmSelection.ResumeLayout(false);
            this.panelAlgorithmSelection.PerformLayout();
            this.panelAlgorithmParameters.ResumeLayout(false);
            this.panelAlgorithmParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TrackBar trackBarAlpha;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.Label labelDelta;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TrackBar trackBarBeta;
        private System.Windows.Forms.TrackBar trackBarDelta;
        private System.Windows.Forms.Label lblResult;
    }
}

