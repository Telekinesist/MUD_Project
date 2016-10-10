using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	/**
	 * Edge only contans a destination and a price. Price is currently not used
	 */
	public class Edge
	{
		public Room link;
		public int distance;

		public Edge(Room linkedRoom, int price = 0)
		{
			link = linkedRoom;
			distance = price;
		}
	}
}
