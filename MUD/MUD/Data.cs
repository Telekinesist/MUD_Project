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
	}
}
