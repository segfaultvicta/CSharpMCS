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
    public partial class InputEnhanceStatus : Form
    {
		private Dictionary<String, int> costs = new Dictionary<string, int>();

        public InputEnhanceStatus()
        {
            costs.Add("Float", 2);
            costs.Add("Regen", 2);
            costs.Add("Refresh", 2);
            costs.Add("Brave", 2);
            costs.Add("Faith", 2);
            costs.Add("Vigilance", 2);
            costs.Add("Reflect", 4);
            costs.Add("Vanish", 4);
            costs.Add("Protect", 2);
            costs.Add("Haste", 2);
            costs.Add("Shell", 2);
            costs.Add("Bar-Element", 2);
            costs.Add("Accuracy Up", 2);
            costs.Add("Evasion Up", 2);
            costs.Add("Critical Up", 2);
            costs.Add("Element Sword", 2);
            costs.Add("Veil", 2);
            costs.Add("Blink", 4);
            costs.Add("Tranq", 2);
            costs.Add("Dread Spikes", 2);
            costs.Add("Resist", 4);
            costs.Add("Other Sword", 2);
            costs.Add("Reraise", 2);
            costs.Add("Bubble", 4);
            costs.Add("Enhance Element", 2);
            InitializeComponent();
        }
        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }
        public int SlotCost()
        {
            String chosen = this.comboBox1.SelectedItem.ToString();
            return costs[chosen];
        }
    }
}
