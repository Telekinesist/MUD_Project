using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	[Serializable]
    public class Chest
    {
		public int Hp;
		public Weapon weapon;
		public bool unopened = true;
		public Chest(int Hp_Exp, Weapon chestweapon)
        {
            Hp = Hp_Exp;
            weapon = chestweapon;
        }
    }
}
