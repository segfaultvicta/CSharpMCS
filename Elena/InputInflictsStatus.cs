using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Elena
{
	public partial class InputInflictsStatus : Form
	{
		private int moreDelayModifier = 0;
		private Boolean gravity50 = false;
		private List<String> expensiveStrings = new List<String>();
		private List<String> effectStrings = new List<String>();

		public InputInflictsStatus()
		{
			InitializeComponent();
			delayButton.Checked = true;
			expensiveStrings.Add("Sleep");
			expensiveStrings.Add("Stop");
			expensiveStrings.Add("Toad");
			expensiveStrings.Add("Death");
			expensiveStrings.Add("Stone");
			expensiveStrings.Add("Eject");
			expensiveStrings.Add("Near-Fatal");
			effectStrings.Add("Death");
			effectStrings.Add("Libra");
			effectStrings.Add("Near-Fatal");
			effectStrings.Add("Delay");
			effectStrings.Add("Dispel");
			effectStrings.Add("Eject");
			effectStrings.Add("Gravity");
			effectStrings.Add("Push");
			effectStrings.Add("Stone");
			UpdateData();
		}

		public bool CostIsDelay
		{
			get { return delayButton.Checked; }
			set
			{
				if (value == true)
				{
					delayButton.Checked = true;
					mpButton.Checked = false;
				}
				else
				{
					mpButton.Checked = true;
					delayButton.Checked = false;
				}
			}
		}

		private void UpdateData()
		{
			//grey and zero out appropriate text boxes as per chosen status
			if (statusList.Items.Contains("Delay"))
			{
				moreDelayText.ForeColor = Properties.Settings.Default.TextColour;
				moreDelaySlider.Enabled = true;
			}
			else
			{
				moreDelaySlider.Enabled = false;
				moreDelayText.ForeColor = System.Drawing.Color.DarkGray;
			}

			if (statusList.Items.Contains("Gravity"))
			{
				gravityText.ForeColor = Properties.Settings.Default.TextColour;
				gravityCheckBox.Enabled = true;
			}
			else
			{
				gravityText.ForeColor = System.Drawing.Color.DarkGray;
				gravityCheckBox.Enabled = false;
			}
			slotCostText.Text = SlotCost().ToString();
			delayText.Text = DelayCost().ToString();
			mpCostText.Text = MPScale().ToString();
		}

		public String FinalDelay(string status)
		{
			if (status != "Delay")
			{
				return "";
			}
			else
			{
				int delay = 5;
				if (moreDelaySlider.Enabled)
				{
					delay += (5 * (int)moreDelaySlider.Value);
				}
				return " " + delay.ToString();
			}
		}

		public String Duration(string status)
		{
			if (status == "Stone") 
			{
				return " (U)";
			}
			else if (effectStrings.Contains(status))
			{
				return "";
			}
			else
			{
				return " (4)";
			}
		}

		public int MPScale()
		{
			int mp = 7;
			bool doubledCost = false;
			foreach (string status in statusList.Items)
			{
				mp += 3;
				if (expensiveStrings.Contains(status))
				{
					doubledCost = true;
				}
			}
			if (doubledCost)
			{
				mp *= 2;
			}
			return mp;
		}

		public int DelayCost()
		{
			int delay = 2;
			bool doubledCost = false;
			foreach (string status in statusList.Items)
			{
				delay++;
				if (expensiveStrings.Contains(status))
				{
					doubledCost = true;
				}
			}
			if (doubledCost)
			{
				delay *= 2;
			}
			return delay;
		}

		public int CoSMod()
		{
			int cosmod = -10;
			foreach (string status in statusList.Items)
			{
				cosmod -= 10;
			}
			return cosmod;
		}

		public String GravityPower(string status)
		{
			if (status != "Gravity")
			{
				return "";
			}
			else
			{
				if (gravity50)
				{
					return " 50%";
				}
				else
				{
					return " 25%";
				}
			}
		}

		public String StatusString()
		{
			string retval = "";
			int count = 0;
			foreach (string status in statusList.Items)
			{
				retval += status + GravityPower(status) + Duration(status) + FinalDelay(status);
				count++;
				if (count < statusList.Items.Count)
				{
					retval += ", ";
				}
			}
			//return baseStatus + GravityPower() + Duration() + FinalDelay();
			return retval;
		}

		public int SlotCost()
		{
			int slots = 0;
			if (moreDelaySlider.Enabled)
			{
				slots += (int)moreDelaySlider.Value;
			}
			if (gravity50 && gravityCheckBox.Enabled)
			{
				slots++;
			}
			foreach (string status in statusList.Items)
			{
				if (expensiveStrings.Contains(status))
				{
					slots += 3;
				}
				else
				{
					slots++;
				}
			}
			return slots;
		}

		private void moreDelaySlider_ValueChanged(object sender, EventArgs e)
		{
			moreDelayModifier = (int)moreDelaySlider.Value;
			UpdateData();
		}

		private void gravityCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			gravity50 = gravityCheckBox.Checked;
			UpdateData();
		}

		private void baseStatusButton_Click(object sender, EventArgs e)
		{
			InputStatus status = new InputStatus(!statusList.Items.Contains("Delay"));
			if (status.ShowDialog(this) == DialogResult.OK)
			{
				string chosenStatus = status.ChosenString();
				if (chosenStatus == "Delay +5")
				{
					chosenStatus = "Delay";
				}
				statusList.Items.Add(chosenStatus);
			}
			UpdateData();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			statusList.Items.Remove(statusList.SelectedItem);
			UpdateData();
		}

		public void LoadFromString(string statusString)
		{
			string[] statuses = statusString.Split(',');
			Regex rgx = new Regex("[^0-9]");
			foreach (string s in statuses)
			{
				string toAdd = s;
				if (s.Contains("Delay"))
				{
					toAdd = "Delay";
					moreDelaySlider.Enabled = true;
					int delayTotal = Int32.Parse(rgx.Replace(s,""));
					int delayRanks = (delayTotal / 5) - 1;
					moreDelaySlider.Value = delayRanks;
				}
				else if (s.Contains("Gravity"))
				{
					toAdd = "Gravity";
					gravityCheckBox.Enabled = true;
					if (rgx.Replace(s, "") == "50")
					{
						gravityCheckBox.Checked = true;
					}
				}
				else
				{
					try
					{
						toAdd = s.Substring(0, (s.IndexOf("(") - 1)).Trim();
					}
					catch
					{
						toAdd = s.Trim();
					}
				}
				statusList.Items.Add(toAdd);
			}
			UpdateData();
		}
	}
}
