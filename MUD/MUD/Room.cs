using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	public class Room
	{
		/**
		 * The room object is a node in the graph that makes up the world
		 */
		
        public Chest RoomChest;
        public Monster RoomMonster;
        public Edge north;
		public Edge south;
		public Edge east;
		public Edge west;

		public int id;

		public string descrp;

		public Room(int roomId, Chest b = null, Monster c = null, string description = "")
		{
			id = roomId;
            RoomChest = b;
            RoomMonster = c;
			descrp = description;
		}

		//Adds an edge for the directions north, south, east or west.
		public void addEdge(string direction, Edge linkEdge)
		{
			switch (direction.Substring(0, 1).ToLower())
			{
				case "n":
					north = linkEdge;
					break;
				case "s":
					south = linkEdge;
					break;
				case "e":
					east = linkEdge;
					break;
				case "w":
					west = linkEdge;
					break;
				default:
					Console.WriteLine("DEBUG: The code attempted to add an edge to an unknown direction \"" + direction + "\". Direction default to null");
					break;
			}
		}
	}
}
