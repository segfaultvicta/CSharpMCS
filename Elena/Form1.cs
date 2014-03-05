using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Elena
{
	public enum Element
	{
		Fire, Water, Lightning, Ice, Holy, Shadow, Null
	}

	public enum ElementMod
	{
		Weak, Resist, Immune, Absorb, None
	}

	public partial class Form1 : Form
	{
		public const String titleBase = "FFRPG 4e MCS Helper v0.7.1 \"Behemoth Flute\" ";

		private Monster monster;
		private bool valid;
		private MonsterProperty selectedProperty = new NullProperty();
		private MonsterAbility selectedAbility = new NullAbility();

		private Assembly asm = Assembly.GetExecutingAssembly();
		private Dictionary<Element, Label> elementLabels = new Dictionary<Element, Label>();
		private Dictionary<ElementMod, Color> modColors = new Dictionary<ElementMod, Color>();

		public Form1()
		{
			monster = new Monster();
			InitializeComponent();
			diffBox.SelectedIndex = 1;
			rankBox.SelectedIndex = 0;
			elementLabels.Add(Element.Fire, fireText);
			elementLabels.Add(Element.Holy, holyText);
			elementLabels.Add(Element.Ice, iceText);
			elementLabels.Add(Element.Lightning, litText);
			elementLabels.Add(Element.Shadow, shadText);
			elementLabels.Add(Element.Water, waterText);
			
			modColors.Add(ElementMod.Absorb, Properties.Settings.Default.AbsorbColour);
			modColors.Add(ElementMod.Immune, Properties.Settings.Default.ImmuneColour);
			modColors.Add(ElementMod.Resist, Properties.Settings.Default.ResistColour);
			modColors.Add(ElementMod.Weak, Properties.Settings.Default.WeakColour);
			modColors.Add(ElementMod.None, Properties.Settings.Default.NormalColour);
			weak_label.ForeColor = modColors[ElementMod.Weak];
			normal_label.ForeColor = modColors[ElementMod.None];
			resist_label.ForeColor = modColors[ElementMod.Resist];
			immune_label.ForeColor = modColors[ElementMod.Immune];
			absorb_label.ForeColor = modColors[ElementMod.Absorb];
			this.UpdateData(false);
		}

		private void levelBox_ValueChanged(object sender, EventArgs e)
		{
			monster.Level = (int)levelBox.Value;
			this.UpdateData();
		}
		private void diffBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int diffIndex = diffBox.SelectedIndex;
			switch (diffIndex)
			{
				case 0:
					//Easy
					monster.Difficulty = new DiffEasy();
					break;

				case 1:
					//Normal
					monster.Difficulty = new DiffNormal();
					break;

				case 2:
					//Tough
					monster.Difficulty = new DiffTough();
					break;
			}
			this.UpdateData();
		}

		private void UpdateDataFromLoad()
		{
			this.UpdateData(false);
			this.nameBox.Text = monster.Name;
			this.levelBox.Value = monster.Level;
			this.diffBox.SelectedIndex = GetIndex(monster.Difficulty);
			this.rankBox.SelectedIndex = GetIndex(monster.Rank);
			this.atkBox.Value = monster.ATK;
			this.vitBox.Value = monster.VIT;
			this.spdBox.Value = monster.SPD;
			this.magBox.Value = monster.MAG;
			this.sprBox.Value = monster.SPR;
			this.descBox.Text = monster.Description;
			this.itemBox.Text = monster.Item;
			this.equipBox.Text = monster.Equip;
			this.dropBox.Text = monster.Drop;
			if (!monster.BasicAttack.IsNull)
			{
				basicAttackButton.ForeColor = Properties.Settings.Default.BackColour;
				basicAttackButton.BackColor = System.Drawing.Color.Transparent;
			}
		}

		private int GetIndex(MonsterProperty monsterProperty)
		{
			Type t = monsterProperty.GetType();
			if (t.Name == "DiffEasy" || t.Name == "RankUnranked")
			{
				return 0;
			}
			if (t.Name == "DiffNormal" || t.Name == "RankMiniboss")
			{
				return 1;
			}
			if (t.Name == "DiffTough" || t.Name == "RankBoss")
			{
				return 2;
			}
			return 0; // if all else fails
		}

		private void UpdateData()
		{
			this.UpdateData(true);
		}

		private void UpdateData(bool valuesChanged)
		{
			monster.ApplyProperties();
			
			//empty out the properties list box
			propsListBox.Items.Clear();

			foreach (MonsterProperty m in monster.Properties)
			{
				propsListBox.Items.Add(m);
			}

			abilsList.Nodes.Clear();
			TreeNode basicNode = new TreeNode(monster.BasicAttack.ToString());
			if (monster.BasicAttack.HasModifiers())
			{
				foreach (AbilityModifier mod in monster.BasicAttack.Modifiers())
				{
					basicNode.Nodes.Add(mod.ToString());
				}
			}
			abilsList.Nodes.Add(basicNode);
			foreach(MonsterAbility a in monster.Abilities) 
			{
				TreeNode abilNode = new TreeNode(a.ToString());
				if (a.HasModifiers())
				{
					foreach (AbilityModifier mod in a.Modifiers())
					{
						abilNode.Nodes.Add(mod.ToString());
					}
					
				}
				abilsList.Nodes.Add(abilNode);
			}

			abilsList.ExpandAll();

			valid = true;
			if (monster.PointsRemaining >= 0)
			{
				labelPL.ForeColor = Properties.Settings.Default.TextColour;
				pointsLeftText.ForeColor = Properties.Settings.Default.TextColour;
			} 
			else
			{
				//sum of stats was out of bounds
				labelPL.ForeColor = Properties.Settings.Default.ErrorTextColour;
				pointsLeftText.ForeColor = Properties.Settings.Default.ErrorTextColour;
				valid = false; //raise some sort of red flag
			}

			bool overMax = false;

			if (monster.ATK <= monster.AttributeMax)
			{
				atkBox.BackColor = Properties.Settings.Default.FieldBackColour;
				atkBox.ForeColor = Properties.Settings.Default.FieldTextColour;
			}
			else
			{
				overMax = true;
				atkBox.BackColor = Color.Pink;
				atkBox.ForeColor = Color.Black;
			}

			if (monster.VIT <= monster.AttributeMax)
			{
				vitBox.BackColor = Properties.Settings.Default.FieldBackColour;
				vitBox.ForeColor = Properties.Settings.Default.FieldTextColour;
			}
			else
			{
				overMax = true;
				vitBox.BackColor = Color.Pink;
				vitBox.ForeColor = Color.Black;
			}

			if (monster.SPD <= monster.AttributeMax)
			{
				spdBox.BackColor = Properties.Settings.Default.FieldBackColour;
				spdBox.ForeColor = Properties.Settings.Default.FieldTextColour;
			}
			else
			{
				overMax = true;
				spdBox.BackColor = Color.Pink;
				spdBox.ForeColor = Color.Black;
			}

			if (monster.MAG <= monster.AttributeMax)
			{
				magBox.BackColor = Properties.Settings.Default.FieldBackColour;
				magBox.ForeColor = Properties.Settings.Default.FieldTextColour;
			}
			else
			{
				overMax = true;
				magBox.BackColor = Color.Pink;
				magBox.ForeColor = Color.Black;
			}

			if (monster.SPR <= monster.AttributeMax)
			{
				sprBox.BackColor = Properties.Settings.Default.FieldBackColour;
				sprBox.ForeColor = Properties.Settings.Default.FieldTextColour;
			}
			else
			{
				overMax = true;
				sprBox.BackColor = Color.Pink;
				sprBox.ForeColor = Color.Black;
			}


			if (overMax)
			{
				valid = false;
				labelMax.ForeColor = Properties.Settings.Default.ErrorTextColour;
				attrMaxText.ForeColor = Properties.Settings.Default.ErrorTextColour;
			}
			else
			{
				labelMax.ForeColor = Properties.Settings.Default.TextColour;
				attrMaxText.ForeColor = Properties.Settings.Default.TextColour;
			}

			tierDisplay.Text = monster.Tier.ToString();
			maxHPText.Text = monster.HP.ToString();
			maxMPText.Text = monster.MP.ToString();
			pointsLeftText.Text = monster.PointsRemaining.ToString();
			attrMaxText.Text = monster.AttributeMax.ToString();
			expText.Text = monster.XPReward.ToString();
			gilText.Text = monster.GilReward.ToString();
			jpText.Text = monster.JPReward.ToString();

			//arm, m.arm, eva, m.eva
			armText.Text = (monster.ARM * 5).ToString();
			marmText.Text = (monster.MARM * 5).ToString();
			evaText.Text = (monster.EVA * 5).ToString();
			mevaText.Text = (monster.MEVA * 5).ToString();
			accText.Text = (monster.ACC * 5).ToString();
			//stats
			atkLabel.Text = monster.ATK.ToString();
			vitLabel.Text = monster.VIT.ToString();
			spdLabel.Text = monster.SPD.ToString();
			magLabel.Text = monster.MAG.ToString();
			sprLabel.Text = monster.SPR.ToString();

			checkBox1.Checked = monster.EquipMultiplier;

			slotsRemaining.Text = monster.SlotsRemaining.ToString();

			fireText.ForeColor = Color.Gray;
			litText.ForeColor = Color.Gray;
			shadText.ForeColor = Color.Gray;
			holyText.ForeColor = Color.Gray;
			iceText.ForeColor = Color.Gray;
			waterText.ForeColor = Color.Gray;

			

			foreach (KeyValuePair<Element, ElementMod> kvp in monster.ElementalProperties)
			{
				elementLabels[kvp.Key].ForeColor = modColors[kvp.Value];
			}

			if (valuesChanged)
			{
				this.Text = titleBase + "[Modified Since Last Save]";
			}
			else
			{
				this.Text = titleBase;
			}

			if (!valid)
			{
				//have some kind of kitten at the user somehow? reflect in statusbar?
			}
		}

		private void rankBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int rankIndex = rankBox.SelectedIndex;
			switch (rankIndex)
			{
				case 0:
					//Unranked
					monster.Rank = new RankUnranked();
					break;

				case 1:
					//Miniboss
					monster.Rank = new RankMiniboss();
					break;

				case 2:
					//Boss
					monster.Rank = new RankBoss();
					break;
			}
			this.UpdateData();
		}
		private void atkBox_ValueChanged(object sender, EventArgs e)
		{
			monster.ATK = (int)atkBox.Value;
			this.UpdateData();
		}
		private void vitBox_ValueChanged(object sender, EventArgs e)
		{
			monster.VIT = (int)vitBox.Value;
			this.UpdateData();
		}
		private void spdBox_ValueChanged(object sender, EventArgs e)
		{
			monster.SPD = (int)spdBox.Value;
			this.UpdateData();
		}
		private void magBox_ValueChanged(object sender, EventArgs e)
		{
			monster.MAG = (int)magBox.Value;
			this.UpdateData();
		}
		private void sprBox_ValueChanged(object sender, EventArgs e)
		{
			monster.SPR = (int)sprBox.Value;
			this.UpdateData();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			PropertiesForm f = new PropertiesForm(this);
			f.ShowDialog();
		}

		internal void RegisterNewProperty(TreeNode treeNode)
		{
			//validate the node (some nodes will need a second dialog opened,
			//some may not actually lead to the registration of a new property
			//(i.e. if it would require more slots than are currently available))
			
			Type propertyType = asm.GetType("Elena." + treeNode.Name);
			bool propertyGenerated;
			MonsterProperty property;
			try
			{
				property = (MonsterProperty)Activator.CreateInstance(propertyType);
				propertyGenerated = true;
			}
			catch
			{
				propertyGenerated = false;
				property = new NullProperty();
			}
			if (propertyGenerated)
			{
				monster.AddProperty(property);
			}
			this.UpdateData();
		}

		private void propsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedProperty = (MonsterProperty)propsListBox.SelectedItem;
			editPropButton.Enabled = selectedProperty.IsEditable();
		}

		private void delPropButton_Click(object sender, EventArgs e)
		{
			monster.RemoveProperty(selectedProperty);
			selectedProperty = new NullProperty();
			this.UpdateData();
		}

		private void newButton_Click(object sender, EventArgs e)
		{
			//blank out all fields, empty all lists, create new Monster
			monster = new Monster();
			diffBox.SelectedIndex = 1;
			rankBox.SelectedIndex = 0;
			this.UpdateDataFromLoad();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			saveDialog.FileName = monster.Name + ".rawr";
			if (saveDialog.ShowDialog() == DialogResult.OK)
			{
				FileInfo file = new FileInfo(saveDialog.FileName);
				BinaryFormatter b = new BinaryFormatter();
				 
				Stream s = file.Open(FileMode.Create, FileAccess.Write);
				b.Serialize(s, monster);
				s.Close();
				this.Text = titleBase;
			}
		}

		private void loadButton_Click(object sender, EventArgs e)
		{
			//load monster data from a file
			if (loadDialog.ShowDialog() == DialogResult.OK)
			{
				FileInfo file = new FileInfo(loadDialog.FileName);
				BinaryFormatter b = new BinaryFormatter();

				Stream s = file.Open(FileMode.Open);
				monster = (Monster)b.Deserialize(s);
				s.Close();
				this.UpdateDataFromLoad();
			}
		}

		private void txtButton_Click(object sender, EventArgs e)
		{
			//money button for the entire apparatus!
			String output = monster.Name + " :: ";
			output += "L" + monster.Level + " " + monster.Difficulty.Text() + " " + monster.Rank.Text() + "\r\n";
			output += "ATK" + monster.ATK + " VIT" + monster.VIT + " SPD" + monster.SPD + " MAG" + monster.MAG + " SPR" + monster.SPR + "\r\n";
			output += "HP: " + monster.HP + " MP: " + monster.MP + "\r\n";
			output += "XP: " + monster.XPReward + " JP: " + monster.JPReward + " Gil: " + monster.GilReward + "\r\n";
			String libra = monster.Name + ", Level " + monster.Level + " " + monster.Difficulty.Libra() + " " + monster.Rank.Libra() + " «FAMILY»";
			libra += " ???/" + monster.HP + " HP ???/" + monster.MP + " MP \r\n";

			output += "\r\nProperties:\r\n";

			//at some point here we need to print out arm/marm/eva/meva/acc
			if (monster.ARM > 0)
			{
				output += "Armour: " + monster.ARM * 5 + "\r\n";
			}

			if (monster.MARM > 0)
			{
				output += "Magic Armour: " + monster.MARM * 5 + "\r\n";
			}

			if (monster.EVA > 0)
			{
				output += "Evasion: " + monster.EVA * 5 + "\r\n";
			}

			if (monster.MEVA > 0)
			{
				output += "Magic Evasion: " + monster.MEVA * 5 + "\r\n";
			}

			if (monster.ACC > 0)
			{
				output += "Accuracy Bonus: " + monster.ACC * 5 + "\r\n";
			}

			foreach (KeyValuePair<Element, ElementMod> kvp in monster.ElementalProperties)
			{
				if (kvp.Value != ElementMod.None)
				{
					output += kvp.Value.ToString() + ":" + kvp.Key.ToString() + " ";
					libra += kvp.Value.ToString() + ":" + kvp.Key.ToString() + " ";
				}
			}

			output += "\r\n";

			libra += "\r\n«ALL STATUS R/I» \r\nReveal one of of: \r\n";

			foreach (MonsterProperty m in monster.Properties.Reverse<MonsterProperty>())
			{
				if (m.Text().Length != 0)
				{
					output += m.Text() + "\r\n";
				}
				if (m.Libra().Length != 0)
				{
					libra += m.Libra() + "\r\n";
				}
			}

			output += "\r\nActions:\r\n";

			output += monster.BasicAttack.Text(true) + "\r\n";

			foreach (AbstractAbility a in monster.Abilities)
			{
				output += a.Text(true) + "\r\n";
			}

			output += "Item: " + monster.Item + ", Equip: " + monster.Equip + ", Drop: " + monster.Drop;

			output += "\r\n\r\n=======================\r\n\r\n" + libra;
			txtDialog.FileName = monster.Name + ".txt";
			if (txtDialog.ShowDialog() == DialogResult.OK)
			{
				String fileName = txtDialog.FileName;
				System.IO.StreamWriter f = new StreamWriter(fileName);
				f.WriteLine(output);
				f.Close();
			}
		}

		public void DebugSet(String s) {
			descBox.Text = s;
		}

		private void nameBox_TextChanged(object sender, EventArgs e)
		{
			monster.Name = nameBox.Text;
		}

		private void itemBox_TextChanged(object sender, EventArgs e)
		{
			monster.Item = itemBox.Text;
		}

		private void equipBox_TextChanged(object sender, EventArgs e)
		{
			monster.Equip = equipBox.Text;
		}

		private void dropBox_TextChanged(object sender, EventArgs e)
		{
			monster.Drop = dropBox.Text;
		}

		private void descBox_LostFocus(object sender, System.EventArgs e)
		{
			monster.Description = descBox.Text;
		}

		private void addAbilityButton_Click(object sender, EventArgs e)
		{
			AbilitiesForm d = new AbilitiesForm();
			if (d.ShowDialog() == DialogResult.OK)
			{
				Type abilityType = asm.GetType("Elena." + d.SelectedNode().Name);
				bool propertyGenerated;
				MonsterAbility ability;
				try
				{
					ability = (MonsterAbility)Activator.CreateInstance(abilityType);
					propertyGenerated = true;
				}
				catch
				{
					propertyGenerated = false;
					ability = new NullAbility();
				}
				if (propertyGenerated)
				{
					if (selectedAbility.IsNull)
					{
						monster.AddAbility(ability);
					}
					else
					{
						monster.AddAbility(ability, selectedAbility);
					}
					selectedAbility = new NullAbility();
				}
				this.UpdateData();
			}
		}

		private MonsterAbility FindAbilityInTree(TreeNode n, TreeNode parent)
		{
			if (n.Text == monster.BasicAttack.ToString())
			{
				return monster.BasicAttack;
			}

			if (n.Level != 0)
			{
				if (parent.Text == monster.BasicAttack.ToString())
				{
					foreach (AbilityModifier m in monster.BasicAttack.Modifiers())
					{
						if (m.ToString() == n.Text)
						{
							return (MonsterAbility)m;
						}
					}
				}
			}

			if (n.Level != 0)
			{
				//if it's a child node... (this may not work actually)
				foreach (MonsterAbility a in monster.Abilities)
				{
					if (a.ToString() == parent.Text)
					{
						foreach (AbilityModifier m in a.Modifiers())
						{
							if (m.ToString() == n.Text)
							{
								return (MonsterAbility)m;
							}
						}
					}
				}
			}

			foreach (MonsterAbility a in monster.Abilities)
			{
				if (a.ToString() == n.Text)
				{
					return a;
				}
			}
			return new NullAbility();
		}

		private void abilsList_doubleClick(object sender, EventArgs e)
		{
			MonsterAbility a = FindAbilityInTree(abilsList.SelectedNode, abilsList.SelectedNode.Parent);
			if (a.IsNull != true)
			{
				selectedAbility.Edit(monster);
				this.UpdateData();
			}
		}

		private void propsList_doubleClick(object sender, EventArgs e)
		{
			selectedProperty.Edit(monster);
			this.UpdateData();
		}

		private void editPropButton_Click(object sender, EventArgs e)
		{
			selectedProperty.Edit(monster);
			this.UpdateData();
		}

		private void abilsList_AfterSelect(object sender, TreeViewEventArgs e)
		{
			MonsterAbility a = FindAbilityInTree(abilsList.SelectedNode, abilsList.SelectedNode.Parent);
			if (a.IsNull != true)
			{
				selectedAbility = a;
				editAbilButton.Enabled = selectedAbility.IsEditable();
			}
			else
			{
				selectedAbility = new NullAbility();
				editAbilButton.Enabled = false;
			}
		}

		private void delAbilButton_Click(object sender, EventArgs e)
		{
			if (!selectedAbility.IsNull)
			{
				if (selectedAbility.IsBaseAbility())
				{
					monster.Abilities.Remove(selectedAbility);
				}
				else
				{
					monster.RemoveModifier((AbilityModifier)selectedAbility);
				}
				selectedAbility = new NullAbility();
				this.UpdateData();
			}
		}

		private void editAbilButton_Click(object sender, EventArgs e)
		{
			if (!selectedAbility.IsNull)
			{
				selectedAbility.Edit(monster);
				this.UpdateData();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//export to txt for yamotracker
			string[] yamo = new string[14];

			yamo[0] = "\"" + monster.Name + "\"";
			yamo[1] = monster.ATK.ToString();
			yamo[2] = monster.VIT.ToString();
			yamo[3] = monster.SPD.ToString();
			yamo[4] = monster.MAG.ToString();
			yamo[5] = monster.SPR.ToString();
			yamo[6] = (monster.ACC*5).ToString();
			yamo[7] = (monster.EVA*5).ToString();
			yamo[8] = (monster.MEVA*5).ToString();
			yamo[9] = (monster.ARM*5).ToString();
			yamo[10] = (monster.MARM*5).ToString();
			yamo[11] = monster.Level.ToString();
			yamo[12] = monster.HP.ToString();
			yamo[13] = monster.MP.ToString();

			String output = String.Join(",", yamo);

			yamoDialog.FileName = monster.Name + "_trax.txt";
			if (yamoDialog.ShowDialog() == DialogResult.OK)
			{
				String fileName = yamoDialog.FileName;
				System.IO.StreamWriter f = new StreamWriter(fileName);
				f.WriteLine(output);
				f.Close();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			//toggles gil reward multiplier on and off!
			monster.EquipMultiplier = checkBox1.Checked;
			this.UpdateData();
		}

		private void basicAttackButton_Click(object sender, EventArgs e)
		{
			BasicAttack atk = new BasicAttack();
			//and then add the new basic attack
			atk.SetAsDefault();
			atk.Prepare(monster);
			atk.Free = true;

			foreach (AbilityModifier a in monster.BasicAttack.Modifiers())
			{
				a.SetupParent(atk);
				atk.AddModifier(a);
			}

			monster.BasicAttack = atk;
			basicAttackButton.BackColor = Properties.Settings.Default.BackColour;
			basicAttackButton.ForeColor = Properties.Settings.Default.TextColour;
			this.UpdateData();
		}

		private void optionsButton_Click(object sender, EventArgs e)
		{
			InputOptions d = new InputOptions();
			if (d.ShowDialog() == DialogResult.OK)
			{
				this.BackColor = Properties.Settings.Default.BackColour;
				foreach (Control c in this.Controls)
				{
					if (c is TextBox || c is TreeView || c is ListBox)
					{
						c.BackColor = Properties.Settings.Default.FieldBackColour;
						c.ForeColor = Properties.Settings.Default.FieldTextColour;
					}
					if (c is Label || c is GroupBox || c is Button)
					{
						c.ForeColor = Properties.Settings.Default.TextColour;
					}
				}
				foreach (Control c in groupBox1.Controls)
				{
					if (c is TextBox || c is ComboBox || c is NumericUpDown)
					{
						c.BackColor = Properties.Settings.Default.FieldBackColour;
						c.ForeColor = Properties.Settings.Default.FieldTextColour;
					}
					if (c is Label || c is GroupBox || c is Button)
					{
						c.ForeColor = Properties.Settings.Default.TextColour;
					}
				}
				foreach (Control c in groupBox4.Controls)
				{
					if (c is TextBox || c is NumericUpDown)
					{
						c.BackColor = Properties.Settings.Default.FieldBackColour;
						c.ForeColor = Properties.Settings.Default.FieldTextColour;
					}
					if (c is Label || c is GroupBox || c is Button)
					{
						c.ForeColor = Properties.Settings.Default.TextColour;
					}
				}
				weak_label.ForeColor = Properties.Settings.Default.WeakColour;
				normal_label.ForeColor = Properties.Settings.Default.NormalColour;
				resist_label.ForeColor = Properties.Settings.Default.ResistColour;
				immune_label.ForeColor = Properties.Settings.Default.ImmuneColour;
				absorb_label.ForeColor = Properties.Settings.Default.AbsorbColour;
			}
		}




	}
}
