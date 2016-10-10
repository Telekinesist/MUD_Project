using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	class Program
	{
		static string input = "";
		static void Main(string[] args)
		{
			Data.addCommands();
			Data.addData();
			Data.createWorld();
			while (!(input.Equals("exit")))
			{
				Narrator.enterRoom(Data.getRoom(Player.room));
				
				input = Console.ReadLine().ToLower();
				Interface.playerCommand(input);
			}
		}
	}
}
