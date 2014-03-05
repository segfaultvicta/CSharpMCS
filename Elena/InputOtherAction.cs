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
	public partial class InputOtherAction : Form
	{
		private string[] crystalCollection = new string[] { "ACN", "ARC", "BLM", "CHM", "COR", "DNC", "DRK", "DRG", "GEO", "GLA", "ILL",
															"KGT", "MNK", "NIN", "ORC", "PLD", "RAV", "SAM", "SCH", "SEN", "SNI", "SMN",
															"SYN", "THF", "TIM", "WAR", "WHM"};
		private string[] jobCollection = new string[] { "BRD", "BLM", "CHM", "DNC", "DRG", "GRN", "MRD", "MNK", "NIN", "PLD", "PVR",
														"RNG", "RAV", "RDM", "SAM", "SEN", "SOL", "SMN", "THM", "THF", "WAR", "WHM" };
		private string[] classCollection = new string[] { "ALC", "ARC", "BLM", "BLU", "GMB", "LNC", "NIN", "PLD", "RDM", "SON", "SMN", "WAR", "WHM" };

		private Dictionary<int, TargetType> targetLookup = new Dictionary<int, TargetType>();
		private Dictionary<TargetType, int> reverseTargetLookup = new Dictionary<TargetType, int>();
		private TargetType targetType = TargetType.Null;

		private Element element = Element.Null;
		private List<Keyword> keywords = new List<Keyword>();

		private Dictionary<int, AbilityType> typeLookup = new Dictionary<int, AbilityType>();

		private Dictionary<int, AttackType> attackLookup = new Dictionary<int, AttackType>();
		private Dictionary<AttackType, int> reverseAttackLookup = new Dictionary<AttackType, int>();
		private Dictionary<int, DieType> dieTypeLookup = new Dictionary<int, DieType>();
		private Dictionary<DieType, int> reverseDieTypeLookup = new Dictionary<DieType, int>();

		private Dictionary<int, Keyword> keywordLookup = new Dictionary<int, Keyword>();
		private bool keywordsActive = false;

		private int slotsRemaining;

		public InputOtherAction()
		{
			InitializeComponent();
			presetSystem.SelectedIndex = 0;
			targetLookup.Add(-1, TargetType.Null);
			targetLookup.Add(0, TargetType.Single);
			targetLookup.Add(1, TargetType.Group);
			targetLookup.Add(2, TargetType.Row);
			targetLookup.Add(3, TargetType.Group);
			targetLookup.Add(4, TargetType.All);
			targetLookup.Add(5, TargetType.Self);
			targetLookup.Add(6, TargetType.Random);
			reverseTargetLookup.Add(TargetType.Null, -1);
			reverseTargetLookup.Add(TargetType.Single, 0);
			reverseTargetLookup.Add(TargetType.Group, 1);
			reverseTargetLookup.Add(TargetType.Row, 2);
			reverseTargetLookup.Add(TargetType.All, 4);
			reverseTargetLookup.Add(TargetType.Self, 5);
			reverseTargetLookup.Add(TargetType.Random, 6);
			typeLookup.Add(0, AbilityType.Action);
			typeLookup.Add(1, AbilityType.Support);
			typeLookup.Add(2, AbilityType.Reaction);
			attackLookup.Add(0, AttackType.Physical);
			attackLookup.Add(1, AttackType.Magical);
			attackLookup.Add(2, AttackType.PhysicalEffect);
			attackLookup.Add(3, AttackType.MagicalEffect);
			reverseAttackLookup.Add(AttackType.Physical, 0);
			reverseAttackLookup.Add(AttackType.Magical, 1);
			reverseAttackLookup.Add(AttackType.PhysicalEffect, 2);
			reverseAttackLookup.Add(AttackType.MagicalEffect, 3);
			statSelect.SelectedIndex = 0;
			dieTypeLookup.Add(-1, DieType.Null);
			dieTypeLookup.Add(0, DieType.d6);
			dieTypeLookup.Add(1, DieType.d8);
			dieTypeLookup.Add(2, DieType.d10);
			dieTypeLookup.Add(3, DieType.d12);
			reverseDieTypeLookup.Add(DieType.d12, 3);
			reverseDieTypeLookup.Add(DieType.d10, 2);
			reverseDieTypeLookup.Add(DieType.d8, 1);
			reverseDieTypeLookup.Add(DieType.d6, 0);
			reverseDieTypeLookup.Add(DieType.Null, -1);
			keywordLookup.Add(0, Keyword.Technique);
			keywordLookup.Add(1, Keyword.Weapon);
			keywordLookup.Add(2, Keyword.Magic);
			keywordLookup.Add(3, Keyword.Elemental);
			keywordLookup.Add(4, Keyword.StatusEffect);
			keywordLookup.Add(5, Keyword.Enhancement);
			keywordLookup.Add(6, Keyword.Aimed);
			keywordLookup.Add(7, Keyword.Drain);
			modsPanel.Visible = false;
			damageCodePanel.Visible = true;
		}

		internal int SlotCost
		{
			get
			{
				return (int)slotCostField.Value;
			}
			set
			{
				slotCostField.Value = value;
			}
	  
		}

		internal string AbilityName
		{
			get
			{
				return nameBox.Text;
			}
			set
			{
				char[] trimArray = { '[', ']' };
				nameBox.Text = value.Trim(trimArray);
			}
		}

		internal int Delay
		{
			get
			{
				return (int)delaySpinner.Value;
			}
			set
			{
				delaySpinner.Value = (decimal)value;
			}
		}

		internal AbilityType AbilityType
		{
			get
			{
				return typeLookup[tabControl1.SelectedIndex];
			}
			set
			{
				tabControl1.SelectTab("tab" + value.ToString());
			}
		}

		internal AttackType AttackType
		{
			get 
			{
				return attackLookup[statSelect.SelectedIndex];
			}
			set
			{
				statSelect.SelectedIndex = reverseAttackLookup[value];
			}
		}

		internal int Floor
		{
			get
			{
				return (int)floorSpinner.Value;
			}
			set
			{
				floorSpinner.Value = (decimal)value;
			}
		}

		internal int MP
		{
			get
			{
				return (int)mpSpinner.Value;
			}
			set
			{
				mpSpinner.Value = value;
			}
		}

		internal int MPPerTier
		{
			get 
			{
				return (int)mpPerTierSpinner.Value;
			}
			set
			{
				mpPerTierSpinner.Value = value;
			}
		}

		internal int BasePower
		{
			get 
			{
				return (int)powerSpinner.Value;
			}
			set
			{
				powerSpinner.Value = value;
			}
		}

		internal int PowerPerTier
		{
			get
			{
				return (int)pptSpinner.Value;
			}
			set
			{
				pptSpinner.Value = value;
			}
		}

		internal TargetType TargetType
		{
			get 
			{
				return targetType;
			}
			set
			{
				targetType = value;
				targetBox.SelectedIndex = reverseTargetLookup[value];
			}
		}

		internal int CoS
		{
			get 
			{
				return (int)cosSpinner.Value;
			}
			set
			{
				cosSpinner.Value = value;
			}
		}

		internal int Dice
		{
			get 
			{
				return (int)diceSpinner.Value;
			}
			set
			{
				diceSpinner.Value = value;
			}
		}

		internal int DicePerTier
		{
			get 
			{
				return (int)dptSpinner.Value;
			}
			set
			{
				dptSpinner.Value = value;
			}
		}

		internal int PowerMod
		{
			get 
			{
				return (int)powerModSpinner.Value;
			}
			set
			{
				powerModSpinner.Value = value;
			}
		}

		internal int PowerModPerTier
		{
			get 
			{
				return (int)powerModPerTierSpinner.Value;
			}
			set
			{
				powerModPerTierSpinner.Value = value;
			}
		}

		internal int DieMod
		{
			get 
			{
				return (int)diceModSpinner.Value;
			}
			set
			{
				diceModSpinner.Value = value;
			}
		}

		internal int DieModPerTier
		{
			get 
			{
				return (int)diceModPerTierSpinner.Value;
			}
			set
			{
				diceModPerTierSpinner.Value = value;
			}
		}

		internal decimal PowerMultiplier
		{
			get 
			{
				return powerMultSpinner.Value;
			}
			set
			{
				powerMultSpinner.Value = value;
			}
		}

		internal int DelayMod
		{
			get 
			{
				return (int)delaySpinner.Value;
			}
			set
			{
				delaySpinner.Value = value;
			}
		}

		internal int FloorMod
		{
			get 
			{
				return (int)floorSpinner.Value;
			}
			set
			{
				floorSpinner.Value = value;
			}
		}

		internal int CoSMod
		{
			get
			{
				return (int)cosSpinner.Value;
			}
			set
			{
				cosSpinner.Value = value;
			}
		}

		internal DieType DieType
		{
			get
			{
				return dieTypeLookup[diceType.SelectedIndex];
			}
			set
			{
				diceType.SelectedIndex = reverseDieTypeLookup[value];
			}
		}

		internal string Notes
		{
			get
			{
				return notesBox.Text;
			}
			set
			{
				notesBox.Text = value;
			}
		}

		internal Element Element
		{
			get
			{
				return element;
			}
			set
			{
				element = value;
				if (element != Elena.Element.Null)
				{
					elementText.Text = "Element: " + element.ToString();
				}
				else
				{
					elementText.Text = "Element: None";
				}
			}
		}

		internal int CT 
		{ 
			get 
			{ 
				return (int)ctSpinner.Value; 
			}
			set
			{
				ctSpinner.Value = value;
			}
		}

		private void presetSystem_SelectedIndexChanged(object sender, EventArgs e)
		{
			presetTLA.Items.Clear();
			switch (presetSystem.SelectedIndex)
			{
				case 0:
					presetTLA.Items.AddRange(crystalCollection);
					presetTLA.SelectedIndex = 0;
					break;
				case 1:
					presetTLA.Items.AddRange(jobCollection);
					presetTLA.SelectedIndex = 0;
					break;
				case 2:
					presetTLA.Items.AddRange(classCollection);
					presetTLA.SelectedIndex = 0;
					break;
			}
		}

		private void presetTLA_SelectedIndexChanged(object sender, EventArgs e)
		{
			string system = presetSystem.SelectedItem.ToString();
			string tla = presetTLA.SelectedItem.ToString();
			List<String> abilities = GrimoireHandler.AbilityList(system, tla);
			presetAbil.Items.Clear();
			presetAbil.Items.AddRange(abilities.ToArray());
			if (presetAbil.Items.Count > 0)
			{
				presetAbil.SelectedIndex = 0;
			}
		}


		private void presetAbil_SelectedIndexChanged(object sender, EventArgs e)
		{
			string system = presetSystem.SelectedItem.ToString();
			string tla = presetTLA.SelectedItem.ToString();
			string abil = presetAbil.SelectedItem.ToString();
			abil = abil.Remove(abil.IndexOf('(')).Trim();
			LoadAbility(system, tla, abil);
			if (GrimoireHandler.AllowLoad(system, tla, abil))
			{
				LoadAbility(system, tla, abil);
			}
		}

		private void LoadAbility(string system, string job, string abil)
		{
			GrimoireAbility ability = GrimoireHandler.Ability(system, job, abil);
			AbilityName = ability.Name;
			SlotCost = ability.SlotCost;
			Notes = ability.Notes;
			DeactivateKeywords();
			Keywords = ability.Keywords;
			ActivateKeywords();
			AbilityType = ability.AbilityType;
			Element = ability.Element;
			if (AbilityType == AbilityType.Action)
			{
				if (Keywords.Contains(Keyword.Weapon))
				{
					DelayMod = ability.Delay;
					FloorMod = ability.Floor;
					MP = ability.MP;
					MPPerTier = ability.MPPerTier;
					CT = ability.CT;
					CoSMod = ability.CoS;
					TargetType = ability.Target;
					DieMod = ability.Dice;
					DieModPerTier = ability.DicePerTier;
					PowerMod = ability.Power;
					PowerModPerTier = ability.PowerPerTier;
					PowerMultiplier = ability.Multiplier;
				}
				else
				{
					Delay = ability.Delay;
					Floor = ability.Floor;
					MP = ability.MP;
					MPPerTier = ability.MPPerTier;
					CT = ability.CT;
					CoS = ability.CoS;
					TargetType = ability.Target;
					DieType = ability.DieType;
					AttackType = ability.AttackType;
					Dice = ability.Dice;
					DicePerTier = ability.DicePerTier;
					BasePower = ability.Power;
					PowerPerTier = ability.PowerPerTier;
				}
			}
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{
			textBox3.Text = "For the moment, Support abilities solely have Notes, a Slot Cost, and a Name, so there's nothing that needs to go here. If your Support Ability modifies damage, you'll have to do this by hand.";
		}

		private void keywordsList_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Checked)
			{
				if (keywordsActive)
				{
					keywords.Add(keywordLookup[e.Index]);
					if (keywordLookup[e.Index] == Keyword.Magic)
					{
						keywords.Add(Keyword.Spell);
					}
					if (keywordLookup[e.Index] == Keyword.Elemental)
					{
						InputElement d = new InputElement();
						d.StartPosition = FormStartPosition.CenterParent;
						if (d.ShowDialog() == DialogResult.OK)
						{
							Element = d.SelectedElement();
						}
						else
						{
							Element = Element.Null;
							keywords.Remove(Keyword.Elemental);
							keywordsList.SetItemChecked(e.Index, false);
						}
					}
				}
			}
			else
			{
				keywords.Remove(keywordLookup[e.Index]);
				if (keywordLookup[e.Index] == Keyword.Magic)
				{
					keywords.Remove(Keyword.Spell);
				}
				if (keywordLookup[e.Index] == Keyword.Elemental)
				{
					Element = Element.Null;
				}
			}
			this.SynchroniseWeaponKeyword();
		}

		private void targetBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			targetType = targetLookup[targetBox.SelectedIndex];
		}


		internal List<Keyword> Keywords
		{
			get
			{
				return keywords;
			}
			set
			{
				keywords = value;
				foreach (KeyValuePair<int, Keyword> pair in keywordLookup)
				{
					keywordsList.SetItemChecked(pair.Key, keywords.Contains(pair.Value));
				}
				this.SynchroniseWeaponKeyword();
			}
		}

		private void SynchroniseWeaponKeyword()
		{
			if (keywords.Contains(Keyword.Weapon))
			{
				delayText.Text = "D +/- F";
				cosText.Text = "CoS Mod";
				damageCodePanel.Visible = false;
				modsPanel.Visible = true;
			}
			else
			{
				delayText.Text = "D      F";
				cosText.Text = "Base CoS";
				damageCodePanel.Visible = true;
				modsPanel.Visible = false;
			}
		}

		public void ActivateKeywords()
		{
			keywordsActive = true;
		}

		public void DeactivateKeywords()
		{
			keywordsActive = false;
		}

		private void statSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (statSelect.SelectedIndex == 2 || statSelect.SelectedIndex == 3)
			{
				diceSpinner.Enabled = false;
				diceType.Enabled = false;
				dptSpinner.Enabled = false;
				pptSpinner.Enabled = false;
				powerSpinner.Enabled = false;
			}
			else
			{
				diceSpinner.Enabled = true;
				diceType.Enabled = true;
				dptSpinner.Enabled = true;
				pptSpinner.Enabled = true;
				powerSpinner.Enabled = true;
			}
		}

		public int SlotsRemaining
		{
			get
			{
				return slotsRemaining;
			}
			set
			{
				slotsRemaining = value;
			}
		}
	}
}
