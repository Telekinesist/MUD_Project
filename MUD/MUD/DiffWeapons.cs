using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	[Serializable]
    public class DiffWeapons
    {
        List<Weapon> JunkWeapons = new List<Weapon>();
        List<Weapon> CommonWeapons = new List<Weapon>();
        List<Weapon> RareWeapons = new List<Weapon>();
        List<Weapon> EpicWeapons = new List<Weapon>();
        List<Weapon> LegendaryWeapons = new List<Weapon>();

        Random rand = new Random();

        public DiffWeapons()
        {
            Weapon w1 = new Weapon(5, "Toothpick", "Deadly toothpick of the Gods");
            Weapon w2 = new Weapon(10, "Daggert", "Small but deadly to some monsters");
            Weapon w3 = new Weapon(15, "Small Sword", "The chosen weapon to a noob");
            Weapon w4 = new Weapon(20, "Normel Sword", " The chosen weapon to a well player");
            Weapon w5 = new Weapon(25, "Long Sword", "The longest sword in the univers" );
          
           
            JunkWeapons.Add(w1);
            CommonWeapons.Add(w2);
            RareWeapons.Add(w3);
            EpicWeapons.Add(w4);
            LegendaryWeapons.Add(w5);
          
            
            
        }


        public Weapon GetRandomWeapon(int JunkChance, int CommonChance, int RareChance, int EpicChance, int LegendaryChance)
        {
            Weapon w = null;
            int r = rand.Next(0, 101);
                if (r <= JunkChance)
            {
                Random Junk = new Random();
                int i = Junk.Next(0, JunkWeapons.Count);
                return JunkWeapons[i];
            }
            else if (r > JunkChance && r <= CommonChance)
            {
                Random Common = new Random();
                int i = Common.Next(0, CommonWeapons.Count);
                return CommonWeapons[i];
            }
                else if (r > CommonChance && r <= RareChance)
            {

            }
            return w;
        }
 

            
    }

	[Serializable]
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
			s += damage + " Damege" +"\n";
			return s;
		}


	}
}
