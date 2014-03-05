using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elena
{
	public enum AbilityType { Action, Reaction, Support }

	public enum AttackType { Physical, Magical, PhysicalEffect, MagicalEffect, Null }

	public enum Keyword { Weapon, Technique, Magic, Aimed, Spell, StatusEffect, Enhancement, Elemental, Recovery, Life, Drain, GroundBased, Movement, Speedy, Item, Steal, Stance, MultiAction, MultiHit, BreakChance, Performance }

	public enum TargetType { Single, Group, Row, Null, All, Self, Random }

	public enum DieType { d6, d8, d10, d12, Null }

	public enum StatusRider { Null, Delay, Duration, Effect }

	[Serializable]
	public abstract class MonsterAbility
	{
		protected int slotCost = 0;
		protected String name = "";
		protected bool nullAbility = false;
		public bool IsNull
		{
			get
			{
				return nullAbility;
			}
		}
		public virtual int SlotCost()
		{
			return slotCost;
		}
		public virtual bool Prepare(Monster m)
		{
			return true;
		}
		public String TargetTypeDisplay(TargetType t)
		{
			switch (t)
			{
				case TargetType.All:
					return "Target: All";
				case TargetType.Group:
					return "GT";
				case TargetType.Single:
					return "ST";
				case TargetType.Row:
					return "RT";
				case TargetType.Self:
					return "Self-targeting";
				case TargetType.Random:
					return "Randomly targeting";
				default:
					return "";
			}
		}
		public virtual void SetupParent(MonsterAbility parent) { }
		public virtual bool IsBaseAbility()
		{
			return false;
		}
		public virtual MonsterAbility GetParent()
		{
			return new NullAbility();
		}
		public override string ToString()
		{
			return name + " {" + SlotCost().ToString() + "}";
		}
		public void Complain(int complaint)
		{
			switch (complaint)
			{
				case 0:
					MessageBox.Show("OMG WTF BBQ", "seriously wtf!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 1:
					MessageBox.Show("You don't have enough slots to use that ability.", "Not enough slots!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 2:
					MessageBox.Show("That ability is restricted to mini-bosses and bosses.", "Ability Restricted!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 3:
					MessageBox.Show("Ability Modifiers need an ability to attach to!", "Unable to add Modifier!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 4:
					MessageBox.Show("Basic Attacks cannot have that modifier!", "Unable to add Modifier!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 5:
					MessageBox.Show("You don't have enough slots available to make that edit.", "Not enough slots!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 6:
					MessageBox.Show("Unranked monsters can only have one slot of that modifier.", "Editing Restricted!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;

				case 7:
					MessageBox.Show("That modifier cannot be added to an ability with those keywords.", "Unable to add modifier!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					break;
			}
		}
		public virtual void AddModifier(AbilityModifier ability) { }
		public virtual void RemoveModifier(AbilityModifier ability) { }
		public virtual bool HasModifiers()
		{
			return false;
		}
		public virtual IEnumerable<AbilityModifier> Modifiers()
		{
			return new List<AbilityModifier>();
		}
		public virtual string Text(bool showList = false)
		{
			String text = this.ToString();
			if (showList)
			{
				text += " : " + this.KeywordsList;
			}
			if (this.HasModifiers())
			{
				foreach (AbilityModifier a in this.Modifiers())
				{
					text += "\r\n\t" + a.Text();
				}
			}
			return text;
		}
		public virtual string Description()
		{
			return name;
		}

		public virtual void Edit(Monster monster) {}

		public virtual bool IsEditable()
		{
			return false;
		}
		public virtual void Recalculate(Monster monster) 
		{
			if (this.HasModifiers())
			{
				foreach (AbilityModifier m in this.Modifiers())
				{
					m.Recalculate(monster);
				}
			}
		}
		public virtual string KeywordsList { get { return ""; } }
	}
	[Serializable]
	public abstract class AbstractAbility : MonsterAbility
	{
		//an actual ability, as opposed to an ability modifier
		
		protected int baseCos = 0;
		protected int baseDelay = 0;
		protected int baseFloor = 0;
		protected int chargeTime = 0;
		protected int mp = 0;
		protected int mpScale = 0;
		protected int mpPerTierAfterOne = 0;
		protected Element baseElement = Element.Null;
		protected String effectsText = "";
		protected int basePower = 0;
		protected int powerPerTier = 0;
		protected int powerPerTierAfterOne = 0;
		protected int diePerTierAfterOne = 0;
		protected DieType dieType = DieType.Null;
		protected int dice = 0;
		protected bool hasChargeTime = false;
		protected bool ranged = false;
		protected bool piercing = false;
		protected StatusRider statusRider = StatusRider.Null;
		protected Monster parent;
		protected AttackType type;
		protected TargetType target;
		protected bool damagingAbility = false;
		protected List<AbilityModifier> modifiers = new List<AbilityModifier>();
		protected List<Keyword> keywords = new List<Keyword>();
		protected bool free = false;
		protected AbilityType abilityType = AbilityType.Action;
		public List<Keyword> Keywords
		{
			get
			{
				List<Keyword> retlist = new List<Keyword>(keywords);
				foreach (AbilityModifier m in this.Modifiers())
				{
					if (m.SwapsType)
					{
						if (keywords.Contains(Keyword.Technique))
						{
							retlist.Remove(Keyword.Technique);
							if (this.IsDamagingAbility())
							{
								retlist.Remove(Keyword.Weapon);
							}
							retlist.Add(Keyword.Magic);
							retlist.Add(Keyword.Spell);
						}
						else
						{
							retlist.Remove(Keyword.Magic);
							retlist.Remove(Keyword.Spell);
							retlist.Add(Keyword.Technique);
							if (this.IsDamagingAbility())
							{
								retlist.Add(Keyword.Weapon);
							}
						}
					}
				}
				return retlist;
			}
		}
		public AttackType AttackType
		{
			get
			{
				AttackType ret = type;
				if (this.HasModifiers())
				{
					foreach (AbilityModifier m in this.Modifiers())
					{
						if (m.ToType != Elena.AttackType.Null)
						{
							ret = m.ToType;
						}
					}
				}
				return ret;
			}
			set
			{
				type = value;
			}
		}
		public TargetType TargetType
		{
			get
			{
				TargetType ret = target;
				if (this.HasModifiers())
				{
					foreach (AbilityModifier m in this.Modifiers())
					{
						if (m.ToTarget != TargetType.Null)
						{
							ret = m.ToTarget;
						}
					}
				}
				return ret;
			}
			set
			{
				target = value;
			}
		}
		public bool HasCountdown
		{
			//this is distinct from "hasChargeTime", and is specifically for determining what happens when the Countdown modifier is selected.
			get
			{
				bool modifierCT = false;
				foreach (AbilityModifier m in modifiers)
				{
					if (m.ChargeTime != 0)
					{
						modifierCT = true;
					}
				}
				return modifierCT;
			}
		}
		public bool RangedStatus
		{
			get
			{
				return ranged;
			}
		}
		public bool PiercingStatus
		{
			get
			{
				return piercing;
			}
		}
		public StatusRider StatusRider
		{
			get
			{
				return statusRider;
			}
			set
			{
				statusRider = value;
			}
		}
		public override bool IsBaseAbility()
		{
			return true;
		}
		public override void AddModifier(AbilityModifier ability)
		{
			modifiers.Add(ability);
		}
		public override void RemoveModifier(AbilityModifier ability)
		{
			modifiers.Remove(ability);
		}	
		public override int SlotCost()
		{
			int baseCost = 0;
			if (!free)
			{
				baseCost = base.SlotCost();
			}
			foreach (AbilityModifier mod in modifiers)
			{
				baseCost += mod.SlotCost();
			}
			if (this.Element == parent.PrimaryElement && parent.PrimaryElement != Element.Null)
			{
				baseCost--;
			}
			return baseCost;
		}
		public override bool HasModifiers()
		{
			if (modifiers.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public override IEnumerable<AbilityModifier> Modifiers()
		{
			return modifiers;
		}
		public override string ToString()
		{
			string foo = "";
			//foo += " DEBUG: ";
			foreach (Keyword k in Keywords)
			{
				//foo += k.ToString() + ", ";
			}
			return this.Description() + " {" + this.SlotCost() + "}" + foo;
		}
		public override string Description()
		{
			int delayMod = 0;
			int powerMod = 0;
			double powerMult = 1;
			int floorMod = 0;
			int chargeTimeMod = 0;
			int cosMod = CoS;
			int mpCostMod = this.MPCost;
			int critRange = 0;
			bool rangedFinal = RangedStatus;
			bool piercingFinal = PiercingStatus;
			string statusRider = "";
			if (this.HasModifiers())
			{
				foreach (AbilityModifier m in modifiers)
				{
					delayMod += m.DelayMod;
					powerMod += m.PowerMod(parent.Tier);
					powerMult *= m.PowerMult;
					floorMod += m.FloorMod;
					chargeTimeMod += m.ChargeTime;
					cosMod += m.CoSMod;
					mpCostMod += m.MPCost(parent.Tier);
					critRange += m.CritRange;
					rangedFinal |= m.GivesRanged;
					piercingFinal |= m.GivesPiercing;
					statusRider += m.StatusString;
				}
			}
			
			int delay = (baseDelay + parent.DelayMod + delayMod) - parent.SPD;
			int floor = baseFloor + parent.FloorMod + floorMod;

			if (floor < 10)
			{
				floor = 10;
			}

			powerMult *= parent.PowerMult;

			if (delay < floor)
			{
				delay = floor;
			}

			int totalChargeTime = chargeTime + chargeTimeMod;

			String returnString = name;

			if (this.AttackType != AttackType.Null)
			{

				if (cosMod > 0)
				{
					returnString += " CoS:" + cosMod + " ";
				}

				if (critRange > 0)
				{
					returnString += "(Crit 1-" + critRange + ") ";
				}

				if (delay > 0)
				{
					returnString += delay + "D ";
				}

				if (mpCostMod > 0)
				{
					returnString += mpCostMod + " MP ";
				}

				if (totalChargeTime > 0)
				{
					returnString += "CT " + totalChargeTime + " ";
				}
			}

			if (this.AttackType == AttackType.Physical || this.AttackType == AttackType.Magical )
			{
				int power = basePower + parent.Tier * powerPerTier + (parent.Tier - 1) * powerPerTierAfterOne + powerMod;
				power *= LookupStat(parent, this.AttackType);
				if (powerMult != 0)
				{
					double powerCalc = (double)power;
					powerCalc *= powerMult;
					power = (int)Math.Floor(powerCalc);
				}
				
				returnString += dice + diePerTierAfterOne * (parent.Tier - 1) + dieType.ToString() + " + " + power;
			}

			if (this.AttackType == AttackType.Physical || this.AttackType == AttackType.Magical)
			{
				returnString += " " + this.AttackType.ToString();
			}

			returnString += " " + this.TargetTypeDisplay(this.TargetType);

			if (this.AttackType != AttackType.Null)
			{
				if (this.Element != Element.Null)
				{
					returnString += " " + this.Element.ToString();
				}

				if (this.AttackType == AttackType.PhysicalEffect)
				{
					returnString += " Physical Effect";
				}

				if (this.AttackType == AttackType.MagicalEffect)
				{
					returnString += " Magical Effect";
				}
			}

			returnString += statusRider;

			if (rangedFinal)
			{
				returnString += " Ranged";
			}

			if (piercingFinal)
			{
				returnString += " Piercing";
			}

			return returnString + " ";
		}
		public bool Free
		{
			get
			{
				return free;
			}
			set
			{
				free = value;
			}
		}
		public int MPCost
		{
			get
			{
				if (parent.Tier == 1)
				{
					return mp + mpScale * parent.Tier;
				}
				else
				{
					return mp + mpScale * parent.Tier + mpPerTierAfterOne * (parent.Tier - 1);
				}
			}
			set
			{
				mp = value;
			}
		}
		public Element Element
		{
			get
			{
				Element ret = baseElement;
				if (this.HasModifiers())
				{
					foreach (AbilityModifier m in this.Modifiers())
					{
						if (m.ToElement != Element.Null)
						{
							ret = m.ToElement;
						}
					}
				}
				return ret;
			}
			set
			{
				baseElement = value;
			}
		}
		public DieType DieType
		{
			get
			{
				return dieType;
			}
			set
			{
				dieType = value;
			}
		}
		public int Dice
		{
			get
			{
				return dice;
			}
			set
			{
				dice = value;
			}
		}
		public int CoS
		{
			get
			{
				int accBonus = 0;
				if (this.HasKeyword(Keyword.Weapon))
				{
					accBonus = parent.ACC * 5;
				}
				return baseCos + accBonus;
			}
			set
			{
				baseCos = value;
			}
		}
		public bool IsDamagingAbility()
		{
			return damagingAbility;
		}
		public int LookupStat(Monster parent, AttackType type)
		{
			if (type == AttackType.Physical)
			{
				return parent.ATK;
			}
			else if (type == AttackType.Magical)
			{
				return parent.MAG;
			}
			else
			{
				//wtf?
				return 0;
			}
		}
		public bool HasChargeTime()
		{
			if (hasChargeTime)
			{
				return true;
			}
			else
			{
				bool modifierCT = false;
				foreach (AbilityModifier m in modifiers)
				{
					if (m.ChargeTime != 0)
					{
						modifierCT = true;
					}
				}
				return modifierCT;
			}
		}
		public bool HasInflictedStatus { get; set; }

		internal bool HasKeyword(Keyword keyword)
		{
			return Keywords.Contains(keyword);
		}

		public override string KeywordsList
		{
			get
			{
				List<String> kwstrings = new List<String>();
				foreach (Keyword k in keywords)
				{
					kwstrings.Add(k.ToString());
				}
				return string.Join(", ", kwstrings.ToArray());
			}
		}
	}
	[Serializable]
	public abstract class AbilityModifier : MonsterAbility
	{
		protected AbstractAbility modifiedAbility = (AbstractAbility)(new NullAbility());
		protected int delayMod = 0;
		protected int floorMod = 0;
		protected int powerMod = 0;
		protected double powerMult = 1;
		protected int chargeTime = 0;
		protected int cosMod = 0;
		protected int mpCost = 0;
		protected int mpScale = 0;
		protected int critRange = 0;
		protected Element toElement = Element.Null;
		protected AttackType toType = AttackType.Null;
		protected TargetType toTarg = TargetType.Null;
		protected bool swapsType = false;
		protected bool rangedProperty = false;
		protected bool piercingProperty = false;
		protected string statusRiderText = "";
		protected List<Keyword> addsKeywords = new List<Keyword>();
		public override MonsterAbility GetParent()
		{
			return modifiedAbility;
		}
		public override bool IsBaseAbility()
		{
			return false;
		}
		public override void SetupParent(MonsterAbility parent)
		{
			modifiedAbility = (AbstractAbility)parent;
		}
		public override bool Prepare(Monster m)
		{
			if (modifiedAbility.IsNull)
			{
				if (m.Abilities.Count == 0)
				{
					Complain(3);
					return false;
				}
				else
				{
					InputSelectAbility d = new InputSelectAbility(m);
					if (d.ShowDialog() == DialogResult.OK)
					{
						if (d.GetSelectedAbility().IsNull)
						{
							Complain(3);
							return false;
						}
						else
						{
							modifiedAbility = d.GetSelectedAbility();
							return true;
						}
					}
					else
					{
						return false;
					}
				}
			}
			else
			{
				return true;
			}
		}
		public string StatusString
		{
			get
			{
				return statusRiderText;
			}
		}
		public int DelayMod
		{
			get
			{
				return delayMod;
			}
		}
		public int CritRange
		{
			get
			{
				return critRange;
			}
		}
		public bool GivesRanged
		{
			get
			{
				return rangedProperty;
			}
		}
		public bool GivesPiercing
		{
			get
			{
				return piercingProperty;
			}
		}
		public int PowerMod(int tier)
		{
			return powerMod * tier;
		}
		public double PowerMult
		{
			get
			{
				return powerMult;
			}
		}
		public int MPCost(int tier)
		{
			return mpCost + mpScale * tier;
		}
		public int FloorMod
		{
			get
			{
				return floorMod;
			}
		}
		public int ChargeTime
		{
			get
			{
				return chargeTime;
			}
		}
		public int CoSMod
		{
			get
			{
				return cosMod;
			} 
		}
		public Element ToElement
		{
			get
			{
				return toElement;
			}
		}
		public AttackType ToType
		{
			get
			{
				return toType;
			}
		}
		public TargetType ToTarget 
		{
			get
			{
				return toTarg;
			}
		}
		public bool SwapsType
		{
			get
			{
				return swapsType;
			}
		}
		public List<Keyword> AddedKeywords
		{
			get
			{
				return addsKeywords;
			}
		}
	}
	[Serializable]
	public class NullAbility : AbstractAbility
	{
		public NullAbility()
		{
			nullAbility = true;
		}
	}
#region Abilities
	[Serializable]
	public class BasicAttack : AbstractAbility
	{
		int delayMod = 0;
		int floorMod = 0;
		int powerMod = 0;
		bool baseAttack;
		string baseName;

		public BasicAttack()
		{
			baseCos = 80;
			baseFloor = 20;
			dice = 1;
			basePower = 0;
			damagingAbility = true;
			keywords.Add(Keyword.Weapon);
			keywords.Add(Keyword.Technique);
			type = AttackType.Physical;
			target = TargetType.Single;
		}

		public void SetAsDefault()
		{
			baseAttack = true;
		}

		public virtual bool NotNull()
		{
			return true;
		}
		public override bool IsEditable()
		{
			return true;
		}
		public override void Edit(Monster monster)
		{
			InputName d = new InputName();
			d.SetName(baseName);
			if (d.ShowDialog() == DialogResult.OK)
			{
				String tmpName = d.ReturnName();
				if (tmpName.Length > 0)
				{
					BasicAttackForm b = new BasicAttackForm();
					b.SetTypeByDie(dieType);
					if (b.ShowDialog() == DialogResult.OK)
					{
						baseName = tmpName;
						if (baseAttack)
						{
							name = "Basic Attack: [" + tmpName + "]";
						}
						else
						{
							name = "[" + tmpName + "]";
						}
						switch (b.ChosenString())
						{
							case "Light":
								//Light Attack
								baseDelay = 40;
								basePower = 3;
								powerPerTier = 3;
								dieType = DieType.d8;
								break;

							case "Medium":
								//Medium Attack
								baseDelay = 50;
								basePower = 4;
								powerPerTier = 4;
								dieType = DieType.d10;
								break;

							case "Heavy":
								//Heavy Attack
								baseDelay = 60;
								basePower = 5;
								powerPerTier = 5;
								dieType = DieType.d12;
								break;
						}
					}
				}
			}
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			slotCost = 1;

			InputName d = new InputName();
			if (d.ShowDialog() == DialogResult.OK)
			{
				String tmpName = d.ReturnName();
				if (tmpName.Length > 0)
				{
					baseName = tmpName;
					if (baseAttack)
					{
						name = "Basic Attack: [" + tmpName + "]";
					}
					else
					{
						name = "[" + tmpName + "]";
					}
					BasicAttackForm b = new BasicAttackForm();
					if (b.ShowDialog() == DialogResult.OK)
					{
						switch (b.ChosenString())
						{
							case "Light":
								//Light Attack
								baseDelay = 40;
								basePower = 3;
								powerPerTier = 3;
								dieType = DieType.d8;
								break;

							case "Medium":
								//Medium Attack
								baseDelay = 50;
								basePower = 4;
								powerPerTier = 4;
								dieType = DieType.d10;
								break;

							case "Heavy":
								//Heavy Attack
								baseDelay = 60;
								basePower = 5;
								powerPerTier = 5;
								dieType = DieType.d12;
								break;
						}
						return base.Prepare(m);
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public void ApplyModifiers()
		{
			delayMod = 0;
			floorMod = 0;
			powerMod = 0;
			if (this.HasModifiers())
			{
				foreach (AbilityModifier m in modifiers)
				{
					delayMod += m.DelayMod;
					floorMod += m.FloorMod;
					powerMod += m.PowerMod(parent.Tier);
				}
			}
		}

		public int ModifiedDelay
		{
			get
			{
				return baseDelay + delayMod;
			}
		}

		public int ModifiedFloor
		{
			get
			{
				return baseFloor + floorMod;
			}
		} 

		public int ModifiedPower { get { return basePower + powerMod; } }

		public int PowerPerTier { get { return powerPerTier; } }
		public int PowerPerTierAfterOne { get { return powerPerTierAfterOne; } }
		public int DicePerTierAfterOne { get { return diePerTierAfterOne; } }
	}
	[Serializable]
	public class NullAttack : BasicAttack
	{
		public NullAttack()
			: base()
		{
			baseDelay = 0;
			powerPerTier = 0;
			dieType = DieType.Null;
			nullAbility = true;
		}
		public override bool Prepare(Monster m)
		{
			slotCost = 0;
			name = "[NO BASIC ATTACK]";
			parent = m;
			return true;
		}
		public override bool NotNull()
		{
			return false;
		}
	}
	[Serializable]
	public class LightAttack : BasicAttack
	{
		public LightAttack() 
			: base()
		{
			baseDelay = 40;
			basePower = 3;
			powerPerTier = 3;
			dieType = DieType.d8;
		}

		public override bool Prepare(Monster m)
		{
			bool baseVal = base.Prepare(m);
			name += " - Light Attack";
			return baseVal;
		}
	}
	[Serializable]
	public class MediumAttack : BasicAttack
	{
		public MediumAttack() 
			: base()
		{
			baseDelay = 50;
			basePower = 4;
			powerPerTier = 4;
			dieType = DieType.d10;
		}

		public override bool Prepare(Monster m)
		{
			bool baseVal = base.Prepare(m);
			name += " - Medium Attack";
			return baseVal;
		}
	}
	[Serializable]
	public class HeavyAttack : BasicAttack
	{
		public HeavyAttack()
			: base()
		{
			baseDelay = 60;
			basePower = 5;
			powerPerTier = 5;
			dieType = DieType.d12;
		}

		public override bool Prepare(Monster m)
		{
			bool baseVal = base.Prepare(m);
			name += " - Heavy Attack";
			return baseVal;
		}
	}
	[Serializable]
	public class SpecialAbility : AbstractAbility
	{
		private string savedName;
		public SpecialAbility()
		{
			baseCos = 95;
			baseDelay = 40;
			baseFloor = 15;
			slotCost = 1;
			target = TargetType.Single;
		}

		public override bool Prepare(Monster m)
		{
			parent = m;
			InputName d = new InputName();
			InputEffectType typeDialog = new InputEffectType();
			if (d.ShowDialog() == DialogResult.OK && typeDialog.ShowDialog() == DialogResult.OK)
			{
				savedName = d.ReturnName();
				if (savedName.Length > 0)
				{
					name = "[" + savedName + "]";
					type = typeDialog.SelectedType();
					if (type == AttackType.PhysicalEffect)
					{
						baseDelay = 45;
						keywords.Add(Keyword.Technique);
					}
					else
					{
						MPCost = 21;
						mpPerTierAfterOne = 3;
						keywords.Add(Keyword.Magic);
						keywords.Add(Keyword.Spell);
					}
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputName d = new InputName();
			d.SetName(savedName);
			InputEffectType typeDialog = new InputEffectType();
			if (d.ShowDialog() == DialogResult.OK && typeDialog.ShowDialog() == DialogResult.OK)
			{
				savedName = d.ReturnName();
				if (savedName.Length > 0)
				{
					name = "[" + savedName + "]";
					type = typeDialog.SelectedType();
					if (type == AttackType.PhysicalEffect)
					{
						baseDelay = 45;
						keywords.Add(Keyword.Technique);
						keywords.Remove(Keyword.Magic);
						keywords.Remove(Keyword.Spell);
					}
					else
					{
						MPCost = 21;
						mpPerTierAfterOne = 3;
						keywords.Add(Keyword.Magic);
						keywords.Add(Keyword.Spell);
						keywords.Remove(Keyword.Technique);
					}
				}
			}
		}
	}
	[Serializable]
	public class Enhancement : AbstractAbility
	{
		private string chosen;
		private string baseName;
		public Enhancement()
		{
			MPCost = 60;
			mpPerTierAfterOne = 20;
			baseFloor = 15;
			baseDelay = 40;
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			InputEnhancement enhancementDialog = new InputEnhancement();
			InputName nameDialog = new InputName();
			if (nameDialog.ShowDialog() == DialogResult.OK && enhancementDialog.ShowDialog() == DialogResult.OK)
			{
				slotCost = enhancementDialog.SlotCost();
				chosen = enhancementDialog.StatusString;
				if (base.Prepare(m))
				{
					if (enhancementDialog.HasSurcharge())
					{
						baseDelay += 5;
					}
					type = enhancementDialog.SelectedType;
					baseName = nameDialog.ReturnName();
					keywords.Add(Keyword.Enhancement);
					if (type == AttackType.PhysicalEffect)
					{
						keywords.Add(Keyword.Technique);
					}
					else
					{
						keywords.Add(Keyword.Magic);
						keywords.Add(Keyword.Spell);
					}
					name = "[" + baseName + "] - Enhancement: " + chosen + " ";
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputName nameDialog = new InputName();
			InputEnhancement enhancementDialog = new InputEnhancement();
			enhancementDialog.SelectedType = type;
			nameDialog.SetName(baseName);
			enhancementDialog.StatusString = chosen;
			nameDialog.SetName(baseName);
			baseDelay = 40;
			if (nameDialog.ShowDialog() == DialogResult.OK && enhancementDialog.ShowDialog() == DialogResult.OK)
			{
				slotCost = enhancementDialog.SlotCost();
				chosen = enhancementDialog.StatusString;
				if (enhancementDialog.HasSurcharge())
				{
					baseDelay += 5;
				}
				type = enhancementDialog.SelectedType;
				baseName = nameDialog.ReturnName();
				name = "[" + baseName + "] - Enhancement: " + chosen + " ";
				if (type == AttackType.PhysicalEffect)
				{
					keywords.Add(Keyword.Technique);
					keywords.Remove(Keyword.Magic);
					keywords.Remove(Keyword.Spell);
				}
				else
				{
					keywords.Add(Keyword.Magic);
					keywords.Add(Keyword.Spell);
					keywords.Remove(Keyword.Technique);
				}
			}
		}
	}
	[Serializable]
	public class DevourBasic : AbstractAbility
	{
		public DevourBasic()
		{
			baseDelay = 40;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 2;
			name = "[Devour (Basic)]";
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			if (m.Rank.IsMinibossOrBoss())
			{
				keywords.Add(Keyword.Technique);
				keywords.Add(Keyword.Enhancement);
				return true;
			}
			else
			{
				Complain(2);
				return false;
			}
		}
	}
	[Serializable]
	public class DevourPlus : AbstractAbility
	{
		public DevourPlus()
		{
			baseDelay = 40;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 4;
			name = "[Devour (w/ status)]";
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			if (m.Rank.IsMinibossOrBoss())
			{
				keywords.Add(Keyword.Technique);
				keywords.Add(Keyword.Enhancement);
				return true;
			}
			else
			{
				Complain(2);
				return false;
			}
		}
	}
	[Serializable]
	public class AlarmSingle : AbstractAbility
	{
		public AlarmSingle()
		{
			baseDelay = 40;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 2;
			keywords.Add(Keyword.Magic);
			name = "[Alarm (single assist)]";
		}

		public override bool Prepare(Monster m)
		{
			parent = m;
			keywords.Add(Keyword.Magic);
			return true;
		}
	}
	[Serializable]
	public class AlarmMulti : AbstractAbility
	{
		public AlarmMulti()
		{
			baseDelay = 40;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 4;
			keywords.Add(Keyword.Magic);
			name = "[Alarm (multi assist)]";
		}

		public override bool Prepare(Monster m)
		{
			parent = m;
			keywords.Add(Keyword.Magic);
			return true;
		}
	}
	[Serializable]
	public class CallForHelp : AbstractAbility
	{
		public CallForHelp()
		{
			baseDelay = 40;
			baseFloor = 15;
			baseCos = 90;
			slotCost = 4;
			chargeTime = 40;
			hasChargeTime = true;
			keywords.Add(Keyword.Magic);
			name = "[Call For Help!]";
		}

		public override bool Prepare(Monster m)
		{
			parent = m;
			keywords.Add(Keyword.Magic);
			return true;
		}
	}
	[Serializable]
	public class FormChange : AbstractAbility
	{
		public FormChange()
		{
			baseDelay = 15;
			baseFloor = 5;
			baseCos = 255;
			slotCost = 2;
			name = "[Form Change]";
		}

		public override bool Prepare(Monster m)
		{
			parent = m;
			if (m.Rank.IsMinibossOrBoss())
			{
				keywords.Add(Keyword.Speedy);
				return true;
			}
			else
			{
				Complain(2);
				return false;
			}
		}
	}
	[Serializable]
	public class StatusShake2 : AbstractAbility
	{
		public StatusShake2()
		{
			baseDelay = 60;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 1;
			name = "[Status Shake (-1)]";
		}

		public override bool Prepare(Monster m)
		{
			parent = m;
			return true;
		}
	}
	[Serializable]
	public class StatusShake4 : AbstractAbility
	{
		public StatusShake4()
		{
			baseDelay = 60;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 2;
			name = "[Status Shake (-3)]";
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			return true;
		}
	}
	[Serializable]
	public class StatusShakeAll : AbstractAbility
	{
		public StatusShakeAll()
		{
			baseDelay = 60;
			baseFloor = 15;
			baseCos = 100;
			slotCost = 4;
			name = "[Status Shake (ALL)]";
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			return true;
		}
	}
	[Serializable]
	public class StoreElement : AbstractAbility
	{
		public StoreElement()
		{
			slotCost = 2;
			abilityType = AbilityType.Reaction;
			type = AttackType.Null;
			target = Elena.TargetType.Null;
			name = "[Store Element] - Reaction on taking damage from elemental weakness. Stack +25% mod to magic attack. See MCS.";
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			return true;
		}
	}

	#region Modifiers
	[Serializable]
	public class TypeSwap : AbilityModifier
	{
		public TypeSwap()
		{
			slotCost = 1;
			name = "Type Swap";
			swapsType = true;
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				if (modifiedAbility.AttackType == AttackType.Physical)
				{
					InputElement d = new InputElement();
					if (d.ShowDialog() == DialogResult.OK)
					{
						toElement = d.SelectedElement();
						name = "Type Swap to Magical: " + toElement.ToString();
						toType = AttackType.Magical;
						mpCost = 21;
						mpScale = 3;
						if (modifiedAbility.IsDamagingAbility())
						{
							cosMod = 20;
						}
						return true;
					}
				}
				else
				{
					name = "Type Swap to Physical";
					toType = AttackType.Physical;
					if (modifiedAbility.IsDamagingAbility())
					{
						cosMod = -10;
					}
					mpCost = 0;
					mpScale = 0;
					return true;
				}
			}
			return false;
		}
		public override bool IsEditable()
		{
			return true;
		}
		public override void Edit(Monster monster)
		{
			if (toType == AttackType.Magical)
			{
				InputElement d = new InputElement();
				d.SetElement(toElement);
				if (d.ShowDialog() == DialogResult.OK)
				{
					toElement = d.SelectedElement();
					name = "Type Swap to Magical: " + toElement.ToString();
				}
			}
		}
	}
	[Serializable]
	public class GroupAttack : AbilityModifier
	{
		public GroupAttack()
		{
			slotCost = 2;
			name = "Group Attack";
			toTarg = TargetType.Group;
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				InputAdditionalCost dialog = new InputAdditionalCost(10, 40);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					string additionalCostString;
					if (dialog.Result() == AdditionalCost.Delay)
					{
						//delay cost chosen
						delayMod = 10;
						additionalCostString = " (Cost: +10D)";
					}
					else
					{
						//MP Cost chosen
						mpScale = 40;
						additionalCostString = " (Cost: +40 MP/Tier)";
					}
					name += additionalCostString;
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		public override bool IsEditable()
		{
			return true;
		}
		public override void Edit(Monster monster)
		{
			string additionalCostString;
			InputAdditionalCost dialog = new InputAdditionalCost(10, 40);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.Result() == AdditionalCost.Delay)
				{
					//delay cost chosen
					delayMod = 10;
					mpScale = 0;
					additionalCostString = " (Cost: +10D)";
				}
				else
				{
					//MP Cost chosen
					mpScale = 40;
					delayMod = 0;
					additionalCostString = " (Cost: +40 MP/Tier)";
				}
				name = "Group Attack" + additionalCostString;
			}
		}
	}
	[Serializable]
	public class RowCutter : AbilityModifier
	{
		public RowCutter()
		{
			slotCost = 1;
			name = "Row Cutter";
			toTarg = TargetType.Row;
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				string additionalCostString;
				InputAdditionalCost dialog = new InputAdditionalCost(5, 20);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (dialog.Result() == AdditionalCost.Delay)
					{
						//delay cost chosen
						delayMod = 5;
						additionalCostString = " (Cost: +5D)";
					}
					else
					{
						//MP Cost chosen
						mpScale = 20;
						additionalCostString = " (Cost: +20 MP/Tier)";
					}
					name += additionalCostString;
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		public override bool IsEditable()
		{
			return true;
		}
		public override void Edit(Monster monster)
		{
			string additionalCostString;
			InputAdditionalCost dialog = new InputAdditionalCost(5, 20);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.Result() == AdditionalCost.Delay)
				{
					//delay cost chosen
					delayMod = 5;
					mpScale = 0;
					additionalCostString = " (Cost: +5D)";
				}
				else
				{
					//MP Cost chosen
					mpScale = 20;
					delayMod = 0;
					additionalCostString = " (Cost: +20 MP/Tier)";
				}
				name = "Row Cutter" + additionalCostString;
			}
		}
	}
	[Serializable]
	public class ElementShift : AbilityModifier
	{
		public ElementShift()
		{
			slotCost = 1;
		}
		public override bool Prepare(Monster m)
		{
			if (base.Prepare(m))
			{
				InputElement d = new InputElement();
				if (d.ShowDialog() == DialogResult.OK)
				{
					toElement = d.SelectedElement();
					name = "Element Shift: " + toElement.ToString();
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputElement d = new InputElement();
			if (d.ShowDialog() == DialogResult.OK)
			{
				toElement = d.SelectedElement();
				name = "Element Shift: " + toElement.ToString();
			}
		}
	}
	[Serializable]
	public class Faster : AbilityModifier
	{
		public Faster()
		{
			slotCost = 1;
			name = "Faster";
			delayMod = -5;
			floorMod = -5;
		}
		public override bool Prepare(Monster m)
		{
			return base.Prepare(m);
		}
	}
	[Serializable]
	public class Counter : AbilityModifier
	{
		private string trigger;
		public Counter()
		{
			slotCost = 1;
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				InputCounter d = new InputCounter();
				if (d.ShowDialog() == DialogResult.OK)
				{
					cosMod = d.CoSMod();
					name = "Counters: " + d.Trigger();
					trigger = d.Trigger();
					if (modifiedAbility.HasChargeTime())
					{
						slotCost = 3;
					}
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputCounter d = new InputCounter();
			d.SetCoSMod(cosMod);
			d.SetTrigger(trigger);
			if (d.ShowDialog() == DialogResult.OK)
			{
				cosMod = d.CoSMod();
				name = "Counters: " + d.Trigger();
				trigger = d.Trigger();
				if (modifiedAbility.HasChargeTime())
				{
					slotCost = 3;
				}
				else
				{
					slotCost = 1;
				}
			}
		}
		public override void Recalculate(Monster monster)
		{
			if (modifiedAbility.HasChargeTime())
			{
				slotCost = 3;
			}
			else
			{
				slotCost = 1;
			}
		}

	}
	[Serializable]
	public class PowerStrike : AbilityModifier
	{
		private int ranks;
		public PowerStrike()
		{
		}
		public override bool Prepare(Monster m)
		{
			bool allowMP = true;
			if (this.GetParent() == m.BasicAttack)
			{
				allowMP = false;
			}
			if (base.Prepare(m))
			{
				if (!allowMP)
				{
					delayMod = 5;
					if (m.Rank.IsMinibossOrBoss())
					{
						InputRanks d = new InputRanks();
						if (d.ShowDialog() == DialogResult.OK)
						{
							slotCost = d.NumberOfRanks();
							name = "Power Strike: " + d.NumberOfRanks() + " Ranks (Cost: +5D)";
							powerMod = 2 * d.NumberOfRanks();
							ranks = d.NumberOfRanks();
							return true;
						}
						else
						{
							return false;
						}
					} 
					else
					{
						slotCost = 1;
						ranks = 1;
						name = "Power Strike (Cost: +5D)";
						powerMod = 2;
						return true;
					}
				}
				InputAdditionalCost d1 = new InputAdditionalCost(5, 20);
				if (d1.ShowDialog() == DialogResult.OK)
				{
					string additionalCostString;
					if (d1.Result() == AdditionalCost.Delay)
					{
						delayMod = 5;
						additionalCostString = " (Cost: +5D)";
					}
					else
					{
						mpScale = 20;
						additionalCostString = " (Cost: +20 MP/Tier)";
					}

					if (m.Rank.IsMinibossOrBoss())
					{
						//figure out how many ranks are being taken
						InputRanks d = new InputRanks();
						d.SlotsPerRank = 1;
						
						if (d.ShowDialog() == DialogResult.OK)
						{
							ranks = d.NumberOfRanks();
							slotCost = d.NumberOfRanks();
							name = "Power Strike: " + d.NumberOfRanks() + " Ranks" + additionalCostString;
							powerMod = 2 * d.NumberOfRanks();
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						slotCost = 1;
						ranks = 1;
						name = "Power Strike" + additionalCostString;
						powerMod = 2;
						return true;
					}
				}
				else
				{
					return false; 
				}
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
		public override void Edit(Monster monster)
		{
			if (monster.Rank.IsMinibossOrBoss())
			{
				//figure out how many ranks are being taken
				InputRanks d = new InputRanks();
				InputAdditionalCost d1 = new InputAdditionalCost(5, 20);
				d.SetRanks(ranks);
				if (d.ShowDialog() == DialogResult.OK && d1.ShowDialog() == DialogResult.OK)
				{
					slotCost = d.NumberOfRanks();
					powerMod = 2 * d.NumberOfRanks();
					ranks = d.NumberOfRanks();
					string additionalCostString;
					if (d1.Result() == AdditionalCost.Delay)
					{
						additionalCostString = " (Cost: +5D)";
						delayMod = 5;
						mpScale = 0;
					}
					else
					{
						additionalCostString = " (Cost: +20 MP/Tier)";
						mpScale = 20;
						delayMod = 0;
					}
					name = "Power Strike: " + ranks.ToString() + " Ranks" + additionalCostString;
				}
			}
			else
			{
				Complain(6);
			}
		}
	}
	[Serializable]
	public class Critical : AbilityModifier
	{
		private int ranks;
		public Critical()
		{
			name = "Critical";
		}
		public override bool Prepare(Monster m)
		{
			if (base.Prepare(m))
			{
				AbstractAbility abs = (AbstractAbility)GetParent();
				if (abs.HasKeyword(Keyword.Weapon))
				{
					int slotSurcharge;
					if (m.Tier == 1)
					{
						slotSurcharge = 2;
					}
					else
					{
						slotSurcharge = 0;
					}
					InputRanks d = new InputRanks();
					d.SlotSurcharge = slotSurcharge;
					if (d.ShowDialog() == DialogResult.OK)
					{
						ranks = d.NumberOfRanks();
						slotCost = ranks + slotSurcharge;
						critRange = 5 * ranks;
						name = "Critical : " + ranks.ToString() + " Ranks";
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					Complain(7);
					return false;
				}
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

		public override void Edit(Monster monster)
		{
			int slotSurcharge;
			if (monster.Tier == 1)
			{
				slotSurcharge = 2;
			}
			else
			{
				slotSurcharge = 0;
			}
			InputRanks d = new InputRanks();
			d.SlotSurcharge = slotSurcharge;
			d.SetRanks(ranks);
			if (d.ShowDialog() == DialogResult.OK)
			{
				ranks = d.NumberOfRanks();
				slotCost = ranks + slotSurcharge;
				critRange = 5 * ranks;
				name = "Critical : " + ranks.ToString() + " Ranks";
			}
		}

		public override void Recalculate(Monster monster)
		{
			if (monster.Tier == 1)
			{
				slotCost = 2 + ranks;
				critRange = 5 * ranks;
				name = "Critical : " + ranks.ToString() + " Ranks";
			}
			else
			{
				slotCost = ranks;
				critRange = 5 * ranks;
				name = "Critical : " + ranks.ToString() + " Ranks";
			}
			AbstractAbility abs = (AbstractAbility)GetParent();
			if (!abs.HasKeyword(Keyword.Weapon))
			{
				name = "Critical cannot apply to abilities without the Weapon property. :(";
				slotCost = 0;
				critRange = 0;
			}
		}
	}
	[Serializable]
	public class Piercing : AbilityModifier
	{
		public Piercing()
		{
			name = "Piercing";
			piercingProperty = true;
		}
		public override bool Prepare(Monster m)
		{
			if (base.Prepare(m))
			{
				if (m.Tier < 4)
				{
					slotCost = 4;
					return true;
				}
				else
				{
					slotCost = 2;
					return true;
				}
			}
			else
			{
				return false;
			}
		}
		public override void Recalculate(Monster monster)
		{
			if (monster.Tier < 4)
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
	public class AddedStatus : AbilityModifier
	{
		private string addedCostString;
		private bool allowMP = false;
		private bool costIsDelay = true;
		private int cos = 0;
		private string statusString = "";
		private int cosRanks = 0;
		private int durRanks = 0;
		private int potRanks = 0;
		private int delRanks = 0;
		private bool gravity = false;
		private string baseStatus = "";

		public AddedStatus()
		{
		}
		public override bool Prepare(Monster m)
		{
			allowMP = true;
			if (this.GetParent() == m.BasicAttack)
			{
				allowMP = false;
			}
			if (base.Prepare(m))
			{
				InputAddedStatus savedDialog = new InputAddedStatus(allowMP);
				if (savedDialog.ShowDialog() == DialogResult.OK)
				{
					slotCost = savedDialog.SlotCost();
					costIsDelay = savedDialog.CostIsDelay;
					if (costIsDelay)
					{
						delayMod = savedDialog.DelayCost();
						addedCostString = " (Cost: " + delayMod.ToString() + " +D)";
					}
					else
					{
						mpScale = savedDialog.MPScale();
						addedCostString = " (Cost: " + mpScale.ToString() + " MP/Tier)";
					}
					cos = Int32.Parse(savedDialog.CoS());
					gravity = savedDialog.Gravity;
					baseStatus = savedDialog.BaseStatus;
					cosRanks = savedDialog.CoSRanks;
					durRanks = savedDialog.DurRanks;
					potRanks = savedDialog.PotRanks;
					delRanks = savedDialog.DelRanks;
					statusString = savedDialog.StatusString();
					name = "Added Status: " + cos + " CoS " + statusString + addedCostString;
					statusRiderText = " <" + cos + "% " + statusString + ">";
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputAddedStatus savedDialog = new InputAddedStatus(allowMP);
			savedDialog.CostIsDelay = costIsDelay;
			savedDialog.DelRanks = delRanks;
			savedDialog.PotRanks = potRanks;
			savedDialog.DurRanks = durRanks;
			savedDialog.CoSRanks = cosRanks;
			savedDialog.Gravity = gravity;
			savedDialog.BaseStatus = baseStatus;
			if (savedDialog.ShowDialog() == DialogResult.OK)
			{
				slotCost = savedDialog.SlotCost();
				costIsDelay = savedDialog.CostIsDelay;
				if (savedDialog.CostIsDelay)
				{
					delayMod = savedDialog.DelayCost();
					addedCostString = " (Cost: " + delayMod.ToString() + " +D)";
					mpScale = 0;
				}
				else
				{
					mpScale = savedDialog.MPScale();
					addedCostString = " (Cost: " + mpScale.ToString() + " MP/Tier)";
					delayMod = 0;
				}
				cos = Int32.Parse(savedDialog.CoS());
				gravity = savedDialog.Gravity;
				baseStatus = savedDialog.BaseStatus;
				cosRanks = savedDialog.CoSRanks;
				durRanks = savedDialog.DurRanks;
				potRanks = savedDialog.PotRanks;
				delRanks = savedDialog.DelRanks;
				statusString = savedDialog.StatusString();
				name = "Added Status: " + savedDialog.CoS() + " CoS " + savedDialog.StatusString() + addedCostString;
				statusRiderText = " <" + savedDialog.CoS() + "% " + statusString + ">";
			}
		}
		public override void Recalculate(Monster monster)
		{
			int cosBeforeTargetMods = cos;
			int cosAfterTargetMods;
			AbstractAbility p = (AbstractAbility)this.GetParent();
			if (p.TargetType == TargetType.Group)
			{
				cosAfterTargetMods = cosBeforeTargetMods - 10;
			}
			else if (p.TargetType == TargetType.Row)
			{
				cosAfterTargetMods = cosBeforeTargetMods - 5;
			}
			else
			{
				cosAfterTargetMods = cosBeforeTargetMods;
			}
			name = "Added Status: " + cosAfterTargetMods + " CoS " + statusString + addedCostString;
			statusRiderText = " <" + cosAfterTargetMods + "% " + statusString + ">";
		}
	}
	[Serializable]
	public class InflictsStatus : AbilityModifier
	{
		private int baseCoSMod = 0;
		private string statusString = "";
		private bool costIsDelay = false;
		public InflictsStatus()
		{
			
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				InputInflictsStatus savedDialog = new InputInflictsStatus();
				if (savedDialog.ShowDialog() == DialogResult.OK)
				{
					slotCost = savedDialog.SlotCost();
					cosMod = savedDialog.CoSMod();
					baseCoSMod = cosMod;
					string addedCostString;
					if (savedDialog.CostIsDelay)
					{
						costIsDelay = true;
						delayMod = savedDialog.DelayCost();
						addedCostString = " (Cost: " + delayMod.ToString() + " +D)";
					}
					else
					{
						costIsDelay = false;
						mpScale = savedDialog.MPScale();
						addedCostString = " (Cost: " + mpScale.ToString() + " MP/Tier)";
					}
					statusString = savedDialog.StatusString();
					name = "Inflicts Status - " + statusString + addedCostString;
					statusRiderText = " <Inflicts " + statusString + ">";
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputInflictsStatus savedDialog = new InputInflictsStatus();
			savedDialog.LoadFromString(statusString);
			savedDialog.CostIsDelay = costIsDelay;
			if (savedDialog.ShowDialog() == DialogResult.OK)
			{
				slotCost = savedDialog.SlotCost();
				string addedCostString;
				if (savedDialog.CostIsDelay)
				{
					costIsDelay = true;
					delayMod = savedDialog.DelayCost();
					addedCostString = " (Cost: " + delayMod.ToString() + " +D)";
					mpScale = 0;
				}
				else
				{
					costIsDelay = false;
					mpScale = savedDialog.MPScale();
					addedCostString = " (Cost: " + mpScale.ToString() + " MP/Tier)";
					delayMod = 0;
				}
				statusString = savedDialog.StatusString();
				name = "Inflicts Status - " + statusString + addedCostString;
				statusRiderText = " <Inflicts " + statusString + ">";
			}
		}
		public override void Recalculate(Monster monster)
		{
			AbstractAbility p = (AbstractAbility)this.GetParent();
			if (p.TargetType == TargetType.Group)
			{
				cosMod = baseCoSMod - 10;
			}
			else if (p.TargetType == TargetType.Row)
			{
				cosMod = baseCoSMod - 5;
			}
			else
			{
				cosMod = baseCoSMod;
			}
		}
	}
	[Serializable]
	public class Ranged : AbilityModifier
	{
		public Ranged()
		{
			slotCost = 2;
			rangedProperty = true;
			name = "Ranged";
		}
		public override bool Prepare(Monster m)
		{
			return base.Prepare(m);
		}
	}
	[Serializable]
	public class HighCoS : AbilityModifier
	{
		private int ranks;
		public HighCoS()
		{
			name = "High CoS";
		}
		public override bool Prepare(Monster m)
		{
			if (base.Prepare(m))
			{
				if (m.Rank.IsMinibossOrBoss())
				{
					//figure out how many ranks are being taken
					InputRanks d = new InputRanks();
					if (d.ShowDialog() == DialogResult.OK)
					{
						slotCost = d.NumberOfRanks();
						cosMod = 5 * d.NumberOfRanks();
						ranks = d.NumberOfRanks();
						name = "High CoS: +" + cosMod.ToString() + "%";
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					slotCost = 1;
					cosMod = 5;
					name = "+5 CoS";
					return true;
				}
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
		public override void Edit(Monster monster)
		{
			if (monster.Rank.IsMinibossOrBoss())
			{
				//figure out how many ranks are being taken
				InputRanks d = new InputRanks();
				d.SetRanks(ranks);
				if (d.ShowDialog() == DialogResult.OK)
				{
					slotCost = d.NumberOfRanks();
					cosMod = 5 * d.NumberOfRanks();
					ranks = d.NumberOfRanks();
					name = "High CoS: +" + cosMod.ToString() + "%";
				}
			}
			else
			{
				Complain(6);
			}
		}
	}
	[Serializable]
	public class LongerStatus : AbilityModifier
	{
		private int ranks;
		public LongerStatus()
		{
			name = "Longer Status";
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				if (m.Rank.IsMinibossOrBoss())
				{
					//figure out how many ranks are being taken
					InputRanks d = new InputRanks();
					if (d.ShowDialog() == DialogResult.OK)
					{
						ranks = d.NumberOfRanks();
						slotCost = d.NumberOfRanks();
						name = "Longer Status - Status Durations: +" + d.NumberOfRanks() + ", apply manually.";
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					slotCost = 1;
					name = "Longer Status - Status Durations +1, apply manually.";
					return true;
				}
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
		public override void Edit(Monster monster)
		{
			if (monster.Rank.IsMinibossOrBoss())
			{
				InputRanks d = new InputRanks();
				d.SetRanks(ranks);
				if (d.ShowDialog() == DialogResult.OK)
				{
					ranks = d.NumberOfRanks();
					slotCost = d.NumberOfRanks();
					name = "Longer Status - Status Durations: +" + d.NumberOfRanks() + ", apply manually.";
				}
			}
			else
			{
				Complain(6);
			}
		}
	}
	[Serializable]
	public class Countdown : AbilityModifier
	{
		public Countdown()
		{
			name = "Countdown";
			slotCost = 1;
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				InputRanks d = new InputRanks();
				if (d.ShowDialog() == DialogResult.OK)
				{
					AbstractAbility p = (AbstractAbility)this.GetParent();
					slotCost = d.NumberOfRanks();
					chargeTime = 20 + 5 * d.NumberOfRanks();
					powerMult = 1.5 + 0.5 * (d.NumberOfRanks() - 1);
					name += " - " + d.NumberOfRanks().ToString() + " ranks";
					if (p.TargetType == TargetType.All || p.TargetType == TargetType.Group)
					{
						chargeTime += 10;
					}
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			InputRanks d = new InputRanks();
			d.SetRanks(slotCost);
			if (d.ShowDialog() == DialogResult.OK)
			{
				AbstractAbility p = (AbstractAbility)this.GetParent();
				slotCost = d.NumberOfRanks();
				chargeTime = 20 + 5 * d.NumberOfRanks();
				powerMult = 1.5 + 0.5 * (d.NumberOfRanks() - 1);
				name = "Countdown - " + d.NumberOfRanks().ToString() + " ranks";
				if (p.TargetType == TargetType.All || p.TargetType == TargetType.Group)
				{
					chargeTime += 10;
				}
			}
		}
		public override void Recalculate(Monster monster)
		{
			AbstractAbility p = (AbstractAbility)this.GetParent();
			if (p.TargetType == TargetType.All || p.TargetType == TargetType.Group)
			{
				chargeTime = 30 + 5 * slotCost;
			}
			else
			{
				chargeTime = 20 + 5 * slotCost;
			}
		}
	}
	[Serializable]
	public class Tectonic : AbilityModifier
	{
		private bool stripsElement = false;
		public Tectonic()
		{
			slotCost = 1;
			name = "Tectonic";
			
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				if (m.Tier == 1)
				{
					slotCost += 2;
				}
				InputTectonicType dialog = new InputTectonicType();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (dialog.NonElemental())
					{
						name += " - Strips Element";
						slotCost += 1;
						stripsElement = true;
						InputAdditionalCost dialog2 = new InputAdditionalCost(5, 20);
						if (dialog2.ShowDialog() == DialogResult.OK)
						{
							if (dialog2.Result() == AdditionalCost.Delay)
							{
								name += " (Cost: +5D)";
								delayMod = 5;
							}
							else
							{
								name += " (Cost: +20 MP/Tier)";
								mpScale = 20;
							}
						}
					}
					if (dialog.Result() == TectonicResult.PowerMod)
					{
						name += " - Increased Power";
						powerMod = 3;
					}
					else
					{
						name += " - Delays struck targets by 10D";
					}
					return true;
				}
				else
				{
					return false;
				}
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
		public override void Edit(Monster monster)
		{
			if (monster.Tier == 1)
			{
				slotCost = 3;
			}
			else
			{
				slotCost = 1;
			}
			InputTectonicType dialog = new InputTectonicType();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				name = "Tectonic";
				if (dialog.NonElemental())
				{
					name += " - Strips Element";
					slotCost += 1;
					stripsElement = true;
					InputAdditionalCost dialog2 = new InputAdditionalCost(5, 20);
					if (dialog2.ShowDialog() == DialogResult.OK)
					{
						if (dialog2.Result() == AdditionalCost.Delay)
						{
							name += " (Cost: +5D)";
							delayMod = 5;
							mpScale = 0;
						}
						else
						{
							name += " (Cost: +20 MP/Tier)";
							delayMod = 0;
							mpScale = 20;
						}
					}
				}
				else
				{
					delayMod = 0;
					mpScale = 0;
					stripsElement = false;
				}
				if (dialog.Result() == TectonicResult.PowerMod)
				{
					name += " - Increased Power";
					powerMod = 3;
				}
				else
				{
					name += " - Delays struck targets by 10D";
					powerMod = 0;
				}
			}
		}
		public override void Recalculate(Monster monster)
		{
			int baseSlotCost = 1;
			if (monster.Tier == 1)
			{
				baseSlotCost += 2;
			}
			if (stripsElement)
			{
				baseSlotCost++;
			}
			slotCost = baseSlotCost;
		}
	}
	[Serializable]
	public class ClumsyStrength : AbilityModifier
	{
		public ClumsyStrength()
		{
			slotCost = 1;
			name = "Clumsy Strength";
			cosMod = -25;
			powerMod = 4;
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			if (base.Prepare(m))
			{
				InputAdditionalCost dialog = new InputAdditionalCost(5, 20);
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (dialog.Result() == AdditionalCost.Delay)
					{
						//delay cost chosen
						delayMod = 5;
						name += " (Cost: +5D)";
					}
					else
					{
						//MP Cost chosen
						mpScale = 20;
						name += " (Cost: +20 MP/Tier)";
					}
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		public override bool IsEditable()
		{
			return true;
		}
		public override void Edit(Monster monster)
		{
			InputAdditionalCost dialog = new InputAdditionalCost(5, 20);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.Result() == AdditionalCost.Delay)
				{
					//delay cost chosen
					delayMod = 5;
					mpScale = 0;
					name = "Clumsy Strength (Cost: +5D)";
				}
				else
				{
					//MP Cost chosen
					mpScale = 20;
					delayMod = 0;
					name = "Clumsy Strength (Cost: +20 MP/Tier)";
				}
			}
		}
	}
	[Serializable]
	public class DrainHealth : AbilityModifier
	{
		//FIXME this will need to be reevaluated if an attack is changed from
		//single target to group target

		public DrainHealth()
		{
			name = "Drain Health";
		}
		public override bool Prepare(Monster m)
		{
			if (base.Prepare(m))
			{
				int tmpSlotCost = 0;
				if (modifiedAbility.TargetType == TargetType.Single)
				{
					tmpSlotCost = 3;
				}
				else
				{
					tmpSlotCost = 7;
				}

				if (m.Tier < 4)
				{
					slotCost = tmpSlotCost + 2;
				}
				else
				{
					slotCost = tmpSlotCost;
				}
				if (this.GetParent() != m.BasicAttack)
				{
					InputAdditionalCost dialog = new InputAdditionalCost(5, 20);
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						if (dialog.Result() == AdditionalCost.Delay)
						{
							//delay cost chosen
							delayMod = 5;
							name += " (Cost: +5D)";
						}
						else
						{
							//MP Cost chosen
							mpScale = 20;
							name += " (Cost: +20 MP/Tier)";
						}
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					delayMod = 5;
					name += " (Cost: +5D)";
					return true;
				}
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
		public override void Edit(Monster monster)
		{
			InputAdditionalCost dialog = new InputAdditionalCost(5, 20);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.Result() == AdditionalCost.Delay)
				{
					//delay cost chosen
					delayMod = 5;
					mpScale = 0;
					name = "Drain Health (Cost: +5D)";
				}
				else
				{
					//MP Cost chosen
					mpScale = 20;
					delayMod = 0;
					name = "Drain Health (Cost: +20 MP/Tier)";
				}
			}
		}
		public override void Recalculate(Monster monster)
		{
			int baseCost = 3;
			if (monster.Tier < 4)
			{
				baseCost += 2;
			}
			if (modifiedAbility.TargetType != TargetType.Single)
			{
				baseCost += 4;
			}
			slotCost = baseCost;
		}
	}
	[Serializable]
	public class StatusLinked : AbilityModifier
	{
		public StatusLinked()
		{
			slotCost = 0;
			name = "Status Linked";
		}
		public override bool Prepare(Monster m)
		{
			if (this.GetParent() == m.BasicAttack)
			{
				Complain(4);
				return false;
			}
			InputStatus d = new InputStatus(false);
			if (d.ShowDialog() == DialogResult.OK)
			{
				String status = d.ChosenString();
				if (status == "Stone" || status == "Sleep" || status == "Stop")
				{
					if (!m.HasLinkedStatusBonus)
					{
						slotCost = -1;
						m.HasLinkedStatusBonus = true;
					}
				}
				name = "Linked to Status: " + d.ChosenString();
				return true;
			}
			else
			{
				return false;
			}
		}

	}
#endregion 

	[Serializable]
	public class ActionOther : AbstractAbility
	{
		protected String notes;

		private int weaponDelayMod;
		private int weaponFloorMod;
		private int weaponCoSMod;
		private int weaponPowMod;
		private int weaponPowModPerTier;
		private int weaponDice;
		private int weaponDicePerTier;
		private int weaponMPCost;
		private int weaponMPCostPerTier;
		private int weaponCTCost;
		private decimal weaponPowerMult;
		private TargetType weaponTargetType;

		public ActionOther()
		{
		}

		public override bool IsEditable()
		{
			return true;
		}

		public override void Edit(Monster monster)
		{
			InputOtherAction dialog = new InputOtherAction();
			dialog.SlotsRemaining = parent.SlotsRemaining;
			dialog.AbilityName = name;
			dialog.SlotCost = slotCost;
			dialog.Notes = notes;
			//populate dialog keywords, make sure if weapon keyword it shows correct boxes!
			dialog.Keywords = keywords;
			dialog.ActivateKeywords();
			dialog.AbilityType = abilityType;
			dialog.Element = baseElement;
			if (abilityType == AbilityType.Action)
			{
				if (this.keywords.Contains(Keyword.Weapon))
				{
					dialog.DelayMod = weaponDelayMod;
					dialog.FloorMod = weaponFloorMod;
					dialog.MP = weaponMPCost;
					dialog.MPPerTier = weaponMPCostPerTier;
					dialog.CT = weaponCTCost;
					dialog.CoSMod = weaponCoSMod;
					dialog.TargetType = weaponTargetType;
					dialog.DieMod = weaponDice;
					dialog.DieModPerTier = weaponDicePerTier;
					dialog.PowerMod = weaponPowMod;
					dialog.PowerModPerTier = weaponPowModPerTier;
					dialog.PowerMultiplier = weaponPowerMult;
				}
				else
				{
					dialog.Delay = baseDelay;
					dialog.Floor = baseFloor;
					dialog.MP = mp;
					dialog.MPPerTier = mpPerTierAfterOne;
					dialog.CT = chargeTime;
					dialog.CoS = baseCos;
					dialog.TargetType = target;
					dialog.DieType = dieType;
					dialog.AttackType = type;
					dialog.Dice = dice;
					dialog.DicePerTier = diePerTierAfterOne;
					dialog.BasePower = basePower;
					dialog.PowerPerTier = powerPerTierAfterOne;
				}
			}
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				int slotCostDifference = dialog.SlotCost - slotCost;
				if (slotCostDifference <= parent.SlotsRemaining)
				{
					//update keywords list based on dialog results
					slotCost = dialog.SlotCost;
					name = "[" + dialog.AbilityName + "]";
					notes = dialog.Notes;
					abilityType = dialog.AbilityType;
					baseElement = dialog.Element;
					if (abilityType == AbilityType.Action)
					{
						if (this.keywords.Contains(Keyword.Weapon))
						{
							weaponTargetType = dialog.TargetType;
							weaponDelayMod = dialog.Delay;
							weaponCoSMod = dialog.CoS;
							weaponFloorMod = dialog.Floor;
							weaponCTCost = dialog.CT;
							weaponDice = dialog.DieMod;
							weaponDicePerTier = dialog.DieModPerTier;
							weaponMPCost = dialog.MP;
							weaponMPCostPerTier = dialog.MPPerTier;
							weaponPowerMult = dialog.PowerMultiplier;
							weaponPowMod = dialog.PowerMod;
							weaponPowModPerTier = dialog.PowerModPerTier;
						}
						else
						{
							baseDelay = dialog.Delay;
							baseFloor = dialog.Floor;
							mp = dialog.MP;
							mpPerTierAfterOne = dialog.MPPerTier;
							chargeTime = dialog.CT;
							baseCos = dialog.CoS;
							basePower = dialog.BasePower;
							powerPerTierAfterOne = dialog.PowerPerTier;
							dice = dialog.Dice;
							diePerTierAfterOne = dialog.DicePerTier;
							dieType = dialog.DieType;
							target = dialog.TargetType;
							type = dialog.AttackType;
						}
					}
					else
					{
						//reaction or support are treated identically at this point
						target = TargetType.Null;
						type = AttackType.Null;
					}
				}
				else
				{
					Complain(5);
				}
			}
		}
		public override bool Prepare(Monster m)
		{
			parent = m;
			InputOtherAction dialog = new InputOtherAction();
			dialog.ActivateKeywords();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				keywords = dialog.Keywords;
				abilityType = dialog.AbilityType;

				name = "[" + dialog.AbilityName + "]";
				slotCost = dialog.SlotCost;
				notes = dialog.Notes;

				//if it's an action
				if (abilityType == AbilityType.Action)
				{
					if (keywords.Contains(Keyword.Weapon))
					{
						//handle this shit differently!!!
						weaponDelayMod = dialog.DelayMod;
						weaponFloorMod = dialog.FloorMod;
						weaponCoSMod = dialog.CoSMod;
						weaponPowMod = dialog.PowerMod;
						weaponPowModPerTier = dialog.PowerModPerTier;
						weaponDice = dialog.DieMod;
						weaponDicePerTier = dialog.DieModPerTier;
						weaponPowerMult = dialog.PowerMultiplier;
						weaponTargetType = dialog.TargetType;
						weaponMPCost = dialog.MP;
						weaponMPCostPerTier = dialog.MPPerTier;
						weaponCTCost = dialog.CT;
						if (weaponTargetType == TargetType.Null)
						{
							weaponTargetType = TargetType.Single;
						}
						type = AttackType.Physical;
					}
					else
					{
						type = dialog.AttackType;
						//it's a Aimed or Magic or some shit
						baseDelay = dialog.Delay;
						target = dialog.TargetType;
						baseCos = dialog.CoS;
						baseFloor = dialog.Floor;
						mp = dialog.MP;
						mpPerTierAfterOne = dialog.MPPerTier;
						chargeTime = dialog.CT;
						if (type == AttackType.Physical || type == AttackType.Magical )
						{
							basePower = dialog.BasePower;
							powerPerTierAfterOne = dialog.PowerPerTier;
							dice = dialog.Dice;
							diePerTierAfterOne = dialog.DicePerTier;
							dieType = dialog.DieType;
							baseElement = dialog.Element;
						}
					}
				}
				else if (abilityType == AbilityType.Support)
				{
					type = AttackType.Null;
					target = TargetType.Null;
					//don't need to do anything else here!
				}
				else if (abilityType == AbilityType.Reaction)
				{
					type = AttackType.Null;
					target = TargetType.Null;
				}
				else
				{
					//wtf?
				}
				return true;
			}
			else
			{
				return false;
			}
		}
		public override string Description()
		{
			int delayMod = 0;
			int powerMod = 0;
			double powerMult = 1;
			int floorMod = 0;
			int chargeTimeMod = 0;
			int cosMod = 0;
			int mpCostMod = this.MPCost;

			if (this.keywords.Contains(Keyword.Weapon))
			{
				BasicAttack basic = parent.BasicAttack;
				basic.ApplyModifiers();
				baseDelay = basic.ModifiedDelay + weaponDelayMod;
				baseFloor = basic.ModifiedFloor + weaponFloorMod;
				baseCos = basic.CoS + weaponCoSMod;
				basePower = basic.ModifiedPower + weaponPowMod;
				powerPerTierAfterOne = basic.PowerPerTierAfterOne + weaponPowModPerTier;
				powerPerTier = basic.PowerPerTier;
				dice = basic.Dice + weaponDice;
				dieType = basic.DieType;
				diePerTierAfterOne = basic.DicePerTierAfterOne + weaponDicePerTier;
				target = weaponTargetType;
				powerMult *= (double)weaponPowerMult;
				mpCostMod += weaponMPCost + weaponMPCostPerTier * (parent.Tier - 1);
				chargeTimeMod += weaponCTCost;
			}

			if (this.HasModifiers())
			{
				foreach (AbilityModifier m in modifiers)
				{
					delayMod += m.DelayMod;
					powerMod += m.PowerMod(parent.Tier);
					powerMult *= m.PowerMult;
					floorMod += m.FloorMod;
					chargeTimeMod += m.ChargeTime;
					cosMod += m.CoSMod;
					mpCostMod += m.MPCost(parent.Tier);
				}
			}

			int delay = (baseDelay + parent.DelayMod + delayMod) - parent.SPD;
			int floor = baseFloor + parent.FloorMod + floorMod;
			int cos = baseCos + cosMod;

			if (floor < 10)
			{
				floor = 10;
			}

			powerMult *= parent.PowerMult;

			if (delay < floor)
			{
				delay = floor;
			}

			int totalChargeTime = chargeTime + chargeTimeMod;

			String returnString = name + " -";

			if (this.AttackType != AttackType.Null)
			{

				if (cos > 0)
				{
					returnString += " CoS:" + cos + " ";
				}

				if (delay > 0)
				{
					returnString += delay + "D ";
				}

				if (mpCostMod > 0)
				{
					returnString += mpCostMod + " MP ";
				}

				if (totalChargeTime > 0)
				{
					returnString += "CT " + totalChargeTime + " ";
				}
			}

			if (this.AttackType == AttackType.Physical || this.AttackType == AttackType.Magical)
			{
				int power = basePower + parent.Tier * powerPerTier + (parent.Tier - 1) * powerPerTierAfterOne + powerMod;
				power *= LookupStat(parent, type);
				if (powerMult != 0)
				{
					double powerCalc = (double)power;
					powerCalc *= powerMult;
					power = (int)Math.Floor(powerCalc);
				}

				returnString += dice + diePerTierAfterOne * (parent.Tier - 1) + dieType.ToString() + " + " + power + " ";
			}

			if (this.AttackType == AttackType.Physical || this.AttackType == AttackType.Magical)
			{
				returnString += this.AttackType.ToString() + " ";
			}
			else 
			{
				if (this.AttackType == AttackType.PhysicalEffect)
				{
					returnString += " Physical ";
				}
				if (this.AttackType == AttackType.MagicalEffect)
				{
					returnString += " Magical ";
				}
			}

			returnString += this.TargetTypeDisplay(this.TargetType) + " ";

			if (this.AttackType != AttackType.Null)
			{
				if (this.Element != Element.Null)
				{
					returnString += this.Element.ToString();
				}
			}

			return returnString + " " + notes;
		}
	}
}

#endregion