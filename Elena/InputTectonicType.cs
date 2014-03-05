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
    public enum TectonicResult { PowerMod, Delay }

    public partial class InputTectonicType : Form
    {
        private TectonicResult result;

        public InputTectonicType()
        {
            InitializeComponent();
        }

        public TectonicResult Result()
        {
            return result;
        }

        private void powerChoice_Click(object sender, EventArgs e)
        {
            result = TectonicResult.PowerMod;
        }

        private void delayChoice_Click(object sender, EventArgs e)
        {
            result = TectonicResult.Delay;
        }

        internal bool NonElemental()
        {
            return checkBox1.Checked;
        }
    }
}
