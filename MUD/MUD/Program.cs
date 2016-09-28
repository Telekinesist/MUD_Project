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

			//Creates test world with 2 rooms
			//Map world = new Map();
			Data.world.addRoom(1);
			Data.world.addRoom(2);

			Data.world.getRoomById(1).addEdge("north", new Edge(Data.world.getRoomById(2)));
			Data.world.getRoomById(2).addEdge("south", new Edge(Data.world.getRoomById(1)));



			string input = Console.ReadLine().ToLower();
			while (!(input.Equals("exit")))
			{
				Interface.playerCommand(input);
				input = Console.ReadLine().ToLower();
			}
		}
	}
}
