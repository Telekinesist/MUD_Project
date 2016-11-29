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
		public string tag;
        public char retning;

		public Edge(Room linkedRoom, string directionTag, string description = null, char retning = 'w')
		{
			link = linkedRoom;
			descr = description;
			tag = directionTag;
            this.retning = retning;  
		}
	}
}
