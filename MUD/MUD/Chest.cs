using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    public class Chest
    {
       public int a_Hp;
       public string b_Weapon;
       public Chest(int Hp_Exp, string Weapon)
        {
            a_Hp = Hp_Exp;
            b_Weapon = Weapon;
        }
    }
}
