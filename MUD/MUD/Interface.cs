using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class Interface
	{
		public static List<string> directions = new List<string>();
		//Handles user input
		public static void playerCommand(string input)
		{
			if (input.Length > 0)
			{
				if (input.Substring(0, 2).Equals("tp"))
				{
					Player.room = int.Parse(input.Substring(3));
				}
				else if (Data.showInv.Any(input.Contains))
				{
					Player.getStats();
				}
				else if (Data.move.Any(input.Contains))
				{
					foreach (string direct in directions)
					{
						if (input.Contains(" " + direct))
						{
							Player.move(direct);
						}
					}
				}
			}
			
		}
	}
}
