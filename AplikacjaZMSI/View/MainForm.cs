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
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAO_Click(object sender, EventArgs e)
        {
            panelAlgorithmSelection.Visible = false;
            panelAlgorithmParameters.Visible = true;

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelAlgorithmParameters.Visible = false;
            panelAlgorithmSelection.Visible = true;
        }
    }
}
