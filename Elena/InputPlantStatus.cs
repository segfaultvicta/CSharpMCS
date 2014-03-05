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
    public partial class InputPlantStatus : Form
    {
        public InputPlantStatus()
        {
            InitializeComponent();
        }

        public int Offset()
        {
            return this.comboBox1.SelectedIndex;
        }
    }
}
