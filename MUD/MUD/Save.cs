
using System.Xml;
using System.IO;

namespace MUD
{
	/**
	 * Handles savedata and stored settigns
	 */
	public static class Save
	{
		//Loads saved data
		//Set reset to 1 to load default values
		public static void load(bool reset = false)
		{
			
			if (reset)
			{
				C.t("DIY you dumbnut");
				//The world refuses to change after reset.
			/*	PlayerCostomization.CreatePlayer();

				Data.createWorld();
				Player.room = 1;
				C.t("Restat will now commence", 500);
				Program.input = "exit";*/
			}
			else
			{
				string[] data = new string[13];
				byte index = 0;
				XmlDocument x = new XmlDocument();

				x.Load(@"..\GameData.xml");
				data[index] = (x.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["val"].Value);
				index++;
				data[index] = (x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[0].Attributes["val"].Value);
				index++;

				foreach (XmlAttribute cont in x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes)
				{
					data[index] = cont.Value;
					index++;
				}
				foreach (XmlAttribute cont in x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes)
				{
					data[index] = cont.Value;
					index++;
				}
				foreach (XmlAttribute cont in x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[3].Attributes)
				{
					data[index] = cont.Value;
					index++;
				}
				setValues(data);

				Data.world = loadWorld();
			}
		}

		//Serializes the Map object, and stores it as a file, world.dat
		public static void saveWorld(Map world)
		{
			using (Stream stream = File.Open(@"..\world.dat", false ? FileMode.Append : FileMode.Create))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(stream, world);
			}
		}

		//Loads the Map object from world.dat and de-serializes it
		public static Map loadWorld()
		{
			using (Stream stream = File.Open(@"..\world.dat", FileMode.Open))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				return (Map)binaryFormatter.Deserialize(stream);
			}
		}

		public static void save()
		{
			string[] data = new string[9];
			XmlDocument x = new XmlDocument();
			x.Load(@"..\GameData.xml");
			//First child is <savegame>. That have the children <location/> and <player>. Player have <HP/>, <amor/>, <weapon/> and <personal/>
			x.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["val"].Value = Player.room.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[0].Attributes["val"].Value = Player.HP.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes["desc"].Value = Player.armor;
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes["damRes"].Value = Player.damageResistance.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[1].Attributes["damRed"].Value = Player.damageReduction.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["desc"].Value = Player.weapon;
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["wieldAb"].Value = Player.weildability.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["damage"].Value = Player.damage.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[2].Attributes["inconsis"].Value = Player.inconsitency.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[3].Attributes["name"].Value = Player.name;
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[3].Attributes["age"].Value = Player.age.ToString();
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[3].Attributes["sex"].Value = Player.sex;
			x.DocumentElement.ChildNodes[0].ChildNodes[1].ChildNodes[3].Attributes["race"].Value = Player.race;


			x.Save(@"..\GameData.xml");

			saveWorld(Data.world);
		}

		public static void printSave(string[] data)
		{
			foreach(string val in data)
			{
				C.d(val);
			}
		}

		public static void setValues(string[] d)
		{
			Player.room = int.Parse(d[0]);
			Player.HP = int.Parse(d[1]);
			Player.armor = d[2];
			Player.damageResistance = int.Parse(d[3]);
			Player.damageReduction = int.Parse(d[4]);
			Player.weapon = d[5];
			Player.weildability = int.Parse(d[6]);
			Player.damage = int.Parse(d[7]);
			Player.inconsitency = float.Parse(d[8]);
			Player.name = d[9];
			Player.age = float.Parse(d[10]);
			Player.sex = d[11];
			Player.race = d[12];
		}
	}
}
