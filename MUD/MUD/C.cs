using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
namespace MUD
{
	/**
	* A faster way to write to the console
	*/
	static class C
	{
		

		//Write a string to the console
		public static void t(string say)
		{
			foreach (char c in say)
			{
				Console.Write(c);
				Data.du.Play();
				Thread.Sleep(5);
				
			}
			Data.du.Stop();
			//The sound takes 0.05 seconds to play, but the character delay are 0.005 seconds. Therefore it is necessary to stop it.
			Console.WriteLine();
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
		public static void b(string say)
		{
			Console.WriteLine("\t>>>" + say + "<<<");
		}
	}
}
