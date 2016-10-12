using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace MUD
{
	/**
	 * Contains all data and other information that have to be listed somewhere
	 */
	static class Data
	{
		public static Map world = new Map();
		public static Room getRoom(int id)
		{
			return world.Rooms[id];
		}
		public static Room room()
		{
			return world.Rooms[Player.room];
		}

		public static DiffWeapons weapons = new DiffWeapons();
		public static List<Chest> chests = new List<Chest>();
		public static List<Monster> monsters = new List<Monster>();

		public static SoundPlayer door = new SoundPlayer(@"..\Door.aiff");
		public static SoundPlayer mon = new SoundPlayer(@"..\Monsters.wav");



		//Command lists
		public static List<string> showInv = new List<string>();
		public static List<string> move = new List<string>();
		public static List<string> attack = new List<string>();
		public static List<string> dodge = new List<string>();
		public static List<string> think = new List<string>();

		public static void addCommands()
		{
			showInv.Add("inv");
			showInv.Add("inventory");
			showInv.Add("stat");

			move.Add("go");
			move.Add("move");
			move.Add("travel");
			move.Add("traverse");

			attack.Add("attack");
			attack.Add("fight");
			attack.Add("hit");
			attack.Add("kill");
			attack.Add("slay");

			dodge.Add("dodge");
			dodge.Add("defend");
			dodge.Add("shield");

			think.Add("think");
			think.Add("meditate");
			

			Interface.directions.Add("north");
			Interface.directions.Add("ssouth");
			Interface.directions.Add("east");
			Interface.directions.Add("west");
			Interface.directions.Add("up");
			Interface.directions.Add("down");
			Interface.directions.Add("right");
			Interface.directions.Add("left");
			Interface.directions.Add("n");
			Interface.directions.Add("s");
			Interface.directions.Add("e");
			Interface.directions.Add("w");
			Interface.directions.Add("u");
			Interface.directions.Add("d");
			Interface.directions.Add("r");
			Interface.directions.Add("l");
		}

		public static void addData()
		{
			chests.Add(new Chest(50, weapons.GetRandomWeapon()));
			chests.Add(new Chest(0, weapons.GetRandomWeapon()));
			chests.Add(new Chest(700, null));
			
			monsters.Add(new Monster(1, "Rat", 10, 2));

			
		}

		public static void createWorld()
		{
			//Creates test world
			Data.world.addRoom(1, null, null, "You stand in a dark room with two doors. What will you do?");
			Data.world.addRoom(2, chests[0], null, "Another dark room.");
			Data.world.addRoom(3, chests[2], monsters[0], "This room is bright");
			Data.world.addRoom(4, null, monsters[0], "There is only the door you came in through. This looks like a trap!");
			Data.getRoom(1).addEdge("north", new Edge(Data.getRoom(2)));
			Data.getRoom(2).addEdge("south", new Edge(Data.getRoom(1)));
			Data.getRoom(3).addEdge("west", new Edge(Data.getRoom(2)));
			Data.getRoom(1).addEdge("east", new Edge(Data.getRoom(3)));
			Data.getRoom(2).addEdge("north", new Edge(Data.getRoom(4)));
			Data.getRoom(4).addEdge("south", new Edge(Data.getRoom(2)));
		}
	}
}
