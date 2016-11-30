using System;
using System.Linq;

namespace MUD
{
	class Program
	{
		public static string input = "";
		static void Main(string[] args)
		{
			//Sets the buffer size of terminal. Needed to display the menu proporly, besides, the default console is too small for my taste
			Console.BufferWidth = 110;
			Console.WindowWidth = 110;

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
