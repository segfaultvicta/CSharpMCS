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
    public partial class InputStatus : Form
    {
        public InputStatus(bool includeDelay)
        {
            InitializeComponent();
            if (includeDelay)
            {
                this.comboBox1.Items.Add("Delay +5");
            }
        }
        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }
    }
}
