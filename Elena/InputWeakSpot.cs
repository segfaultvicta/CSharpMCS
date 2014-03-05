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
    public partial class InputWeakSpot : Form
    {
        public InputWeakSpot()
        {
            InitializeComponent();
        }

        public int Bonus()
        {
            return Int32.Parse(textBox2.Text);
        }

        public String Trigger()
        {
            return textBox1.Text;
        }

        internal void SetBonus(int bonus)
        {
            textBox2.Text = bonus.ToString();
        }

        internal void SetTrigger(string trigger)
        {
            textBox1.Text = trigger;
        }

		public void SetResult(string result)
		{
			resultText.Text = result;
		}

		public string Result()
		{
			return resultText.Text;
		}

		private void result_Leave(object sender, EventArgs e)
		{
			if (resultText.Text == "")
			{
				resultText.Text = "Result (generally negative status (4))";
			}
		}

		private void result_Enter(object sender, EventArgs e)
		{
			if (resultText.Text == "Result (generally negative status (4))")
			{
				resultText.Text = "";
			}
		}
    }
}
