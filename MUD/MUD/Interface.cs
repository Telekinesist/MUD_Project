using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	/**
	* Interface class handles the players input
	*/
	static class Interface
	{
		public static List<string> directions = new List<string>();
		public static bool haveChest = false;
		//Handles user input
		public static void playerCommand(string input)
		{
			if (input.Length > 1)
			{
				if (input.Substring(0, 2).Equals("tp"))
				{
					Player.room = int.Parse(input.Substring(3));
				}
				else if (Data.showInv.Any(input.Contains))
				{
					Player.getStats();
				}
				else if (Data.move.Any(input.Contains))
				{
					foreach (string direct in directions)
					{
						if (input.Contains(" " + direct))
						{
							Player.move(direct);
							break;
						}
					}
				}
				if (haveChest && input.Equals("open chest"))
				{
					Narrator.descripeChestContent(Data.room().RoomChest);
					Player.HP += Data.room().RoomChest.Hp;
					Data.room().RoomChest.unopened = false;
				}
			}
		}

		public static bool accept(string description, string accept = "You accepted", string decline = "You declined")
		{
			C.t(description);
			while (true)
			{
				
				string input = Console.ReadLine().ToLower();
				if (input.Equals("yes"))
				{
					C.t(accept);
					return true;
				}
				else if (input.Equals("no"))
				{
					C.t(decline);
					return false;
				}
				else if (Data.showInv.Any(input.Contains))
				{
					Player.getStats();
				}
				else
				{
					C.t("No or yes please");
				}
			}
		}

		public static void battle(Monster enemy)
		{
			bool inBattle = true;
			C.b("You ENGAGE in BATTLE. A " + enemy.b_WhatType.ToUpper() + " in LEVEL " + enemy.a_level + " attacks you");
			string input;
			Random r = new Random();
			double damage;
			bool isDoding = false;
			while (inBattle)
			{
				//goto reference
				start:

				C.b(enemy.b_WhatType.ToUpper() + "'s HP: " + enemy.c_MostersHP);
				input = Console.ReadLine().ToLower();
				if (input.Contains("attack"))
				{
					if (r.NextDouble() < Player.weildability)
					{
						//Adds +/- inconcistency to the player attack. Yes it is bulky, but is it 22pm. Yes it is! I just want to finish tish
						damage = Player.damage + (0.1 * r.Next(int.Parse(((-1) * Player.inconsitency * 100).ToString()), int.Parse((Player.inconsitency * 100).ToString())));
						C.b("You ATTACK for " + Math.Round(damage) + " ammount of DAMAGE");
						enemy.c_MostersHP -= int.Parse(Math.Round(damage).ToString());
					}
				}
				else if (input.Contains("dodge"))
				{
					isDoding = true;
				}
				else if (Data.showInv.Any(input.Contains))
				{
					Player.getStats();
					//Jumps to the start: at the top of the while loop
					goto start;
				}
				else
				{
					C.t("In your panic you tried to " + input + " but failed miserabely. Probably why you are down here");
					C.t("You feel so stupid even thinking that " + input + " would work that you knock your head against the wall. You lose 1HP");
					Player.HP -= 1;
				}
				//Cheks if someone died
				if (enemy.c_MostersHP <= 0 || Player.HP <= 0)
				{
					inBattle = false;
					break;
				}
				//Determines whenever or not an attenpt to dodge is successfull;
				if (isDoding)
				{
					if (r.Next(0, 10) > 1)
					{
						C.b("You DODGEd successfully");
					}
					else
					{
						C.b("You STUMPLE on a ROCK, and failed to DODGE");
						isDoding = false;
					}
				}
				//If not dodgin, the enemy attacks
				if (!isDoding)
				{
					damage = enemy.d_MostersAtt + (0.1 * r.Next(-20, 20) * enemy.d_MostersAtt);
					C.b("The " + enemy.b_WhatType.ToUpper() + " ATTACKs for " + Math.Round(damage) + " DAMAGE");
					Player.HP -= int.Parse(Math.Round(damage).ToString());
				}
				//Disables dodgin for nex round
				else
				{
					isDoding = false;
				}
				//Checks again if anyone died
				if (enemy.c_MostersHP <= 0 || Player.HP <= 0)
				{
					inBattle = false;
				}
			}

			//If both enemy and player dies
			if (enemy.c_MostersHP <= 0 && Player.HP <= 0)
			{
				C.t("You defeated the enemy, but only manages to walk a few steps before you collapse on the floor");
				C.t("\t\t\t\tGAME OVER\n\n\n\n\n\n\n\n\n\n");
				C.t("But this is the demo, so whatever. Here, have full HP");
				Player.HP = 100;
			}
			//If monster dies
			else if (enemy.c_MostersHP <= 0)
			{
				C.b("You where VICTORIOUS");
				C.b("You gained a zillion XP");
				C.t("(Exept XP is not implemented)");
				Data.room().RoomMonster = null;
			}
			//If player dies
			else if (Player.HP <= 0)
			{
				C.t("You have been slain by the " + enemy.b_WhatType + ". You collapse dead on the floor");
				C.t("\t\t\t\tGAME OVER\n\n\n\n\n\n\n\n\n\n");
				C.t("But this is the demo, so whatever. Here, have full HP");
				Player.HP = 100;
			}
			//If player is a filthy hacker
			else
			{
				C.d("Dafug? Are you hacking?!?");
			}
			Narrator.enterRoom(Data.room());
		}
	}
}
