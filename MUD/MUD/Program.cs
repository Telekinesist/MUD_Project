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
			//Ads data
			Data.addCommands();
			Data.addData();
			Data.createWorld();
            PlayerCostomization.CreatePlayer();

			//While loop narrates the story, takes player input, and handles it
			while (!(input.Equals("exit")))
			{
				Narrator.enterRoom(Data.room());
				input = Console.ReadLine().ToLower();
				Interface.playerCommand(input);
			}
		}
	}
}
