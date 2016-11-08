
using System.Collections.Generic;

namespace MUD
{
	/**
	* Narrator class tells the story
	*/
	class Narrator
	{	
		//Runs before player gives input. Descripes the room. Starts battle if room contains monster
		public static void enterRoom(Room room)
		{
			C.t(room.descrp, 1000);
			if (room.customForce != null)
			{
				Force.story(room.customForce);
			}
			else if (room.RoomMonster != null)
			{
				if (room.RoomMonster.isSleeping)
				{
					if (Data.makeNoise)
					{
						C.t("You have awoken the " + room.RoomMonster.b_WhatType.ToLower() + " from its sleep. The " + room.RoomMonster.b_WhatType.ToLower() + " is pissed.");
					}
					else
					{
						C.t("You freeze as you see a " + room.RoomMonster.b_WhatType.ToLower() + " sleeping. Better be carefull...");
					}
				}
				else
				{
					C.t("Watch out! A " + room.RoomMonster.b_WhatType.ToLower() + " attacks you!");
					Interface.battle(room.RoomMonster);
				}
			}
			else if (room.RoomChest != null)
			{
				if (room.RoomChest.unopened)
				{
					Interface.haveChest = true;
					C.t("This room have an unopened chest");
				}
				else
				{
					Interface.haveChest = false;
					C.t("Here is a chest you already opened");
				}
			}
			if (room.isNew)
			{
				lookAround();
				room.isNew = false;
			}
			if (room.customOption != null)
			{
				Option.story(room.customOption);
			}
			if (room.customEnd != null)
			{
				End.story(room.customEnd);
			}
		}

		//List the content of chests
		public static void descripeChestContent(Chest chest)
		{
			C.t("You opened the chest. You found:", 1000);
			if (chest.Hp != 0)
			{
				C.l("A potion! You have been healed " + chest.Hp + "HP");
				BM.play("heal");
			}
			if (chest.weapon != null)
			{
				C.l(chest.weapon.ToString());
				if (Interface.accept("Will you take the weapon?", "You took the weapon", "You decided to leave the weapon. A rat took it instead"))
				{
					Player.damage = chest.weapon.damage;
					Player.weapon = chest.weapon.name;
					BM.play("pickUp");
				}
			}
			if (chest.Hp.Equals(null) && chest.weapon.Equals(null))
			{
				C.t("Nothing. The chest is empty");
			}
		}

		public static void lookAround()
		{
			C.t("There are " + Data.room().edges.Count + " doors in this room");
			foreach (Edge e in Data.room().edges)
			{
				C.t("There is a " + e.descr);
			}
		}
	}
}
