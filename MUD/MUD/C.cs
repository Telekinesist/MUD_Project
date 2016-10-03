using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class C
	{
		public static void t(string say)
		{
			Console.WriteLine(say);
		}
		public static void d<obj>(obj toConsole)
		{
			Console.WriteLine("DEBUG: " + toConsole);
		}
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
	}
}
