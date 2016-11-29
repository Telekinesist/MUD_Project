using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	/**
	* The Room object is a node in the graph that makes up the world
	*/
	[Serializable]
	public class Room
	{		
        public Chest RoomChest;
        public Monster RoomMonster;
		public List<Edge> edges = new List<Edge>();
		public bool isNew = true;
		public string customForce;
		public string customOption;
		public string customEnd;

		public int id;

		public string descrp;

		public Room(int roomId, string description = "", Chest b = null, Monster c = null)
		{
			id = roomId;
            RoomChest = b;
            RoomMonster = c;
			descrp = description;
		}

		//Adds an edge for the directions north, south, east or west.
		public void addEdge(Room linkRoom, string directionTag, string description = "", char retning ='w')
		{
			edges.Add(new Edge(linkRoom, directionTag, description,retning));
		}
	}
}
