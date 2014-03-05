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
    public enum AdditionalCost { MP, Delay }

    public partial class InputAdditionalCost : Form
    {
        private AdditionalCost cost;

        public InputAdditionalCost(int delayCost, int mpCost)
        {
            InitializeComponent();
            mpChoice.Text = mpCost.ToString() + " MP";
            delayChoice.Text = delayCost.ToString() + " Delay";
        }

        public AdditionalCost Result()
        {
            return cost;
        }

        private void delayChoice_Click(object sender, EventArgs e)
        {
            cost = AdditionalCost.Delay;
        }

        private void mpChoice_Click(object sender, EventArgs e)
        {
            cost = AdditionalCost.MP;
        }


    }
}
