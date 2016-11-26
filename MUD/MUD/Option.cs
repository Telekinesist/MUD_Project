using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace MUD
{
	static class Option
	{
		public static void story(string action)
		{
			switch (action)
			{
				case "sleepy_monster_rust_door":
					//Now it looks like it is taking input from the main loop
					string input = Console.ReadLine().ToLower();

					//Checks if the player is attempting to go through the rusten door
					//Also checks that the monster isn't already dead.
					if (input.Contains("rust") && Data.move.Any(input.Contains) && Data.room().RoomMonster != null)
					{
						C.t("The moster worke up. RUN!");
						Data.room().RoomMonster.isSleeping = false;
						bool caught = true;
						Stopwatch run = new Stopwatch();
						run.Start();
						do
						{
							//Takes input from the player. If the player types "run" withing 5 seconds, they will escape through the door
							input = Console.ReadLine().ToLower();
							if (input.Contains("run") || input.Contains("hurry") || input.Contains("go"))
							{
								if (run.ElapsedMilliseconds < 5000)
								{
									Player.move("rust");
									caught = false;
									break;
								}
								else
								{
									//Oh no!, Too slow!
									C.t("Too slow.");
								}
							}
							else
							{
								run.Stop();
								C.t("Do what?");
								run.Start();
							}
						} while (run.ElapsedMilliseconds < 5000);
						if (caught)
						{
							//Goes to the next line, instead of writing atop the players attempted input
							Console.WriteLine();
							C.t("The monster graps you by your shoulder and flings you back into the room");
							Interface.battle(Data.room().RoomMonster);
						}
						else
						{
							C.t("You ran thought the door, and managed to close it behind you");
							//Narrates the newly entered room, since the main loop have only gotten to take the players input after this
							Narrator.enterRoom(Data.room());
						}
					}
					//If the player does not attempt to go through the rusten door, it will just take the player input as a regular command.
					else
					{
						Data.tookAction = true;
						//If no action was taken, the playerCommand method will change tookAction to false
						Interface.playerCommand(input);

						//Runs until the player takes an apropriate action. Simulates the main loop
						while (!Data.tookAction)
						{
							Data.tookAction = true;
							Narrator.enterRoom(Data.room());
							input = Console.ReadLine().ToLower();
							Interface.playerCommand(input);
						}
						Narrator.enterRoom(Data.room());
						
					}
					break;
				default:
					C.d("This room is supposed to have a custom action, but the action specified does not exist");
					break;
			}
		}
	}
}
