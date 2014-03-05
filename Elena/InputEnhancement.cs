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
	public partial class InputEnhancement : Form
	{
		private int duration = 5;
		private List<string> surchargeStatuses = new List<string>();
		public InputEnhancement()
		{
			InitializeComponent();
			UpdateData();
			surchargeStatuses.Add("Resist");
			surchargeStatuses.Add("Vanish");
			surchargeStatuses.Add("Bubble");
			surchargeStatuses.Add("Blink");
			surchargeStatuses.Add("Reflect");
		}

		private void UpdateData()
		{
			slotCostText.Text = SlotCost().ToString();
			duration = 6 - statusList.Items.Count;
			durationLabel.Text = duration.ToString();
			if (duration < 3)
			{
				addStatusButton.Enabled = false;
			}
			else
			{
				addStatusButton.Enabled = true;
			}
		}

		public String StatusString
		{
			get
			{
				string retval = "";
				int count = 0;
				foreach (string status in statusList.Items)
				{
					retval += status + " (" + duration.ToString() + ")";
					count++;
					if (count < statusList.Items.Count)
					{
						retval += ", ";
					}
				}
				return retval;
			}
			set
			{
				string toParse = value;
				string[] statuses = toParse.Split(',');
				foreach (string s in statuses)
				{
					string toAdd = s;
					try
					{
						toAdd = s.Substring(0, (s.IndexOf("(") - 1)).Trim();
						statusList.Items.Add(toAdd);
					}
					catch
					{
						//welp
					}
				}
				UpdateData();
			}
		}

		public int SlotCost()
		{
			return statusList.Items.Count + 1 + (HasSurcharge() ? 2 : 0);
		}

		private void baseStatusButton_Click(object sender, EventArgs e)
		{
			InputEnhanceStatus status = new InputEnhanceStatus();
			if (status.ShowDialog() == DialogResult.OK)
			{
				string chosenStatus = status.ChosenString();
				statusList.Items.Add(chosenStatus);
			}
			UpdateData();
		
		}

		private void button2_Click(object sender, EventArgs e)
		{
			statusList.Items.Remove(statusList.SelectedItem);
			UpdateData();
		}

		public bool HasSurcharge()
		{
			foreach (string status in statusList.Items)
			{
				if (surchargeStatuses.Contains(status))
				{
					return true;
				}
			}
			return false;
		}

		public AttackType SelectedType
		{
			get
			{
				if (techButton.Checked)
				{
					return AttackType.PhysicalEffect;
				}
				else
				{
					return AttackType.MagicalEffect;
				}
			}
			set
			{
				if (value == AttackType.PhysicalEffect)
				{
					techButton.Checked = true;
				}
				else
				{
					magspellButton.Checked = true;
				}
			}
		}
	}
}
