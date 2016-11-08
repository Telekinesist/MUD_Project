using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class Force
	{
		public static void story(string action)
		{
			switch (action)
			{
				default:
					C.d("This room is supposed to have a custom action, but the action specified does not exist");
					break;
			}
		}
	}
}
