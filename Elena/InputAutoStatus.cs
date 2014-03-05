using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elena
{
    public partial class InputAutoStatus : Form
    {
        public InputAutoStatus()
        {
            InitializeComponent();
        }
        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }

        internal void SetStatus(string chosenString)
        {
            this.comboBox1.Text = chosenString;
        }
    }
}
