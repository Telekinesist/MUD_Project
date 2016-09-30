 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	static class Player
	{
		public static int room = 1; //Spawn
		public static int HP = 100;
		
		public static void move(string direction)
		{
			switch (direction[0])
			{
				case 'n':
					if (!(Data.getRoom(room).north == null))
					{
						C.t("You went north");
						room = Data.getRoom(room).north.link.id;
					}
					else
					{
						C.t("You can't go that way");
					}
					break;

				case 's':
					if (!(Data.getRoom(room).south == null))
					{
						C.t("You went south");
						room = Data.getRoom(room).south.link.id;
					}
					else
					{
						C.t("You can't go that way");
					}
					break;
				case 'e':
					if (!(Data.getRoom(room).east == null))
					{
						C.t("You went east");
						room = Data.getRoom(room).east.link.id;
					}
					else
					{
						C.t("You can't go that way");
					}
					break;
				case 'w':
					if (!(Data.getRoom(room).west == null))
					{
						C.t("You went west");
						room = Data.getRoom(room).west.link.id;
					}
					else
					{
						C.t("You can't go that way");
					}
					break;

			}
		}
	}
}
