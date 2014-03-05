using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Elena
{
	public static class GrimoireHandler
	{
		private static List<GrimoireAbility> grimoire = new List<GrimoireAbility>();

		static GrimoireHandler()
		{
			//first, check for compiled grimoire file
			if (File.Exists("grimoire.cgm"))
			{
				FileInfo grimoireLoad = new FileInfo("grimoire.cgm");
				BinaryFormatter b = new BinaryFormatter();
				Stream s = grimoireLoad.OpenRead();
				grimoire = (List<GrimoireAbility>)b.Deserialize(s);
				s.Close();
			}
			else if (File.Exists("grimoire.csv"))
			{
				//compiled grimoire does not exist, recompile!
				FileHelperAsyncEngine<GrimoireLine> reader = new FileHelperAsyncEngine<GrimoireLine>();
				reader.BeginReadFile("grimoire.csv");
				foreach (GrimoireLine line in reader)
				{
					if (line.AllowInMCS)
					{
						grimoire.Add(new GrimoireAbility(line));
					}
				}
				reader.Close();
				//compile the grimoire to grimoire.cgm
				FileInfo compileTarget = new FileInfo("grimoire.cgm");
				BinaryFormatter b = new BinaryFormatter();
				Stream s = compileTarget.Open(FileMode.Create, FileAccess.Write);
				b.Serialize(s, grimoire);
				s.Close();
			}
			else
			{
				MessageBox.Show("No grimoire.csv or grimoire.cgm detected. Unable to load in predefined character abilities. Please check the MCS Helper page for the most recent version of the grimoire.", "Can't find grimoire!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		public static List<String> AbilityList(String system, String job)
		{
			List<String> ret = new List<String>();
			var query = from ability in grimoire where ability.System == system && ability.Job == job select ability;
			foreach (GrimoireAbility ability in query)
			{
				ret.Add(ability.Name + " (" + ability.SlotCost + ")");
			}
			return ret;
		}

		public static GrimoireAbility Ability(String system, String job, String name)
		{
			var query = from ability in grimoire where ability.System == system && ability.Job == job && ability.Name == name select ability;
			return query.First();
		}

		public static bool AllowLoad(String system, String job, String name)
		{
			var query = from ability in grimoire where ability.System == system && ability.Job == job && ability.Name == name select ability;
			if (query.Count<GrimoireAbility>() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	[Serializable]
	public class GrimoireAbility
	{
		public String System;
		public String Job;
		public String Name;
		public int SlotCost;
		public AbilityType AbilityType;
		public int Delay;
		public int Floor;
		public int MP;
		public int MPPerTier;
		public int CT;
		public int CoS;
		public TargetType Target;
		public AttackType AttackType;
		public int Power;
		public int PowerPerTier;
		public int Dice;
		public int DicePerTier;
		public DieType DieType;
		public decimal Multiplier;
		public String Notes;
		public List<Keyword> Keywords = new List<Keyword>();
		public Element Element;

		public GrimoireAbility(GrimoireLine line)
		{
			this.System = line.System;
			this.Job = line.Job;
			this.Name = line.Name;
			switch (this.System)
			{
				case "Class":
					//too complicated
					this.SlotCost = ResolveClassSlotCosts(line.Job, line.APOrSlotCost, line.Keywords);
					break;
				case "Job":
					if (line.APOrSlotCost <= 100)
					{
						this.SlotCost = 2;
					}
					else if (line.APOrSlotCost < 150)
					{
						this.SlotCost = 3;
					}
					else
					{
						//150 or more AP
						this.SlotCost = 4;
					}
					break;
				case "Crystal":
					if (line.APOrSlotCost < 4)
					{
						this.SlotCost = 2;
					}
					else if (line.APOrSlotCost == 4)
					{
						this.SlotCost = 3;
					}
					else
					{
						//5 or more slots
						this.SlotCost = 4;
					}
					break;
			}
			try
			{
				this.AbilityType = (AbilityType)Enum.Parse(typeof(AbilityType), line.Type);
			}
			catch
			{
				this.AbilityType = AbilityType.Support;
			}
			this.Delay = line.Delay;
			this.Floor = line.Floor;
			this.MP = line.MP;
			this.MPPerTier = line.MPPerTier;
			this.CT = line.CT;
			this.CoS = line.CoS;
			try
			{
				this.Target = (TargetType)Enum.Parse(typeof(TargetType), line.Target);
			}
			catch
			{
				this.Target = TargetType.Null;
			}
			this.AttackType = AttackType.Null;
			if (line.Stat == "ATK") this.AttackType = AttackType.Physical;
			if (line.Stat == "MAG") this.AttackType = AttackType.Magical;
			if (this.AttackType == AttackType.Null)
			{
				if (line.Keywords.Contains("Magic"))
				{
					this.AttackType = AttackType.MagicalEffect;
				}
				else if(line.Keywords.Contains("Technique"))
				{
					this.AttackType = AttackType.PhysicalEffect;
				}
			}
			this.Power = line.Power;
			this.PowerPerTier = line.PowerPerTier;
			this.Dice = line.Dice;
			this.DicePerTier = line.DicePerTier;
			string buildDieType = "d" + line.DieType.ToString();
			try
			{
				this.DieType = (DieType)Enum.Parse(typeof(DieType), buildDieType);
			}
			catch
			{
				this.DieType = DieType.Null;
			}
			this.Multiplier = line.Multiplier;
			this.Notes = line.Notes;
			List<String> keywordsBroken = line.Keywords.Split(',').ToList<String>();
			Regex rgx = new Regex("[^a-zA-Z:]");
			this.Element = Element.Null;
			foreach (String key in keywordsBroken)
			{
				//do preprocessing to mung Elemental, Status, and Effect keywords
				String toAdd = rgx.Replace(key, "");
				if (key.Contains("Elemental"))
				{
					//split at colon, element will be in split[1]
					string[] parts = key.Split(':');
					toAdd = "Elemental";
					try
					{
						this.Element = (Element)Enum.Parse(typeof(Element), parts[1]);
					}
					catch
					{
						this.Element = Element.Null;
					}
				}
				if (key.Contains("Status") || key.Contains("Effect"))
				{
					toAdd = "StatusEffect";
				}
				if (key.Contains("Enhancement"))
				{
					toAdd = "Enhancement";
				}
				try
				{
					this.Keywords.Add((Keyword)Enum.Parse(typeof(Keyword), toAdd));
				}
				catch
				{
					//couldn't recognise the keyword, do nothing.
					Console.WriteLine("Could not recognise keyword " + toAdd);
				}
			}
		}

		private int ResolveClassSlotCosts(string job, int ap, string keywords)
		{
			return 2;
		}
	}

	[DelimitedRecord(",")]
	[IgnoreFirst()]
	public class GrimoireLine
	{
		public String System;
		public String Job;
		public String Name;
		[FieldNullValue(0)]
		public int APOrSlotCost;
		[FieldNullValue("")]
		public String Type;
		[FieldNullValue(0)]
		public int Delay;
		[FieldNullValue(0)]
		public int Floor;
		[FieldNullValue(0)]
		public int MP;
		[FieldNullValue(0)]
		public int MPPerTier;
		[FieldNullValue(0)]
		public int CT;
		[FieldNullValue(0)]
		public int CoS;
		[FieldNullValue("")]
		public String Target;
		[FieldNullValue("")]
		public String Stat;
		[FieldNullValue(0)]
		public int Power;
		[FieldNullValue(0)]
		public int PowerPerTier;
		[FieldNullValue(0)]
		public int Dice;
		[FieldNullValue(0)]
		public int DicePerTier;
		[FieldNullValue(0)]
		public int DieType;
		[FieldNullValue(false)]
		public bool AllowInMCS;
		[FieldNullValue(typeof(decimal),"1.000")]
		public decimal Multiplier;
		[FieldNullValue("")]
		[FieldQuoted()]
		public String Notes;
		[FieldNullValue("")]
		[FieldQuoted()]
		public String Keywords;
	}
}
