﻿using System;
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
            DifferentsWeapons r = new DifferentsWeapons();
            List<Chest> DiffierentChestes;
            DiffierentChestes = new List<Chest>();
            DiffierentChestes.Add(new Chest("50Hp", r.GetRandomWeapon()));
            DiffierentChestes.Add(new Chest(null, r.GetRandomWeapon()));
            DiffierentChestes.Add(new Chest("700Hp", null));


            List<Monster> DiffierentMonsters;
            DiffierentMonsters = new List<Monster>();
            DiffierentMonsters.Add(new Monster(1, "Rat","10Hp","Attack 2"));

            

            //Creates test world with 2 rooms
            //Map world = new Map();
            Data.world.addRoom(1);
			Data.world.addRoom(2);
            Data.world.addRoom(3, DiffierentChestes[0]);

			/*Data.world.getRoomById(1).addEdge("north", new Edge(Data.world.getRoomById(2)));
			Data.world.getRoomById(2).addEdge("south", new Edge(Data.world.getRoomById(1)));*/
			Data.getRoom(1).addEdge("north", new Edge(Data.getRoom(2)));
			Data.getRoom(2).addEdge("south", new Edge(Data.getRoom(1)));
            Data.getRoom(3).addEdge("west", new Edge(Data.getRoom(2)));
           

			//nu er jeg med

			string input = Console.ReadLine().ToLower();
			while (!(input.Equals("exit")))
			{
				Interface.playerCommand(input);
				input = Console.ReadLine().ToLower();
			}
		}
	}
}
