using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class End
	{
		public static void story(string action)
		{
			string input = "";
			switch (action)
			{
				case "deathPit":
					C.t("This room is completely dark.");
					C.t("You stumple through the darkness, perhaps you could find a light switch.");
					C.t("You fall; soon screaming as you realize you keep falling.");
					C.t("A silent \"BUMB\" can be hard from the top of the pit", 4000);
					C.t("\t\t\t\tGAME OVER");
					Console.Write("\n\n\n\n\n\n\n\n\n\n");
					C.t("", 10000);
					C.t("Continue or Quit?");
					while (true)
					{
						input = Console.ReadLine().ToLower();
						if (input.Contains("continue"))
						{
							Save.load();
							break;
						}
						else if (input.Contains("quit"))
						{
							Environment.Exit(0);
						}
						else if (input.Contains("save"))
						{
							C.t("You DIED. Moron");
							C.t("Why would you want to save? So you could reload the death screen?!?!");
							C.t("Idiot");
						}
						else
						{
							C.t("You only have those two options. Please choose one");
						}
					}
					
					break;

                case "NerdEnd":
                    C.t("You walk out into the light, gretted by a pair of fellow geeks.",200);
                    C.t("They point you to their D & D van.",200);
                    C.t("You are finally free.",100);
                    C.t("I guess?",1000);
                    C.t("THE END (or something)");
                    C.t("", 1200);
                    C.t("Replay?");
                    while (true)
                    {
                        input = Console.ReadLine().ToLower();
                        if (input.Contains("replay"))
                        {
                             
                        }

                        else if (input.Contains("reload"))
                        {
                            C.t("Loading last save game");
                            Save.load();
                            break;
                        }

                        else if (input.Contains("exit"))
                        {
                            Environment.Exit(0);
                        }

                        
                    }

                    break;

                case "LockdownEnd":
                    C.t("The door slams behind you, and the room goes dark.", 200);
                    C.t("Uanble to re-open the door, you accept your fate... ", 600);
                    C.t("An eternity in lockdown.",1000);
                    C.t("THE END", 100);
                    C.t("(more or less", 500);
                    C.t("", 1200);
                    C.t("Replay?");
                    while (true)
                    {
                        input = Console.ReadLine().ToLower();
                        if (input.Contains("replay"))
                        {

                        }

                        else if (input.Contains("reload"))
                        {
                            C.t("Loading last save game");
                            Save.load();
                            break;
                        }

                        else if (input.Contains("exit"))
                        {
                            Environment.Exit(0);
                        }


                    }

                    break; 



                default:

                    C.d("This room is supposed to have a custom action, but the action specified does not exist");
					break;
			}
		}
	}
}
