using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    public class Chest
    {
       public int a_hp;
       public string b_weapon;
       public Chest(int Hp_Exp, string Weapon)
        {
            a_hp = Hp_Exp;
            b_weapon = Weapon;
        }
    }
}
