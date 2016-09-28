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

		public void addRoom(int roomId, Chest b, Monster c)
		{
			Room room = new Room(roomId, b, c);
			Rooms.Add(room);
			numOfRooms++;
		}

		public Room getRoomById(int roomID)
		{
			for (int i = numOfRooms; i >= 0; i--)
			{
				if (Rooms[i].id.Equals(roomID))
				{
					return Rooms[i];
				}
			}
			Console.WriteLine("DEBUG: Did not find room with ID " + roomID);
			return null;
		}
	}
}
