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
			Save.printSave(Save.load());
			Data.addCommands();
            DifferentsWeapons r = new DifferentsWeapons();
            List<Chest> DiffierentChestes;
            DiffierentChestes = new List<Chest>();
            DiffierentChestes.Add(new Chest(50, r.GetRandomWeapon()));
            DiffierentChestes.Add(new Chest(0, r.GetRandomWeapon()));
            DiffierentChestes.Add(new Chest(700, null));


            List<Monster> DiffierentMonsters;
            DiffierentMonsters = new List<Monster>();
            DiffierentMonsters.Add(new Monster(1, "Rat", 10, 2));

            

            //Creates test world
            Data.world.addRoom(1, null, null, "You stand in a dark room with two doors. What will you do?");
			Data.world.addRoom(2, DiffierentChestes[0], null, "Another dark room.");
            Data.world.addRoom(3, DiffierentChestes[2], DiffierentMonsters[0], "This room is bright");
			Data.world.addRoom(4, null, DiffierentMonsters[0], "There is only the door you came in through. This looks like a trap!");
			Data.getRoom(1).addEdge("north", new Edge(Data.getRoom(2)));
			Data.getRoom(2).addEdge("south", new Edge(Data.getRoom(1)));
            Data.getRoom(3).addEdge("west", new Edge(Data.getRoom(2)));
			Data.getRoom(1).addEdge("east", new Edge(Data.getRoom(3)));
			Data.getRoom(2).addEdge("north", new Edge(Data.getRoom(4)));
			Data.getRoom(4).addEdge("south", new Edge(Data.getRoom(2)));


			//Narrator.enterRoom(Data.getRoom(Player.room));
			while (!(input.Equals("exit")))
			{
				Narrator.enterRoom(Data.getRoom(Player.room));
				
				input = Console.ReadLine().ToLower();
				Interface.playerCommand(input);
			}
		}
	}
}
