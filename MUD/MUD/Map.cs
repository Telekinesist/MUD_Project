using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MUD
{
	public class Map
	{
		public List<Room> Rooms;
		int numOfRooms = -1;

		public Map()
		{
			Rooms = new List<Room>();
		}

		public void addRoom(int roomId)
		{
			Room room = new Room(roomId);
			Rooms.Add(room);
			numOfRooms++;
		}

		public Room getRoom(int roomID)
		{
			for (int i = numOfRooms; i >= 0; i--)
			{
				if (Rooms[i].id.Equals(roomID))
				{
					return Rooms[i];
				}
			}
			return null;
		}
	}
}
