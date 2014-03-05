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
    public partial class InputRanks : Form
    {
        private int baseSlots = 1;
        private decimal slotsPerRank = 1;
        private int slots;
        private int slotsSave;
        private int slotSurcharge = 0;

        public int Ranks
        {
            get
            {
                return (int)ranksBox.Value;
            }
        }

        public decimal SlotsPerRank
        {
            set
            {
                slotsPerRank = value;
            }
        }

        public int BaseSlotCost
        {
            set
            {
                baseSlots = value;
            }
        }

        public int BaseResult
        {
            set
            {
                ranksBox.Minimum = value;
                Recalculate();
            }
            get
            {
                return (int)ranksBox.Minimum;
            }
        }

        public InputRanks()
        {
            InitializeComponent();
            BaseResult = 1;
        }

        public int NumberOfRanks() 
        {
            return (int)ranksBox.Value;
        }

        private void slotsBox_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            slots = slotSurcharge + baseSlots + (int)((Ranks - BaseResult) * slotsPerRank);
            resultText.Text = "Slot Cost: " + slots.ToString();
        }

        public int SlotSurcharge
        {
            set
            {
                slotSurcharge = value;
                Recalculate();
            }
        }

        public int Slots
        {
            get
            {
                return slots;
            }
        }

        public int RanksPastBase
        {
            get
            {
                return (int)(Ranks - BaseResult);
            }
        }

        public void SetRanks(int ranks)
        {
            ranksBox.Value = ranks;
            slotsSave = Slots;
        }

        public bool AllowSlotDifference(int slotsRemaining)
        {
            return (Slots - slotsSave <= slotsRemaining);
        }
    }
}
