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
    public partial class InputEffectType : Form
    {
        public InputEffectType()
        {
            InitializeComponent();
        }
        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }
        public AttackType SelectedType()
        {
            if (this.ChosenString() == "Physical")
            {
                return AttackType.PhysicalEffect;
            }
            else 
            {
                return AttackType.MagicalEffect;
            }
        }
    }
}
