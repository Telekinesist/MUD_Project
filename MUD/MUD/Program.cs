using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	class Program
	{
		static void Main(string[] args)
		{
			Map world = new Map();
			world.addRoom(1);
			world.addRoom(2);

			world.getRoomById(1).addEdge("north", new Edge(world.getRoomById(2)));
			world.getRoomById(2).addEdge("south", new Edge(world.getRoomById(1)));



			string input = Console.ReadLine().ToLower();
			while (!(input.Equals("exit")))
			{
				if (input.Contains("tp"))
				{
					Player.inRoom = int.Parse(input.Substring(2));
				}
				input = Console.ReadLine().ToLower();
			}
		}
	}
}
