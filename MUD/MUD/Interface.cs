using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class Interface
	{
		//Handles user input
		public static void playerCommand(string input)
		{
			if (input.Length > 0)
			{
				if (input.Substring(0, 2).Equals("tp"))
				{
					Player.room = int.Parse(input.Substring(3));
				}
				else if (input.Substring(0, 2).Equals("go"))
				{
					Player.move(input.Substring(3));
				}
			}
			
		}
	}
}
