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
    public partial class InputAddedStatus : Form
    {
        private String baseStatus = "Pick A Status";
        private int durationModifier = 0;
        private int cosModifier = 0;
        private int moreDelayModifier = 0;
        private int potencyModifier = 0;
        private Boolean gravity50 = false;
        private List<String> expensiveStrings = new List<String>();
        private List<String> effectStrings = new List<String>();
        private bool warning = false;

        public InputAddedStatus(bool mpAllowed)
        {
            InitializeComponent();
            delayButton.Checked = true;
            if (!mpAllowed)
            {
                mpButton.Enabled = false;
                mpCostText.ForeColor = Color.DarkGray;
                mpCostLabel.ForeColor = Color.DarkGray;
            }
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
            baseStatusButton.Text = "Status: " + baseStatus;
            warning = false;

            if (baseStatus == "Pick A Status")
            {
                warning = true;
            }

            //grey and zero out appropriate text boxes as per chosen status
            if (baseStatus == "Delay")
            {
                moreDelayText.ForeColor = Properties.Settings.Default.TextColour;
                moreDelaySlider.Enabled = true;
            }
            else
            {
                moreDelaySlider.Enabled = false;
                moreDelayText.ForeColor = System.Drawing.Color.DarkGray;
            }

            if (baseStatus == "Gravity")
            {
                gravityText.ForeColor = Properties.Settings.Default.TextColour;
                gravityCheckBox.Enabled = true;
            }
            else
            {
                gravityText.ForeColor = System.Drawing.Color.DarkGray;
                gravityCheckBox.Enabled = false;
            }

            if (effectStrings.Contains(baseStatus))
            {
                durationText.ForeColor = System.Drawing.Color.DarkGray;
                potencyText.ForeColor = System.Drawing.Color.DarkGray;
                durationSlider.Enabled = false;
                potencySlider.Enabled = false;
            }
            else
            {
                durationText.ForeColor = Properties.Settings.Default.TextColour;
                potencyText.ForeColor = Properties.Settings.Default.TextColour;
                durationSlider.Enabled = true;
                potencySlider.Enabled = true;
            }

            //update current Summary, slot cost, delay and MP costs
            summaryText.Text = "Added Status: " + StatusString() + " CoS " + CoS();
            slotCostText.Text = SlotCost().ToString();
            delayText.Text = DelayCost().ToString();
            mpCostText.Text = MPScale().ToString();

            if (warning)
            {
                okButton.ForeColor = System.Drawing.Color.Firebrick;
                okButton.BackColor = System.Drawing.Color.MistyRose;
            }
            else
            {
                okButton.ForeColor = Properties.Settings.Default.TextColour;
                okButton.BackColor = Properties.Settings.Default.BackColour;
            }
        }

        public String FinalDelay()
        {
            if (baseStatus != "Delay")
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

        public String Duration()
        {
            if (baseStatus == "Stone") 
            {
                return " (U)";
            }
            else if (effectStrings.Contains(baseStatus))
            {
                return "";
            }
            else
            {
                int duration = 4;
                if (durationSlider.Enabled)
                {
                    duration += (int)durationSlider.Value;
                }
                if (potencySlider.Enabled)
                {
                    duration -= (int)potencySlider.Value;
                }
                if (duration < 1)
                {
                    warning = true;
                }
                return " (" + duration.ToString() + ")";
            }
        }

        public String CoS()
        {
            int cos = 30;
            if (cosSlider.Enabled)
            {
                cos += (10*(int)cosSlider.Value);
            }
            if(potencySlider.Enabled) 
            {
                cos += (30 * (int)potencySlider.Value);
            }
            if (cos > 100)
            {
                warning = true;
            }
            return cos.ToString();
        }

        public int MPScale()
        {
            int mp = 10;
            if (potencySlider.Enabled)
            {
                mp += (3 * (int)potencySlider.Value);
            }
            if (cosSlider.Enabled)
            {
                mp += (3 * (int)cosSlider.Value);
            }
            if (durationSlider.Enabled)
            {
                mp += (3 * (int)durationSlider.Value);
            }
            if (moreDelaySlider.Enabled)
            {
                mp += (3 * (int)moreDelaySlider.Value);
            }
            if (expensiveStrings.Contains(baseStatus))
            {
                mp *= 2;
            }
            return mp;
        }

        public int DelayCost()
        {
            int delay = 3;
            if (potencySlider.Enabled)
            {
                delay += (int)potencySlider.Value;
            }
            if (cosSlider.Enabled)
            {
                delay += (int)cosSlider.Value;
            }
            if (durationSlider.Enabled)
            {
                delay += (int)durationSlider.Value;
            }
            if (moreDelaySlider.Enabled)
            {
                delay += (int)moreDelaySlider.Value;
            }
            if (expensiveStrings.Contains(baseStatus))
            {
                delay *= 2;
            }
            return delay;
        }

        public String GravityPower()
        {
            if (baseStatus != "Gravity")
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
            return baseStatus + GravityPower() + Duration() + FinalDelay();
        }

        public int SlotCost()
        {
            int slots = 1;
            if (potencySlider.Enabled)
            {
                slots += (int)potencySlider.Value;
            }
            if (cosSlider.Enabled)
            {
                slots += (int)cosSlider.Value;
            }
            if (durationSlider.Enabled)
            {
                slots += (int)durationSlider.Value;
            }
            if (moreDelaySlider.Enabled)
            {
                slots += (int)moreDelaySlider.Value;
            }
            if (gravity50 && gravityCheckBox.Enabled)
            {
                slots++;
            }
            if (expensiveStrings.Contains(baseStatus))
            {
                slots += 2;
            }
            return slots;
        }

        private void durationSlider_ValueChanged(object sender, EventArgs e)
        {
            durationModifier = (int)durationSlider.Value;
            UpdateData();
        }

        private void potencySlider_ValueChanged(object sender, EventArgs e)
        {
            potencyModifier = (int)potencySlider.Value;
            UpdateData();
        }

        private void cosSlider_ValueChanged(object sender, EventArgs e)
        {
            cosModifier = (int)cosSlider.Value;
            UpdateData();
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
            InputStatus status = new InputStatus(true);
            if (status.ShowDialog(this) == DialogResult.OK)
            {
                baseStatus = status.ChosenString();
            }
            if (baseStatus == "Delay +5")
            {
                baseStatus = "Delay";
            }
            UpdateData();
        }

		public bool Gravity 
		{
			get
			{
				return gravityCheckBox.Checked;
			}
			set
			{
				gravityCheckBox.Checked = value;
			}
		}

		public string BaseStatus { get { return baseStatus; } set { baseStatus = value; UpdateData(); } }

		public int CoSRanks { get { return (int)cosSlider.Value; } set { cosSlider.Value = value; } }

		public int DurRanks { get { return (int)durationSlider.Value; } set { durationSlider.Value = value; } }

		public int PotRanks { get { return (int)potencySlider.Value; } set { potencySlider.Value = value; } }

		public int DelRanks { get { return (int)moreDelaySlider.Value; } set { moreDelaySlider.Value = value; } }
	}
}
