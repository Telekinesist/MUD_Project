using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    public class DifferentsWeapons
    {
        List<Weapon> weapons = new List<Weapon>();

        public DifferentsWeapons()
        {
            Weapon w1 = new Weapon(10, "Toothpick", "Deadly toothpick of the Gods");
            Weapon w2 = new Weapon(15, "Daggert", "Small but deadly to some monsters");
            weapons.Add(w1);
            weapons.Add(w2);
        }


        public Weapon GetRandomWeapon()
        {
            Random rand = new Random();
            int i = rand.Next(0, weapons.Count);
            return weapons[i];
        }
 

            
    }

    public class Weapon
    {
        public int damage;
        public string name;
        public string description;

        public Weapon(int damage, string name, string description)
        {
            this.damage = damage;
            this.name = name;
            this.description = description;

        }

		public override string ToString()
		{
			string s = name + "\n";
		   s += description + "\n";
			s += damage + "\n";
			return s;
		}


	}
}
