using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MUD
{
	public class Map
	{
		public Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
		int numOfRooms = 0;

		public Map()
		{

		}

		public void addRoom(int roomId, Chest b = null, Monster c = null)
        {
			Room room = new Room(roomId, b, c);
			Rooms.Add(roomId, room);
			numOfRooms++;
		}

		public Room getRoomById(int roomID)
		{
			return Rooms[roomID];
		}
	}
}
