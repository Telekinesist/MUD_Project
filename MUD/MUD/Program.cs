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
			Data.addCommands();

			//Creates test world
			Data.world.addRoom(1);
			Data.world.addRoom(2);
			
			Data.getRoom(1).addEdge("north", new Edge(Data.getRoom(2)));
			Data.getRoom(2).addEdge("south", new Edge(Data.getRoom(1)));


			string input = Console.ReadLine().ToLower();
			while (!(input.Equals("exit")))
			{

				Interface.playerCommand(input);
				input = Console.ReadLine().ToLower();
				
			}
		}
	}
}
