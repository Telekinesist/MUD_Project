using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    public class Chest
    {
       public string a_Hp;
       public Weapon b_Weapon;
       public Chest(string Hp_Exp, Weapon weapon)
        {
            a_Hp = Hp_Exp;
            b_Weapon = weapon;
        }
    }
}
