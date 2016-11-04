using System;
using System.Collections.Generic;

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

		public Map()
		{

		}

		public void addRoom(int roomId, Chest b = null, Monster c = null, string description = "")
        {
			Monster mon = null;
			Chest che = null;
			if (c != null)
			{
				mon = new Monster(c.a_level, c.b_WhatType, c.c_MostersHP, c.d_MostersAtt, c.isSleeping);
			}
			if (b != null)
			{
				che = new Chest(b.Hp, b.weapon);
			}
			Room room = new Room(roomId, b, mon, description);
			Rooms.Add(roomId, room);
		}

		public Room getRoomById(int roomID)
		{
			return Rooms[roomID];
		}

	}
}
