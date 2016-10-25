﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			if (room.RoomMonster != null)
			{
				C.t("Watch out! A " + room.RoomMonster.b_WhatType + " attacks you!");
				
				Interface.battle(room.RoomMonster);
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
		}

		//List the content of chests
		public static void descripeChestContent(Chest chest)
		{
			C.t("You opened the chest. You found:", 1000);
			if (chest.Hp != 0)
			{
				C.l("A potion! You have been healed " + chest.Hp + "HP");
			}
			if (chest.weapon != null)
			{
				C.l(chest.weapon.ToString());
				if (Interface.accept("Will you take the weapon?", "You took the weapon", "You decided to leave the weapon. A rat took it instead"))
				{
					Player.damage = chest.weapon.damage;
					Player.weapon = chest.weapon.name;
				}
			}
			if (chest.Hp.Equals(null) && chest.weapon.Equals(null))
			{
				C.t("Nothing. The chest is empty");
			}
		}
	}
}
