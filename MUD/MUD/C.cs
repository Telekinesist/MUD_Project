using System;
using System.Threading;
namespace MUD
{
	/**
	* A faster way to write to the console
	*/
	static class C
	{
		

		//Write a string to the console
		public static void t(string say, int pause = 0)
		{
			int index = 0;
			while (index < say.Length)
			{
				Console.Write(say[index]);
				if (say[index].Equals('.') || say[index].Equals('?'))
				{
					Data.du.Stop();
					if ((index + 1 < say.Length) && say[index + 1].Equals('\n'))
					{
						index++;
						Console.WriteLine();
						Thread.Sleep(pause);
					}
					else if (index + 1 == say.Length)
					{
						Console.WriteLine();
					}
					else
					{
						Thread.Sleep(500);
					}
					
				}
				else if (index + 1 == say.Length)
				{
					Console.WriteLine();
				}
				else if (say[index].Equals('\n'))
				{
					Data.du.Stop();
					Console.WriteLine();
					Thread.Sleep(pause);
				}
				else
				{
					Data.du.Play();
					Thread.Sleep(5);
				}
				index++;
			}
			Data.du.Stop();
			//The sound takes 0.05 seconds to play, but the character delay are 0.005 seconds. Therefore it is necessary to stop it.
			Thread.Sleep(pause);
			

		}

		//Writes debug information to the console. Can handle anything, not just strings.
		public static void d<obj>(obj toConsole)
		{
			Console.WriteLine("DEBUG: " + toConsole);
		}

		//Used for listing stuff
		public static void l(string list, string stat = "")
		{
			Console.Write("    " + list);
			if (list.Length < 6)
			{
				Console.WriteLine("\t\t\t: " + stat);
			}
			else if (list.Length < 15)
			{
				Console.WriteLine("\t\t: " + stat);
			}
			else
			{
				Console.WriteLine("\t: " + stat);
			}
			
		}

		//Writes battle messages to the console
		public static void b(string say, int pause = 0)
		{
			Console.Write("\t>>>");
			foreach(char c in say)
			{
				Console.Write(c);
				Data.du.Play();
				Thread.Sleep(3);
			}
			Data.du.Stop();
			Console.WriteLine("<<<");
			Thread.Sleep(pause);
		}
	}
}
