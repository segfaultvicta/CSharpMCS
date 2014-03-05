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
    public partial class InputSelectAbility : Form
    {
		private Dictionary<int, AbstractAbility> abilities = new Dictionary<int, AbstractAbility>();

        public InputSelectAbility(Monster m)
        {
            InitializeComponent();
            int i = 0;
            foreach (AbstractAbility a in m.Abilities)
            {
                abilities.Add(i, a);
                i++;
                comboBox1.Items.Add(a.ToString());
            }
            comboBox1.SelectedIndex = 0;
        }

        public AbstractAbility GetSelectedAbility()
        {
            try
            {
                return abilities[comboBox1.SelectedIndex];
            }
            catch
            {
                return new NullAbility();
            }
        }
    }
}
