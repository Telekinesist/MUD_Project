using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class C
	{
		/**
		 * A faster way to write to the console
		 */
		
		//Write a string to the console
		public static void t(string say)
		{
			Console.WriteLine(say);
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
