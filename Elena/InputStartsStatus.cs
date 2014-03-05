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
    public partial class InputStartsStatus : Form
    {
		private Dictionary<String, int> costs = new Dictionary<string, int>();
        private int slotsSave;

        public InputStartsStatus()
        {
            costs.Add("Float (5)", 2);
            costs.Add("Regen (5)", 4);
            costs.Add("Refresh (5)", 4);
            costs.Add("Brave (5)", 4);
            costs.Add("Faith (5)", 4);
            costs.Add("Vigilance (5)", 4);
            costs.Add("Reflect (5)", 4);
            costs.Add("Vanish (5)", 4);
            costs.Add("Protect (5)", 4);
            costs.Add("Haste (5)", 4);
            costs.Add("Shell (5)", 4);
            costs.Add("Bar-Element (5)", 4);
            costs.Add("Accuracy Up (5)", 4);
            costs.Add("Evasion Up (5)", 4);
            costs.Add("Critical Up (5)", 4);
            costs.Add("Element Sword (5)", 4);
            costs.Add("En-Element (5)", 4);
            costs.Add("Veil (4)", 6);
            costs.Add("Blink (4)", 6);
            costs.Add("Tranq (4)", 6);
            costs.Add("Dread Spikes (4)", 6);
            costs.Add("Resist (4)", 6);
            InitializeComponent();
        }
        public String ChosenString()
        {
            return this.comboBox1.SelectedItem.ToString();
        }
        public int SlotCost()
        {
            String chosen = this.comboBox1.SelectedItem.ToString();
            return costs[chosen] + SlotCostOffset;
        }

        public void SetStatus(string chosenString)
        {
            this.comboBox1.Text = chosenString;
            slotsSave = SlotCost();
        }

        public bool AllowSlotDifference(int slotsRemaining)
        {
            return (SlotCost() - slotsSave <= slotsRemaining);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            slotCostLabel.Text = SlotCost().ToString();
        }

        public int SlotCostOffset { get; set; }
    }
}
