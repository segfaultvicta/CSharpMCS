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
    public partial class InputElementFreestyle : Form
    {
        private int slots = 0;
        private bool weakApplied;
        ElementMod fireMod = ElementMod.None;
        ElementMod iceMod = ElementMod.None;
        ElementMod lightningMod = ElementMod.None;
        ElementMod waterMod = ElementMod.None;
        ElementMod holyMod = ElementMod.None;
        ElementMod shadowMod = ElementMod.None;

        public InputElementFreestyle()
        {
            InitializeComponent();
            fireBox.SelectedIndex = 1;
            iceBox.SelectedIndex = 1;
            lightningBox.SelectedIndex = 1;
            waterBox.SelectedIndex = 1;
            holyBox.SelectedIndex = 1;
            shadowBox.SelectedIndex = 1;
        }

        public ElementMod Fire
        {
            get
            {
                return fireMod;
            }
        }
        public ElementMod Ice
        {
            get
            {
                return iceMod;
            }
        }
        public ElementMod Lightning
        {
            get
            {
                return lightningMod;
            }
        }
        public ElementMod Water
        {
            get
            {
                return waterMod;
            }
        }
        public ElementMod Holy
        {
            get
            {
                return holyMod;
            }
        }
        public ElementMod Shadow
        {
            get
            {
                return shadowMod;
            }
        }

        public int SlotCost()
        {
            return slots;
        }

        private ElementMod LookupMod(int index)
        {
            switch (index)
            {
                case 0:
                    return ElementMod.Weak;

                case 1:
                    return ElementMod.None;

                case 2:
                    return ElementMod.Resist;

                case 3:
                    return ElementMod.Immune;

                case 4:
                    return ElementMod.Absorb;
            }
            return ElementMod.None;
        }

		private int LookupIndex(ElementMod mod)
		{
			switch (mod)
			{
				case ElementMod.Weak:
					return 0;
				case ElementMod.None:
					return 1;
				case ElementMod.Resist:
					return 2;
				case ElementMod.Immune:
					return 3;
				case ElementMod.Absorb:
					return 4;
				default:
					return 1;
			}
		}

        private void selectedIndexChanged(object sender, EventArgs e)
        {
            fireMod = LookupMod(fireBox.SelectedIndex);
            iceMod = LookupMod(iceBox.SelectedIndex);
            lightningMod = LookupMod(lightningBox.SelectedIndex);
            waterMod = LookupMod(waterBox.SelectedIndex);
            holyMod = LookupMod(holyBox.SelectedIndex);
            shadowMod = LookupMod(shadowBox.SelectedIndex);
            slots = 0;
            weakApplied = false;
            slots += LookupCost(fireMod);
            slots += LookupCost(iceMod);
            slots += LookupCost(lightningMod);
            slots += LookupCost(waterMod);
            slots += LookupCost(holyMod);
            slots += LookupCost(shadowMod);

            slotCost.Text = slots.ToString();
        }

        private int LookupCost(ElementMod e)
        {
            switch (e)
            {
                case ElementMod.Weak:
                    if (weakApplied)
                    {
                        return -1;
                    }
                    else
                    {
                        weakApplied = true;
                        return -2;
                    }
                
                case ElementMod.None:
                    return 0;

                case ElementMod.Resist:
                    return 2;

                case ElementMod.Immune:
                    return 3;

                case ElementMod.Absorb:
                    return 4;

                default:
                    return 0;
            }
        }

		internal void LoadElements(Dictionary<Element, ElementMod> properties)
		{
			fireBox.SelectedIndex = LookupIndex(properties[Element.Fire]);
			waterBox.SelectedIndex = LookupIndex(properties[Element.Water]);
			iceBox.SelectedIndex = LookupIndex(properties[Element.Ice]);
			lightningBox.SelectedIndex = LookupIndex(properties[Element.Lightning]);
			holyBox.SelectedIndex = LookupIndex(properties[Element.Holy]);
			shadowBox.SelectedIndex = LookupIndex(properties[Element.Shadow]);
		}
	}
}
