using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	class Program
	{   static int action;
		static void Main(string[] args)
		{       
            
                List<Chest> DiffierentChestes;
                DiffierentChestes = new List<Chest>();
                DiffierentChestes.Add(new Chest(50, "weapon"));
                DiffierentChestes.Add(new Chest(0, "poison"));
                DiffierentChestes.Add(new Chest(700, ""));


                List<Monster> DiffierentMonsters;
                DiffierentMonsters = new List<Monster>();
                DiffierentMonsters.Add(new Monster(1, "Rat"));



            Map world = new Map();
			world.addRoom(1, DiffierentChestes[0], DiffierentMonsters[0]);
            world.addRoom(2, DiffierentChestes[1], DiffierentMonsters[0]);

            Console.WriteLine("you found a chest and pick up a potion with " + world.getRoomById(1).RoomChest.a_hp + "hp" + "but wait, there is something else in the room you entered, it is" + world.getRoomById(1).RoomMonster.b_WhatType + " and it level is " + world.getRoomById(1).RoomMonster.a_level);
            Console.WriteLine("you entered a new room with " + world.getRoomById(2).RoomChest.b_weapon + " you died, GAME OVER!!!!");
            Console.ReadLine();

			world.getRoomById(1).addEdge("north", new Edge(world.getRoomById(2)));
			world.getRoomById(2).addEdge("south", new Edge(world.getRoomById(1)));

            //nu er jeg med

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
