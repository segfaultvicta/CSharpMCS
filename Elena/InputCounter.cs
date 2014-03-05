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
    public partial class InputCounter : Form
    {
        public InputCounter()
        {
            InitializeComponent();
        }

        public int CoSMod()
        {
            return Int32.Parse(textBox2.Text);
        }

        public String Trigger()
        {
            return textBox1.Text;
        }

        internal void SetCoSMod(int cosMod)
        {
            textBox2.Text = cosMod.ToString();
        }

        internal void SetTrigger(string trigger)
        {
            textBox1.Text = trigger;
        }
    }
}
