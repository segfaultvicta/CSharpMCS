using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Elena
{
	[Serializable]
	public abstract class MonsterProperty : IComparable<MonsterProperty>
	{
		protected bool veiledScan = false;
		protected bool veiledVeil = false;
		protected String libraInfo = "";
		protected String propInfo = "*DEBUG*";
		protected String textInfo = "*";
		protected int slotCost = 0;
		protected bool isUnique = false;
		protected int weight = 0;

		public void Complain(int type)
		{
			switch (type)
			{
				case 0:
					MessageBox.Show("That property is not usable by unranked monsters.", "Property Restricted!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 1:
					MessageBox.Show("That property is limited to Bosses.", "Property Restricted!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 2:
					MessageBox.Show("Minibosses and Bosses can't undergo amorphous fission. Feel free to pencil in 'Family: Amorph' on the monster's data on your own, though!", "Doop Doop Doop!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 3:
					MessageBox.Show("Sorry! You can only have one of those properties active at the same time.", "Property Restricted!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 4:
					MessageBox.Show("That property costs too many slots.", "Property Restricted!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;
				
				case 5:
					MessageBox.Show("Not enough slots to edit the ability.", "Not Enough Slots!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;
			}
		}
		public virtual void ApplyProperty(Monster m) { }
		public int SlotCost()
		{
			return slotCost;
		}
		public override String ToString()
		{
			return propInfo + " {" + SlotCost().ToString() + "}";
		}
		public String Libra()
		{
			return libraInfo;
		}
		public String Text()
		{
			if (textInfo.Length == 0)
			{
				return textInfo;
			}
			else
			{
				return propInfo;
			}
		}
		public void VeilScan(bool veilVeil)
		{
			veiledScan = true;
			veiledVeil = veilVeil;
		}
		public bool Unique()
		{
			return isUnique;
		}
		public virtual void Edit(Monster m) { }
		public virtual void Recalculate(Monster m) { }
		public virtual bool Prepare(Monster m) 
		{
			return true;
			//when this is overridden, it should raise some sort of validation dialog if
			//it's going to return false.
		}
		public virtual bool IsMinibossOrBoss()
		{
			return false;
		}
		public virtual bool IsBoss()
		{
			return false;
		}
		public int CompareTo(MonsterProperty other)
		{
			return weight.CompareTo(other.weight);
		}

		public virtual bool IsEditable() { return false; }
	}
	[Serializable]
	public class NullProperty : MonsterProperty { }
	[Serializable]
	public class DiffEasy : MonsterProperty
	{
		public DiffEasy()
		{
			propInfo = "Easy Difficulty";
			libraInfo = "Easy";
		}
		public override void ApplyProperty(Monster m)
		{
			m.HPMod = 1;
			m.MPMod = 1;
			m.XPMod = 150;
			m.JPMod = 2;
			m.AttributeMax = 10;
			m.AttributeTotal = 30;
			m.Slots = 8;
		}
	}
	[Serializable]
	public class DiffNormal : MonsterProperty
	{
		public DiffNormal()
		{
			propInfo = "Normal Difficulty";
			libraInfo = "Normal";
		}
		public override void ApplyProperty(Monster m)
		{
			m.HPMod = 3;
			m.MPMod = 1;
			m.XPMod = 200;
			m.JPMod = 3;
			m.AttributeMax = 15;
			m.AttributeTotal = 35;
			m.Slots = 12;
		}
	}
	[Serializable]
	public class DiffTough : MonsterProperty
	{
		public DiffTough()
		{
			propInfo = "Tough Difficulty";
			libraInfo = "Tough";
		}
		public override void ApplyProperty(Monster m)
		{
			m.HPMod = 4;
			m.MPMod = 1;
			m.XPMod = 300;
			m.JPMod = 5;
			m.AttributeMax = 20;
			m.AttributeTotal = 40;
			m.Slots = 20;
		}
	}
	[Serializable]
	public class RankUnranked : MonsterProperty 
	{
		public RankUnranked()
		{
			propInfo = "Unranked";
		}
		public override void ApplyProperty(Monster m)
		{
			m.HPMultiplier = 1;
		}
	}
	[Serializable]
	public class RankMiniboss : MonsterProperty
	{
		public RankMiniboss()
		{
			propInfo = "Mini Boss";
			libraInfo = "Miniboss";
		}
		public override void ApplyProperty(Monster m)
		{
			m.AttributeTotal += 5;
			m.Slots += 4;
			m.HPMultiplier = 2;
			m.JPMod *= 3;
			m.XPMod *= 2;
		}
		public override bool IsMinibossOrBoss()
		{
			return true;
		}
	}
	[Serializable]
	public class RankBoss : MonsterProperty
	{
		public RankBoss()
		{
			propInfo = "Boss";
			libraInfo = "Boss";
		}
		public override void ApplyProperty(Monster m)
		{
			m.AttributeTotal += 10;
			m.AttributeMax += 5;
			m.Slots += 10;
			m.HPMultiplier = 3;
			m.JPMod *= 6;
			m.XPMod *= 4;
		}
		public override bool IsBoss()
		{
			return true;
		}
		public override bool IsMinibossOrBoss()
		{
			return true;
		}
	}
	[Serializable]
	public class FamilyAvian : MonsterProperty
	{
		public FamilyAvian()
		{
			propInfo = "Avian - Evasion V, Auto-Float, W:Lightning";
			slotCost = 2;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Lightning] = ElementMod.Weak;
			m.EVA += 5;
		}
	}
	[Serializable]
	public class FamilyAvianNoWeakness : MonsterProperty
	{
		public FamilyAvianNoWeakness()
		{
			propInfo = "Family - Avian: Evasion V, Auto-Float";
			slotCost = 4;
			weight = 3;
		}
		public override void ApplyProperty(Monster m)
		{
			m.EVA += 5;
		}
	}
	[Serializable]
	public class FamilyUndead : MonsterProperty
	{
		public FamilyUndead()
		{
			propInfo = "Undead - A:Shadow, W:Holy, W:Fire and Auto-Zombie";
			slotCost = -4;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Shadow] = ElementMod.Absorb;
			m.ElementalProperties[Element.Holy] = ElementMod.Weak;
			m.ElementalProperties[Element.Fire] = ElementMod.Weak;
		}
	}
	[Serializable]
	public class FamilyRevenant6 : MonsterProperty
	{
		public FamilyRevenant6()
		{
			propInfo = "Undead Revenant (6) - A:Shadow, W:Holy, W:Fire and Auto-Zombie";
			slotCost = 0;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Shadow] = ElementMod.Absorb;
			m.ElementalProperties[Element.Holy] = ElementMod.Weak;
			m.ElementalProperties[Element.Fire] = ElementMod.Weak;
		}
	}
	[Serializable]
	public class FamilyRevenant4 : MonsterProperty
	{
		public FamilyRevenant4()
		{
			propInfo = "Undead Revenant (4) - A:Shadow, W:Holy, W:Fire and Auto-Zombie";
			slotCost = 4;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Shadow] = ElementMod.Absorb;
			m.ElementalProperties[Element.Holy] = ElementMod.Weak;
			m.ElementalProperties[Element.Fire] = ElementMod.Weak;
		}
	}
	[Serializable]
	public class FamilyConstruct : MonsterProperty
	{
		public FamilyConstruct()
		{
			propInfo = "Construct - clank, clank, clank.";
			isUnique = true;
			weight = 3;
		}
	}
	[Serializable]
	public class FamilyMachina : MonsterProperty
	{
		public FamilyMachina()
		{
			propInfo = "Machina Construct - W:Lightning, Steal Item is Death";
			slotCost = -6;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Lightning] = ElementMod.Weak;
		}
	}
	[Serializable]
	public class FamilyTurret : MonsterProperty
	{
		public FamilyTurret()
		{
			propInfo = "Turret Construct - W:Lightning, 0 EVA, Cannot Move, I:Push, 1/2 defense factor to non-lightning damage while CTing";
			slotCost = 2;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Lightning] = ElementMod.Weak;
			m.EVA = 0;
		}
	}
	[Serializable]
	public class FamilyArcana : MonsterProperty
	{
		public FamilyArcana()
		{
			propInfo = "Arcana - +3 MPMOD, Manabound";
			slotCost = 0;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.MPMod += 3;
		}
	}
	[Serializable]
	public class FamilyPlant : MonsterProperty
	{
		public FamilyPlant()
		{
			isUnique = true;
			weight = 3;
		}
		public override bool Prepare(Monster m)
		{
			//select a status. whenever a status-inflicting ability misses,
			//CoS 30 of inflicting this new status to the target.
			//slot cost is contingent on status chosen.
			//Deprotect, Deshell, Slow : 0 slots
			//Silence, Immobilise, Poison : 1 slot
			//Confuse, Pain, Sleep : 2 slots
			InputPlantStatus d = new InputPlantStatus();
			if (d.ShowDialog() == DialogResult.OK)
			{
				//figure out which status was selected
				switch (d.Offset())
				{
					case 0:
						propInfo = "Plant - W:Fire, Status Boomerang: Deprotect (4) CoS 30";
						slotCost = 0;
						break;

					case 1:
						propInfo = "Plant - W:Fire, Status Boomerang: Deshell (4) CoS 30";
						slotCost = 0;
						break;

					case 2:
						propInfo = "Plant - W:Fire, Status Boomerang: Slow (4) CoS 30";
						slotCost = 0;
						break;

					case 3:
						propInfo = "Plant - W:Fire, Status Boomerang: Debrave (4) CoS 30";
						slotCost = 1;
						break;

					case 4:
						propInfo = "Plant - W:Fire, Status Boomerang: Defaith (4) CoS 30";
						slotCost = 1;
						break;

					case 5:
						propInfo = "Plant - W:Fire, Status Boomerang: Immobilize (4) CoS 30";
						slotCost = 1;
						break;

					case 6:
						propInfo = "Plant - W:Fire, Status Boomerang: Poison (4) CoS 30";
						slotCost = 1;
						break;

					case 7:
						propInfo = "Plant - W:Fire, Status Boomerang: Confuse (4) CoS 20";
						slotCost = 2;
						break;

					case 9:
						propInfo = "Plant - W:Fire, Status Boomerang: Sleep (2) CoS 20";
						slotCost = 2;
						break;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Fire] = ElementMod.Weak;
		}
	}
	[Serializable]
	public class FamilyAquan : MonsterProperty
	{
		public FamilyAquan()
		{
			propInfo = "Aquan - . o 0 (blub, blub, blub)";
			slotCost = 0;
			isUnique = true;
			weight = 3;
		}
	}
	[Serializable]
	public class FamilyAmphibian : MonsterProperty
	{
		public FamilyAmphibian()
		{
			propInfo = "Amphibian Aquan - W:Fire, I:Toad, +100% situational modifier to all Recovery effects";
			slotCost = 2;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Fire] = ElementMod.Weak;
			//I:Toad
			//+100% sit mod to all recovery effects
		}
	}
	[Serializable]
	public class FamilyHumanoid : MonsterProperty
	{
		public FamilyHumanoid()
		{
			propInfo = "Humanoid - Utilises Equipment";
			slotCost = 0;
			isUnique = true;
			weight = 3;
		}
	}
	[Serializable]
	public class FamilyInsect : MonsterProperty
	{
		public FamilyInsect()
		{
			propInfo = "Insect - W:Ice, R:Poison V, Added Status: Poison (20)";
			slotCost = 2;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ElementalProperties[Element.Ice] = ElementMod.Weak;
			//Resist Poison V
			//Added Status: Poison (20)
		}
	}
	[Serializable]
	public class FamilyDragon : MonsterProperty
	{
		public FamilyDragon()
		{
			propInfo = "Dragon - x1.5 power multiplier to all damage, +D10 to all actions";
			slotCost = 2;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			//+D5 to all actions
			m.DelayMod += 10;
			//x1.5 power multiplier to all actions
			m.PowerMult *= 1.5;
		}
	}
	[Serializable]
	public class FamilyBeast : MonsterProperty
	{
		public FamilyBeast()
		{
			propInfo = "Beast - Reduce all delay and floor by 5";
			slotCost = 2;
			isUnique = true;
			weight = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			//Delay, Floor -5
			m.DelayMod -= 5;
			m.FloorMod -= 5;
		}
	}
	[Serializable]
	public class FamilyAmorph : MonsterProperty
	{
		public FamilyAmorph()
		{
			propInfo = "Amorph - doop doop doop (5), canceled by physical Shadow";
			isUnique = true;
			weight = 3;
		}
		public override bool Prepare(Monster m)
		{
			if (m.Rank.IsMinibossOrBoss())
			{
				Complain(2);
				return false;
			}
			else
			{
				Type difficulty = m.Difficulty.GetType();
				if (difficulty == (new DiffEasy()).GetType())
				{
					slotCost = 2;
				}
				else if(difficulty == (new DiffNormal()).GetType())
				{
					slotCost = 4;
				}
				else if (difficulty == (new DiffTough()).GetType())
				{
					slotCost = 6;
				}
				return true;
			}
		}
	}
	[Serializable]
	public class BasicArm : MonsterProperty
	{
		private int ranks = 0;
		private int ranksPastBase = 0;
		private int baseSlotCost = 3;
		private decimal slotsPerRank = 0.5M;
		public BasicArm()
		{
			weight = 2;
			textInfo = "";
		}

		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = m.Tier * 2;
			d.SlotsPerRank = slotsPerRank;
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Armor " + d.Ranks.ToString();
				libraInfo = "Armor " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				ranksPastBase = d.RanksPastBase;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Recalculate(Monster m)
		{
			ranks = m.Tier * 2 + ranksPastBase;
			propInfo = "Armor " + ranks.ToString();
			libraInfo = "Armor " + ranks.ToString();
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = m.Tier * 2;
			d.SlotsPerRank = slotsPerRank;
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "Armor " + d.Ranks.ToString();
					libraInfo = "Armor " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
					ranksPastBase = d.RanksPastBase;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ARM = ranks;
		}
	}
	[Serializable]
	public class BasicMarm : MonsterProperty
	{
		private int ranks = 0;
		private int ranksPastBase = 0;
		private int baseSlotCost = 3;
		private decimal slotsPerRank = 0.5M;
		public BasicMarm()
		{
			weight = 2;
			textInfo = "";
		}

		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = m.Tier * 2;
			d.SlotsPerRank = slotsPerRank;
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Magic Armor " + d.Ranks.ToString();
				libraInfo = "Magic Armor " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				ranksPastBase = d.RanksPastBase;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Recalculate(Monster m)
		{
			ranks = m.Tier * 2 + ranksPastBase;
			propInfo = "Magic Armor " + ranks.ToString();
			libraInfo = "Magic Armor " + ranks.ToString();
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = m.Tier * 2;
			d.SlotsPerRank = slotsPerRank;
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "Magic Armor " + d.Ranks.ToString();
					libraInfo = "Magic Armor " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
					ranksPastBase = d.RanksPastBase;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.MARM = ranks;
		}
	}
	[Serializable]
	public class BasicEva : MonsterProperty
	{
		private int ranks;
		private int baseSlotCost = 2;
		private int baseResult = 1;
		private int slotsPerRank = 1;
		public BasicEva()
		{
			weight = 2;
			textInfo = "";
		}

		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = baseResult;
			d.SlotsPerRank = slotsPerRank;
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Evasion " + d.Ranks.ToString();
				libraInfo = "Evasion " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = baseResult;
			d.SlotsPerRank = slotsPerRank;
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "Evasion " + d.Ranks.ToString();
					libraInfo = "Evasion " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override void ApplyProperty(Monster m)
		{
			m.EVA = ranks;
		}
	}
	[Serializable]
	public class BasicMeva : MonsterProperty
	{
		private int ranks;
		private int baseSlotCost = 2;
		private int baseResult = 1;
		private int slotsPerRank = 2;
		public BasicMeva()
		{
			weight = 2;
			textInfo = "";
		}

		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = baseResult;
			d.SlotsPerRank = slotsPerRank;
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Magic Evasion " + d.Ranks.ToString();
				libraInfo = "Magic Evasion " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = baseResult;
			d.SlotsPerRank = slotsPerRank;
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "Magic Evasion " + d.Ranks.ToString();
					libraInfo = "Magic Evasion " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.MEVA = ranks;
		}
	}
	[Serializable]
	public class BasicAcc : MonsterProperty
	{
		private int ranks;
		private int baseSlotCost = 1;
		private int baseResult = 1;
		private int slotsPerRank = 2;
		public BasicAcc()
		{
			weight = 2;
			textInfo = "";
		}


		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = baseResult;
			d.SlotsPerRank = slotsPerRank;
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Accuracy " + d.Ranks.ToString();
				libraInfo = "Accuracy " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.BaseSlotCost = baseSlotCost;
			d.BaseResult = baseResult;
			d.SlotsPerRank = slotsPerRank;
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "Accuracy " + d.Ranks.ToString();
					libraInfo = "Accuracy " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.ACC = ranks;
		}
	}
	[Serializable]
	public class ElementalFreestyle : MonsterProperty
	{
		private Dictionary<Element, ElementMod> properties = new Dictionary<Element, ElementMod>();

		public ElementalFreestyle()
		{
			propInfo = "Freestyle Elemental Properties";
			textInfo = "";
			isUnique = true;
			weight = 0;
		}

		public override bool Prepare(Monster m)
		{
			InputElementFreestyle d = new InputElementFreestyle();
			if (d.ShowDialog() == DialogResult.OK)
			{
				slotCost = d.SlotCost();
				this.properties[Element.Fire] = d.Fire;
				this.properties[Element.Ice] = d.Ice;
				this.properties[Element.Lightning] = d.Lightning;
				this.properties[Element.Water] = d.Water;
				this.properties[Element.Holy] = d.Holy;
				this.properties[Element.Shadow] = d.Shadow;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster m)
		{
			InputElementFreestyle d = new InputElementFreestyle();
			d.LoadElements(properties);
			if (d.ShowDialog() == DialogResult.OK)
			{
				slotCost = d.SlotCost();
				this.properties[Element.Fire] = d.Fire;
				this.properties[Element.Ice] = d.Ice;
				this.properties[Element.Lightning] = d.Lightning;
				this.properties[Element.Water] = d.Water;
				this.properties[Element.Holy] = d.Holy;
				this.properties[Element.Shadow] = d.Shadow;
			}
		}

		public override void ApplyProperty(Monster m)
		{
			foreach(KeyValuePair<Element,ElementMod> kvp in properties) 
			{
				if (kvp.Value != ElementMod.None)
				{
					m.ElementalProperties[kvp.Key] = kvp.Value;
				}
			}
		}
	}
	[Serializable]
	public class ElementalAlignment : MonsterProperty
	{
		private Dictionary<Element, ElementMod> properties = new Dictionary<Element, ElementMod>();
		private Element primaryElement = Element.Null;

		public ElementalAlignment()
		{
			isUnique = true;
			textInfo = "";
			weight = 1;
		}

		public override bool Prepare(Monster m)
		{
			InputElementPresets d = new InputElementPresets();

			if (d.ShowDialog() == DialogResult.OK)
			{
				switch (d.ReturnSet())
				{
					case 1:
						//set 1 selected
						//A: selected, W: Opposite
						properties[d.ReturnPrimary()] = ElementMod.Absorb;
						properties[d.ReturnOpposite()] = ElementMod.Weak;
						slotCost = 0;
						propInfo = "A: " + d.ReturnPrimary().ToString() + " W: " + d.ReturnOpposite().ToString();
						primaryElement = d.ReturnPrimary();
						return true;

					case 2:
						//set 2 selected
						//A: selected, W: Opposite, R: tertiaries
						properties[d.ReturnPrimary()] = ElementMod.Absorb;
						properties[d.ReturnOpposite()] = ElementMod.Weak;
						properties[d.ReturnTertiary1()] = ElementMod.Resist;
						properties[d.ReturnTertiary2()] = ElementMod.Resist;
						slotCost = 2;
						propInfo = "A: " + d.ReturnPrimary().ToString() + " W: " + d.ReturnOpposite().ToString() + "R: Tertiaries";
						primaryElement = d.ReturnPrimary();
						return true;

					case 3:
						//set 3 selected
						//A: selected, W: Opposite, I: tertiaries
						properties[d.ReturnPrimary()] = ElementMod.Absorb;
						properties[d.ReturnOpposite()] = ElementMod.Weak;
						properties[d.ReturnTertiary1()] = ElementMod.Immune;
						properties[d.ReturnTertiary2()] = ElementMod.Immune;
						slotCost = 4;
						propInfo = "A: " + d.ReturnPrimary().ToString() + " W: " + d.ReturnOpposite().ToString() + "I: Tertiaries";
						primaryElement = d.ReturnPrimary();
						return true;

					case 4:
						//set 4 selected
						//A: selected, W: Opposite, R: all others
						Element primary = d.ReturnPrimary();
						Element opposite = d.ReturnOpposite();
						properties[Element.Fire] = ElementMod.Resist;
						properties[Element.Ice] = ElementMod.Resist;
						properties[Element.Lightning] = ElementMod.Resist;
						properties[Element.Water] = ElementMod.Resist;
						properties[Element.Holy] = ElementMod.Resist;
						properties[Element.Shadow] = ElementMod.Resist;
						properties[primary] = ElementMod.Absorb;
						properties[opposite] = ElementMod.Weak;
						slotCost = 4;
						propInfo = "A: " + d.ReturnPrimary().ToString() + " W: " + d.ReturnOpposite().ToString() + "R: Others";
						primaryElement = d.ReturnPrimary();
						return true;

					default:
						return false;
				}
			}
			else
			{
				return false;
			}
		}

		public override void ApplyProperty(Monster m)
		{
			m.PrimaryElement = primaryElement;
			foreach (KeyValuePair<Element, ElementMod> kvp in properties)
			{
				if (kvp.Value != ElementMod.None)
				{
					m.ElementalProperties[kvp.Key] = kvp.Value;
				}
			}
		}
	}
	[Serializable]
	public class ElementalEnhance : MonsterProperty
	{
		public ElementalEnhance()
		{
			slotCost = 2;
			weight = 1;
		}
		public override bool Prepare(Monster m)
		{
			InputElement d = new InputElement();
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Enhanced " + d.SelectedElement().ToString();
				libraInfo = "Enhanced " + d.SelectedElement().ToString();
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}
		public override void Edit(Monster m)
		{
			InputElement d = new InputElement();
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "Enhanced " + d.SelectedElement().ToString();
				libraInfo = "Enhanced " + d.SelectedElement().ToString();
			}
		}
	}
	[Serializable]
	public class ElementalWallchange : MonsterProperty
	{
		public ElementalWallchange()
		{
			propInfo = "Elemental Wallchange";
			libraInfo = "Wall Change";
			slotCost = 2;
			weight = 1;
		}

		public override bool Prepare(Monster m)
		{
			if (m.Rank.IsMinibossOrBoss())
			{
				return true;
			}
			else
			{
				Complain(0);
				return false;
			}
		}
	}
	[Serializable]
	public class StatusResistance : MonsterProperty
	{
		public StatusResistance()
		{
			propInfo = "Status Resistance - 4 Ranks (see MCS)";
			slotCost = 1;
		}
	}
	[Serializable]
	public class StatusImmunity : MonsterProperty
	{
		public StatusImmunity()
		{
			slotCost = 2;
		}

		public override bool Prepare(Monster m)
		{
			if (m.Rank.IsMinibossOrBoss())
			{
				InputImmuneStatus d = new InputImmuneStatus();
				if (d.ShowDialog() == DialogResult.OK)
				{
					propInfo = "I:" + d.ChosenString();
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				Complain(0);
				return false;
			}
		}
	}
	[Serializable]
	public class StatusAutoFloat : MonsterProperty
	{
		public StatusAutoFloat()
		{
			propInfo = "Auto-Float";
			libraInfo = "Auto-Float";
			slotCost = 4;
		}
	}
	[Serializable]
	public class StatusAuto : MonsterProperty
	{
		private string chosenString;
		public StatusAuto()
		{
			slotCost = 8;
		}

		public override bool Prepare(Monster m)
		{
			InputAutoStatus d = new InputAutoStatus();
			if (d.ShowDialog() == DialogResult.OK)
			{
				chosenString = d.ChosenString();
				propInfo = "Auto-" + d.ChosenString();
				libraInfo = "Auto-" + d.ChosenString();
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster m)
		{
			InputAutoStatus d = new InputAutoStatus();
			d.SetStatus(chosenString);
			if (d.ShowDialog() == DialogResult.OK)
			{
				chosenString = d.ChosenString();
				propInfo = "Auto-" + d.ChosenString();
				libraInfo = "Auto-" + d.ChosenString();
			}
		}
	}
	[Serializable]
	public class StatusSOS : MonsterProperty
	{
		public string chosenString;
		public StatusSOS()
		{
		}
		public override bool Prepare(Monster m)
		{
			InputStartsStatus d = new InputStartsStatus();
			d.SlotCostOffset = -2;
			if (d.ShowDialog() == DialogResult.OK)
			{
				chosenString = d.ChosenString();
				propInfo = "SOS-" + d.ChosenString();
				libraInfo = "SOS-" + d.ChosenString();
				slotCost = d.SlotCost();
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster m)
		{
			InputStartsStatus d = new InputStartsStatus();
			d.SlotCostOffset = -2;
			d.SetStatus(chosenString);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					chosenString = d.ChosenString();
					propInfo = "SOS-" + d.ChosenString();
					libraInfo = "SOS-" + d.ChosenString();
					slotCost = d.SlotCost();
				}
				else
				{
					Complain(5);
				}
			}
		}

	}
	[Serializable]
	public class StartsBattleWith : MonsterProperty
	{
		public string chosenString;
		public StartsBattleWith()
		{
		}
		public override bool Prepare(Monster m)
		{
			InputStartsStatus d = new InputStartsStatus();
			if (d.ShowDialog() == DialogResult.OK)
			{
				chosenString = d.ChosenString();
				propInfo = "Starts Battle With " + d.ChosenString();
				libraInfo = "Starts Battle With " + d.ChosenString();
				slotCost = d.SlotCost();
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster m)
		{
			InputStartsStatus d = new InputStartsStatus();
			d.SetStatus(chosenString);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					chosenString = d.ChosenString();
					propInfo = "Starts Battle With " + d.ChosenString();
					libraInfo = "Starts Battle With " + d.ChosenString();
					slotCost = d.SlotCost();
				}
				else
				{
					Complain(5);
				}
			}
		}
	}
	[Serializable]
	public class AdditionalXAction : MonsterProperty
	{
		public AdditionalXAction()
		{
			propInfo = "X-Action";
			libraInfo = "X-Action";
			slotCost = 4;
		}

		public override bool Prepare(Monster m)
		{
			if (m.Rank.IsMinibossOrBoss())
			{
				return true;
			}
			else
			{
				Complain(0);
				return false;
			}
		}
	}
	[Serializable]
	public class AdditionalRapidAssault : MonsterProperty
	{
		public AdditionalRapidAssault()
		{
			propInfo = "Rapid Assault";
			libraInfo = "Rapid Assault";
			slotCost = 3;
		}

		public override void ApplyProperty(Monster m)
		{
			m.DelayMod -= 15;
			m.FloorMod -= 5;
		}

		public override bool Prepare(Monster m)
		{
			if (m.Rank.IsMinibossOrBoss())
			{
				return true;
			}
			else
			{
				Complain(0);
				return false;
			}
		}
	}
	[Serializable]
	public class AdditionalXAttack : MonsterProperty
	{
		public AdditionalXAttack()
		{
			propInfo = "X-Attack - Add +10 to the monster's Weapon Delays.";
			libraInfo = "X-Attack";
			slotCost = 2;
		}
		public override bool Prepare(Monster m)
		{
			if (m.Tier < 7)
			{
				slotCost = 4;
			}
			return true;
		}

		public override void Recalculate(Monster m)
		{
			if (m.Tier < 7)
			{
				slotCost = 4;
			}
			else
			{
				slotCost = 2;
			}
		}
	}
	[Serializable]
	public class AdditionalHighHP : MonsterProperty
	{
		private int ranks;
		public AdditionalHighHP()
		{
			libraInfo = "High HP";
		}

		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "High HP " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "High HP " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.HPMod += ranks;
		}
	}
	[Serializable]
	public class AdditionalLowHP : MonsterProperty
	{
		public AdditionalLowHP()
		{
			propInfo = "Low HP";
			libraInfo = "Low HP";
			slotCost = -1;
			isUnique = true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.HPMod--;
		}
	}
	[Serializable]
	public class AdditionalHighMP : MonsterProperty
	{
		private int ranks;
		public AdditionalHighMP()
		{
			libraInfo = "High MP";
		}

		public override bool Prepare(Monster m)
		{
			InputRanks d = new InputRanks();
			if (d.ShowDialog() == DialogResult.OK)
			{
				propInfo = "High MP " + d.Ranks.ToString();
				slotCost = d.Slots;
				ranks = d.Ranks;
				return true;
			}
			else
			{
				return false;
			}
		}

		public override void Edit(Monster m)
		{
			InputRanks d = new InputRanks();
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				if (d.AllowSlotDifference(m.SlotsRemaining))
				{
					propInfo = "High MP " + d.Ranks.ToString();
					slotCost = d.Slots;
					ranks = d.Ranks;
				}
				else
				{
					Complain(5);
				}
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void ApplyProperty(Monster m)
		{
			m.MPMod += ranks;
		}
	}
	[Serializable]
	public class AdditionalDifficultEscape : MonsterProperty
	{
		public AdditionalDifficultEscape()
		{
			propInfo = "Makes Escapes Difficult";
			libraInfo = "Makes Escapes Difficult";
			slotCost = 2;
		}
	}
	[Serializable]
	public class AdditionalNoEscape : MonsterProperty
	{
		public AdditionalNoEscape()
		{
			propInfo = "Can't Escape";
			libraInfo = "Can't Escape";
			slotCost = 2;
		}
		public override bool Prepare(Monster m)
		{
			if (m.Rank.IsBoss())
			{
				return true;
			}
			else
			{
				Complain(1);
				return false;
			}
		}
	}
	[Serializable]
	public class AdditionalFission : MonsterProperty
	{
		public AdditionalFission()
		{
			propInfo = "Fission";
			libraInfo = "Fissionable";
			slotCost = 2;
		}
	}
	[Serializable]
	public class AdditionalGetBackUpBasic : MonsterProperty
	{
		public AdditionalGetBackUpBasic()
		{
			propInfo = "Get Back Up";
			libraInfo = "Gets Back Up";
			slotCost = 4;
		}
		public override bool Prepare(Monster m)
		{
			if (m.Tier < 3)
			{
				slotCost = 6;
			}
			if (m.Rank.IsMinibossOrBoss())
			{
				return true;
			}
			else
			{
				Complain(0);
				return false;
			}
		}

		public override void Recalculate(Monster m)
		{
			if (m.Tier < 3)
			{
				slotCost = 6;
			}
			else
			{
				slotCost = 4;
			}
		}
	}
	[Serializable]
	public class AdditionalGetBackUpPlus : MonsterProperty
	{
		public AdditionalGetBackUpPlus()
		{
			propInfo = "Get Back Up +Bravery, +Faith (Behemoth Edition)";
			libraInfo = "Gets Back Up";
			slotCost = 6;
		}
		public override bool Prepare(Monster m)
		{
			if (m.Tier < 3)
			{
				slotCost = 8;
			}
			if (m.Rank.IsMinibossOrBoss())
			{
				return true;
			}
			else
			{
				Complain(0);
				return false;
			}
		}
		public override void Recalculate(Monster m)
		{
			if (m.Tier < 3)
			{
				slotCost = 8;
			}
			else
			{
				slotCost = 6;
			}
		}
	}
	[Serializable]
	public class AdditionalGetBackUpPlusPlus : MonsterProperty
	{
		public AdditionalGetBackUpPlusPlus()
		{
			propInfo = "Get Back Up +Bravery +Faith +Haste +Critical Up (King Behemoth Edition)";
			libraInfo = "Gets Back Up";
			slotCost = 8;
		}
		public override bool Prepare(Monster m)
		{
			if (m.Tier < 3)
			{
				slotCost = 10;
			}
			if (m.Rank.IsMinibossOrBoss())
			{
				return true;
			}
			else
			{
				Complain(0);
				return false;
			}
		}
		public override void Recalculate(Monster m)
		{
			if (m.Tier < 3)
			{
				slotCost = 10;
			}
			else
			{
				slotCost = 8;
			}
		}
	}
	[Serializable]
	public class AdditionalPropertyVeil : MonsterProperty
	{
		public AdditionalPropertyVeil()
		{
			slotCost = 1;
		}
		public override bool Prepare(Monster m)
		{
			//select a status to veil! and then veil it.
			propInfo = "Property Veil (overt)";
			libraInfo = "Property Veil (overt) - replace a property with 'Property Veil'";
			return true;
		}
	}
	[Serializable]
	public class AdditionalVeiledPropertyVeil : MonsterProperty
	{
		public AdditionalVeiledPropertyVeil()
		{
			slotCost = 2;
		}

		public override bool Prepare(Monster m)
		{
			//select a status to veil! and then veil it.
			propInfo = "Property Veil (veiled) - not implemented yet.";
			libraInfo = "Property Veil (veiled) - veil a property from Libra entirely.";
			return true;
		}
	}
	[Serializable]
	public class AdditionalWeakSpot : MonsterProperty
	{
		private string trigger;
		private string result;
		public AdditionalWeakSpot()
		{
		}

		public override bool Prepare(Monster m)
		{
			InputWeakSpot d = new InputWeakSpot();
			if (d.ShowDialog() == DialogResult.OK)
			{
				trigger = d.Trigger();
				result = d.Result();
				slotCost = -1 * d.Bonus();
				propInfo = "Weak Spot - Trigger " + trigger + ", Result: " + result + ".";
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster m)
		{
			InputWeakSpot d = new InputWeakSpot();
			d.SetTrigger(trigger);
			d.SetResult(result);
			d.SetBonus(-1 * slotCost);
			if (d.ShowDialog() == DialogResult.OK)
			{
				trigger = d.Trigger();
				result = d.Result();
				slotCost = -1 * d.Bonus();
				propInfo = "Weak Spot - Trigger " + trigger + ", Result: " + result + ".";
			}
		}
	}
	[Serializable]
	public class BodyArmorArmor : MonsterProperty
	{
		public BodyArmorArmor()
		{
			slotCost = 2;
		}

		public override bool Prepare(Monster m)
		{
			propInfo = "Body Armor: Grants " + (5 * m.Tier).ToString() + " ranks of Armor to another monster of higher difficulty and rank.";
			return true;
		}

		public override void Recalculate(Monster m)
		{
			propInfo = "Body Armor: Grants " + (5 * m.Tier).ToString() + " ranks of Armor to another monster of higher difficulty and rank.";
		}
	}
	[Serializable]
	public class BodyArmorMArmor : MonsterProperty
	{
		public BodyArmorMArmor()
		{
			slotCost = 2;
		}

		public override bool Prepare(Monster m)
		{
			propInfo = "Body Armor: Grants " + (10 * m.Tier).ToString() + " ranks of M.Armor to another monster of higher difficulty and rank.";
			return true;
		}

		public override void Recalculate(Monster m)
		{
			propInfo = "Body Armor: Grants " + (10 * m.Tier).ToString() + " ranks of M.Armor to another monster of higher difficulty and rank.";
		}
	}
	[Serializable]
	public class BodyArmorBoth : MonsterProperty
	{
		public BodyArmorBoth()
		{
			slotCost = 3;
		}

		public override bool Prepare(Monster m)
		{
			propInfo = "Body Armor: Grants " + (5 * m.Tier).ToString() + " ranks of Armor and M.Armor to another monster of higher difficulty and rank.";
			return true;
		}

		public override void Recalculate(Monster m)
		{
			propInfo = "Body Armor: Grants " + (5 * m.Tier).ToString() + " ranks of Armor and M.Armor to another monster of higher difficulty and rank.";
		}
	}
}
