using System;
using System.Linq;

namespace MUD
{
	class Program
	{
		public static string input = "";
		static void Main(string[] args)
		{
			//Adds data
			Data.addCommands();
			Data.addData();
			
			
			BM.play("door");
			Menu.titleMenu();

			
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
