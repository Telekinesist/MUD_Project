using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class Data
	{
		public static Map world = new Map();
		public static Room getRoom(int id)
		{
			return world.Rooms[id];
		}


		//Command lists
		public static List<string> showInv = new List<string>();
		public static List<string> move = new List<string>();

		public static void addCommands()
		{
			showInv.Add("inv");
			showInv.Add("inventory");
			showInv.Add("stats");

			move.Add("go");
			move.Add("move");
			move.Add("travel");
			move.Add("traverse");

			Interface.directions.Add("n");
			Interface.directions.Add("s");
			Interface.directions.Add("e");
			Interface.directions.Add("w");
			Interface.directions.Add("u");
			Interface.directions.Add("d");
			Interface.directions.Add("r");
			Interface.directions.Add("l");
		}
	}
}
