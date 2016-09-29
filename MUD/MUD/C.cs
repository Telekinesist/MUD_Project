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
	}
}
