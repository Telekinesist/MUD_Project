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
	 [Serializable]
	public class Edge
	{
		public Room link;
		public string descr;

		public Edge(Room linkedRoom, string description = null)
		{
			link = linkedRoom;
			descr = description;
		}
	}
}
