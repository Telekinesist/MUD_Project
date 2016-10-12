using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MUD
{
	/**
	 * Contans the world
	 */
	 [Serializable]
	public class Map
	{
		//A dictionary is used for fast access to the rooms
		public Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
		int numOfRooms = 0;

		public Map()
		{

		}

		public void addRoom(int roomId, Chest b = null, Monster c = null, string description = "")
        {
			Room room = new Room(roomId, b, c, description);
			Rooms.Add(roomId, room);
			numOfRooms++;
		}

		public Room getRoomById(int roomID)
		{
			return Rooms[roomID];
		}

	}
}
