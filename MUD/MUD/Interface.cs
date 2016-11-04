using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
				else if (input.Contains("save"))
				{
					if (accept("\n\n\nAre you SURE you want to save? This will override previous saved data.\nYes/No", "Game saved", "Save not commenced"))
					{
						Save.save();
					}
				}
				else if (input.Contains("load"))
				{
					if (accept("\n\n\nAre you SURE you want to load? All progress will be lost\nYes/No", "Loaded save data", "Load not commenced"))
					{
						Save.load();
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
			BM.play("mon");
			//Min 150 milliseconds or the music won't pause
			Thread.Sleep(1000);
			bool inBattle = true;
			if (enemy.b_WhatType.Equals("Spider"))
			{
				C.b("You ENGAGE in, Ba-");
				BM.stop("mon");
				Thread.Sleep(1000);
				
				C.t("Wait. Where is the enemy?", 500);
				C.t("Oh, it's just small a spider", 500);
				C.t("OH WAIT CRAP, YOU A TERRIGIED OF SPIDERS!!!",500);
				C.t("SOMEONE SAAAAAAAAVEE MEEEEEEEEE!!!!!!!!!!!!!!!!!!!!!!!", 100);
				BM.play("spid");
			}
			else
			{
				C.b("You ENGAGE in BATTLE. A " + enemy.b_WhatType.ToUpper() + " in LEVEL " + enemy.a_level + " attacks you", 300);
			}
			string input;
			Random r = new Random();
			double damage;
			bool isDoding = false;
			while (inBattle)
			{
				//goto reference
				start:

				C.b(enemy.b_WhatType.ToUpper() + "'s HP: " + enemy.c_MostersHP, 100);
				input = Console.ReadLine().ToLower();
				if (Data.attack.Any(input.Contains))
				{
					if (r.NextDouble() < Player.weildability)
					{
						//Adds +/- inconcistency to the player attack. Yes it is bulky, but is it 22pm. Yes it is! I just want to finish tish
						damage = Player.damage + (0.1 * r.Next(int.Parse(((-1) * Player.inconsitency * 100).ToString()), int.Parse((Player.inconsitency * 100).ToString())));
						C.b("You ATTACK for " + Math.Round(damage) + " ammount of DAMAGE", 100);
						enemy.c_MostersHP -= int.Parse(Math.Round(damage).ToString());
					}
				}
				else if (Data.dodge.Any(input.Contains))
				{
					isDoding = true;
				}
				else if (Data.showInv.Any(input.Contains))
				{
					Player.getStats();
					//Jumps to the start: at the top of the while loop
					//It could be done otherwise, but this works well, and the code is easy to change this way
					goto start;
				}
				else if (Data.think.Any(input.Contains))
				{
					C.t("You think about who you are. Why you are here. What comes next", 1000);
					C.t("The " + enemy.b_WhatType + " attacks while your guard is down");

				}
				else if (input.Length < 1)
				{
					C.b("You do NOTHING", 100);
					C.b("The " + enemy.b_WhatType.ToUpper() + " is still mad as hell");
				}
				else
				{
					C.t("In your panic you tried to " + input + " but failed miserabely. Probably why you are down here", 300);
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
						C.b("You STUMPLE on a ROCK, and failed to DODGE", 100);
						isDoding = false;
					}
				}
				//If not dodgin, the enemy attacks
				if (!isDoding)
				{
					damage = enemy.d_MostersAtt + (0.01 * r.Next(-20, 20) * enemy.d_MostersAtt);
					C.b("The " + enemy.b_WhatType.ToUpper() + " ATTACKs for " + Math.Round(damage) + " DAMAGE", 100);
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

			BM.stop("mon");
			BM.stop("spid");

			//If both enemy and player dies
			if (enemy.c_MostersHP <= 0 && Player.HP <= 0)
			{
				C.t("You defeated the enemy, but only manages to walk a few steps before you collapse on the floor", 3000);
				C.t("\t\t\t\tGAME OVER\n\n\n\n\n\n\n\n\n\n", 10000);
				C.t("But this is the demo, so whatever. Here, have full HP");
				Player.HP = 100;
			}
			//If monster dies
			else if (enemy.c_MostersHP <= 0)
			{
				C.b("You where VICTORIOUS", 300);
				C.b("You gained a zillion XP", 300);
				C.t("(Exept XP is not implemented)");
				Data.room().RoomMonster = null;
			}
			//If player dies
			else if (Player.HP <= 0)
			{
				C.t("You have been slain by the " + enemy.b_WhatType + ". You collapse dead on the floor", 3000);
				C.t("\t\t\t\tGAME OVER\n\n\n\n\n\n\n\n\n\n", 10000);
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
