using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MUD
{
	public class Map
	{
		//public List<Room> Rooms;
		public Dictionary<int, Room> Rooms = new Dictionary<int, Room>();
		int numOfRooms = 0;

		public Map()
		{
			//Rooms = new List<Room>();
		}

		public void addRoom(int roomId, Chest b = null, Monster c = null)
        {
			Room room = new Room(roomId, b, c);
			//Rooms.Add(room);
			Rooms.Add(roomId, room);
			numOfRooms++;
		}

		public Room getRoomById(int roomID)
		{
			/*for (int i = numOfRooms -1; i >= 0; i--)
			{
				if (Rooms[i].id.Equals(roomID))
				{
					return Rooms[i];
				}
			}
			Console.WriteLine("DEBUG: Did not find room with ID " + roomID);
			return null;*/
			return Rooms[roomID];
		}
	}
}
