using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elena
{
	[Serializable]
	public class Monster
	{
		private String name;
		private int level = 1;
		private int tier = 1;

		private int hpModBase = 0;
		private int mpModBase = 0;
		private int xpModBase = 0;
		private int jpBase = 1;
		private int attrMaxBase = 0;
		private int attrTotalBase = 0;
		private int baseSlots = 0;
		private int hpMultiplier = 1;

		private int hpMax;
		private int mpMax;

		private int hpMod;
		private int mpMod;
		private int attrMax;
		private int attrTotal;
		private int xp;
		private int jp;
		private int xpMod;
		private int jpMod;
		private int slots;
		private int slotsUsed = 0;

		private int atkBase = 5;
		private int vitBase = 5;
		private int spdBase = 5;
		private int magBase = 5;
		private int sprBase = 5;

		private int atk = 5;
		private int vit = 5;
		private int spd = 5;
		private int mag = 5;
		private int spr = 5;

		private int armour;
		private int m_armour;
		private int evasion;
		private int m_evasion;
		private int accuracy;

		private String description;
		private String item;
		private String drop;
		private String equip;

		private bool equipMultiplier = true;

		private int delayMod = 0;
		private int floorMod = 0;
		private double powerMult = 1;

		private bool hasLinkedStatusBonus = false;

		private BasicAttack basicAttack;
		private List<MonsterProperty> properties = new List<MonsterProperty>();
		private List<MonsterAbility> abilities = new List<MonsterAbility>();
		private MonsterProperty difficulty = new DiffNormal();
		private MonsterProperty rank = new RankUnranked();
		private Dictionary<Element, ElementMod> elementalProperties = new Dictionary<Element, ElementMod>();
		private Element primaryElement = Element.Null;

		public Monster()
		{
			//do anything that needs to be done to initialise the monster
			basicAttack = new NullAttack();
			basicAttack.Prepare(this);
		}
		public String Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public int Level 
		{
			get
			{
				return level;
			}

			set
			{
				level = value;
				tier = (int)Math.Floor((double)((level - 1) / 10)) + 1;
			}
		}
		public int Tier
		{
			get
			{
				return tier;
			}
		}
		public int ATK
		{
			get
			{
				return atk;
			}
			set
			{
				atkBase = value;
			}
		}
		public int VIT
		{
			get
			{
				return vit;
			}
			set
			{
				vitBase = value;
			}
		}
		public int SPD
		{
			get
			{
				return spd;
			}
			set
			{
				spdBase = value;
			}
		}
		public int MAG
		{
			get
			{
				return mag;
			}
			set
			{
				magBase = value;
			}
		}
		public int SPR
		{
			get
			{
				return spr;
			}
			set
			{
				sprBase = value;
			}
		}
		public int HP
		{
			get
			{
				return hpMax;
			}
		}
		public int MP
		{
			get
			{
				return mpMax;
			}
		}
		public int PointsRemaining
		{
			get
			{
				return attrTotal - (atkBase + vitBase + spdBase + magBase + sprBase);
			}
		}
		public bool EquipMultiplier
		{
			get
			{
				return equipMultiplier;
			}
			set
			{
				equipMultiplier = value;
			}
		}
		public int AttributeMax
		{
			get
			{
				return attrMax;
			}
			set
			{
				attrMax = value;
			}
		}
		public int AttributeTotal
		{
			get
			{
				return attrTotal;
			}
			set
			{
				attrTotal = value;
			}
		}
		public int XPReward
		{
			get
			{
				return xp;
			}
		}
		public int GilReward
		{
			get
			{
				if (equipMultiplier)
				{
					return (int)Math.Floor(xp / 5.0);
				}
				else
				{
					return (int)Math.Floor(xp / 5.0) / 10;
				}
			}
		}
		public int JPReward
		{
			get
			{
				return jp;
			}
		}
		public int HPMultiplier
		{
			get
			{
				return hpMultiplier;
			}
			set
			{
				hpMultiplier = value;
			}
		}
		public int ARM
		{
			get
			{
				return armour;
			}
			set
			{
				armour = value;
			}
		}
		public int MARM
		{
			get
			{
				return m_armour;
			}
			set
			{
				m_armour = value;
			}
		}
		public int EVA
		{
			get
			{
				return evasion;
			}
			set
			{
				evasion = value;
			}
		}
		public int MEVA
		{
			get
			{
				return m_evasion;
			}
			set
			{
				m_evasion = value;
			}
		}
		public int ACC
		{
			get
			{
				return accuracy;
			}
			set
			{
				accuracy = value;
			}
		}
		public int HPMod
		{
			get
			{
				return hpMod;
			}
			set
			{
				hpMod = value;
			}
		}
		public int MPMod
		{
			get
			{
				return mpMod;
			}
			set
			{
				mpMod = value;
			}
		}
		public int XPMod
		{
			get
			{
				return xpMod;
			}
			set
			{
				xpMod = value;
			}
		}
		public int JPMod
		{
			get
			{
				return jpMod;
			}
			set
			{
				jpMod = value;
			}
		}
		public int Slots
		{
			get
			{
				return slots;
			}
			set
			{
				slots = value;
			}
		}
		public MonsterProperty Difficulty
		{
			get
			{
				return difficulty;
			}
			set
			{
				difficulty = value;
			}
		}
		public int SlotsRemaining
		{
			get
			{
				return slots - slotsUsed;
			}
		}
		public int SlotsUsed
		{
			get
			{
				return slotsUsed;
			}
		}
		public MonsterProperty Rank
		{
			get
			{
				return rank;
			}
			set 
			{
				rank = value;
			}
		}
		public bool HasLinkedStatusBonus
		{
			get
			{
				return hasLinkedStatusBonus;
			}
			set
			{
				hasLinkedStatusBonus = value;
			} 
		}
		public List<MonsterAbility> Abilities
		{
			get
			{
				return abilities;
			}
		}
		public void AddProperty(MonsterProperty p)
		{
			bool validToAdd = true;
			//validate the property to make sure we're not adding
			//a second instance of a unique property.
			if (p.Unique())
			{
				Type pType = p.GetType();
				Type compareType;
				//make sure we don't already have an instance of p
				foreach (MonsterProperty compare in properties)
				{
					compareType = compare.GetType();
					if (compareType == pType)
					{
						p.Complain(3);
						validToAdd = false;
					}
				}
			}
			if (validToAdd)
			{
				if (p.Prepare(this))
				{
					if (slotsUsed + p.SlotCost() > slots)
					{
						p.Complain(4);
					}
					else
					{
						properties.Add(p);
						properties.Sort();
					}
				}
			}
		}
		public void AddAbility(MonsterAbility ability, MonsterAbility parent)
		{
			bool validToAdd = true;
			if (validToAdd)
			{
				//catch case wherein a modifier is selected
				if (parent.IsBaseAbility() && !ability.IsBaseAbility())
				{
					ability.SetupParent(parent);
					if (ability.Prepare(this))
					{
						if (slotsUsed + ability.SlotCost() > slots)
						{
							ability.Complain(1);
						}
						else
						{
							parent.AddModifier((AbilityModifier)ability);
						}
					}
				}
				else
				{
					AddAbility(ability);
				}
			}
		}
		public void AddAbility(MonsterAbility ability)
		{
			if (ability.Prepare(this))
			{
				if (slotsUsed + ability.SlotCost() > slots)
				{
					ability.Complain(1);
				}
				else
				{
					//if it's an actual ability, it'll be inserted as a root node
					//otherwise, it'll be inserted as a child node of whatever 
					//ability it's modifying
					if (ability.IsBaseAbility())
					{
						abilities.Add(ability);
					}
					else
					{
						MonsterAbility parent = ability.GetParent();
						parent.AddModifier((AbilityModifier)ability);
					}
				}
			}
		}
		public void RemoveProperty(MonsterProperty p)
		{
			properties.Remove(p);
		}
		public void RemoveModifier(AbilityModifier m)
		{
			m.GetParent().RemoveModifier(m);
		}
		internal void ApplyProperties()
		{
			this.ResetProperties();

			//apply properties
			difficulty.ApplyProperty(this);
			rank.ApplyProperty(this);
			foreach (MonsterProperty property in properties)
			{
				property.Recalculate(this);
				property.ApplyProperty(this);
				slotsUsed += property.SlotCost();
			}

			slotsUsed += basicAttack.SlotCost();

			basicAttack.Recalculate(this);
			foreach (AbstractAbility ability in abilities)
			{
				ability.Recalculate(this);
				slotsUsed += ability.SlotCost();
			}

			//then, calculate derived stats once the properties have been applied.
			//hpMax = 100 + (((vit * 4) + 8) * hpMod * level);
			hpMax = 200 * tier + vit * 2 * level * hpMod;
			hpMax *= hpMultiplier;
			//mpMax = 50 + (spr * mpMod * level);
			mpMax = 200 * tier + spr * 2 * level * mpMod;

			xp = xpMod * level;
			jp = jpMod * jpBase;
		}
		private void ResetProperties()
		{
			attrMax = attrMaxBase;
			xpMod = xpModBase;
			hpMod = hpModBase;
			mpMod = mpModBase;
			attrTotal = attrTotalBase;
			spr = sprBase;
			mag = magBase;
			spd = spdBase;
			vit = vitBase;
			atk = atkBase;
			slots = baseSlots;
			slotsUsed = 0;
			armour = 0;
			m_armour = 0;
			evasion = 0;
			m_evasion = 0;
			accuracy = 0;
			delayMod = 0;
			floorMod = 0;
			powerMult = 1;

			elementalProperties.Clear();
			primaryElement = Element.Null;
		}
		public IEnumerable<MonsterProperty> Properties
		{
			get
			{
				return properties.AsEnumerable<MonsterProperty>();
			}
		}
		public Dictionary<Element, ElementMod> ElementalProperties
		{
			get
			{
				return elementalProperties;
			}
			set
			{
				elementalProperties = value;
			}
		}
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}
		public string Drop
		{
			get
			{
				return drop;
			}
			set
			{
				drop = value;
			}
		}
		public string Equip
		{
			get
			{
				return equip;
			}
			set
			{
				equip = value;
			}
		}
		public string Item
		{
			get
			{
				return item;
			}
			set
			{
				item = value;
			}
		}
		public int DelayMod
		{
			get
			{
				return delayMod;
			}
			set
			{
				delayMod = value;
			}
		}
		public int FloorMod
		{
			get
			{
				return floorMod;
			}
			set
			{
				floorMod = value;
			}
		}

		public double PowerMult
		{
			get
			{
				return powerMult;
			}
			set
			{
				powerMult = value;
			}
		}

		public Element PrimaryElement
		{
			get
			{
				return primaryElement;
			}
			set
			{
				primaryElement = value;
			}
		}

		public BasicAttack BasicAttack 
		{
			get
			{
				return basicAttack;
			}
			set
			{
				basicAttack = value;
			}
		}
	}
}
