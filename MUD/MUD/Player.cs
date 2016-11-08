using System;

namespace MUD
{
	/**
	 * Player class contains information about the player
	 * Also contains methods direcly invorlving the player
	 */
	 [Serializable]
	public static class Player
	{
		public static int room = 0; //Spawn
		public static int HP = 100;

		public static string armor = "shirt";
		public static float damageResistance = 0;
		public static int damageReduction = 0;

		public static string weapon = "fists";
		public static float weildability = 1;
		public static int damage = 2;
		public static float inconsitency = 0.2f;
        public static string name = "default";
        public static float age = 0f;
        public static string sex = "default";
        public static string race = "default";


        public static void createPlayer(string nam, float ag, string sex1, string race1, int Dmg, int Hp)
        {
            name = nam;
            age = ag;
            sex = sex1;
            race = race1;
            damage = Dmg;
            HP = Hp;

        }


        public static void getStats()
		{
			C.t("\t    -INVENTORY-");
			C.l(sex + " " + race, name + ", " + age + " years old");
			C.l("- Room", room.ToString());
			C.l("- Health points", HP.ToString());
			C.l("- Armor", armor);
			C.l("- Defence", damageResistance.ToString() + "% + " + damageReduction.ToString());
			C.l("- Weapon", weapon);
			C.l("- Damage", damage + " and " + weildability + " wieldability ");
		}
		
		public static void move(string input)
		{
			bool fail = true;
			foreach (Edge edge in Data.room().edges)
			{
				if (input.Contains(edge.tag))
				{
					room = edge.link.id;
					BM.play("go");
					fail = false;
					break;
				}
			}
			if (fail)
			{
				C.t("You can't go that way.");
			}

		}
	}
}
