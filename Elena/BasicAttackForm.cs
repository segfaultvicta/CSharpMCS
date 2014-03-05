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
    public partial class BasicAttackForm : Form
    {
        public BasicAttackForm()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
        }

        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }

        internal void SetTypeByDie(DieType dieType)
        {
            switch (dieType.ToString())
            {
                case "d8":
                    this.comboBox1.SelectedIndex = 0;
                    break;

                case "d10":
                    this.comboBox1.SelectedIndex = 1;
                    break;

                case "d12":
                    this.comboBox1.SelectedIndex = 2;
                    break;
            }
        }
    }
}
