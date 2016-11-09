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
            Weapon j1 = new Weapon(1, "Plasik Spoon", "Good luck, you need it");
            Weapon j2 = new Weapon(2, "Plasik Fork", "You can try, just try to kill anything");
            Weapon j3 = new Weapon(3, "Plasik Spork ", "Just try to kill anything");
            Weapon j4 = new Weapon(4, "Small toy Dagget  ", "Roleplay weapon");
            Weapon j5 = new Weapon(5, "Toy Sword", "Roleplay weapon" );
            //alle junk våben der er laves i spille
            Weapon c1 = new Weapon(8, "Rusten Spoon", "It's rusten but can maybe kill");
            Weapon c2 = new Weapon(10, "Rusten Fork", "It's rusten, but can kill");
            Weapon c3 = new Weapon(13,"Rusten Spork", "It was just to feed babys but now it can by just to KILL");
            Weapon c4 = new Weapon(15, "Rusten Dagget","");
            Weapon c5 = new Weapon(18,"Rusten Sword","");
            //alle common våben der laves i spillet 

            JunkWeapons.Add(j1);                    CommonWeapons.Add(c1);                    RareWeapons.Add();
            JunkWeapons.Add(j2);                    CommonWeapons.Add(c2);                    RareWeapons.Add();
            JunkWeapons.Add(j3);                    CommonWeapons.Add(c3);                    RareWeapons.Add();
            JunkWeapons.Add(j4);                    CommonWeapons.Add(c4);                    RareWeapons.Add();
            JunkWeapons.Add(j5);                    CommonWeapons.Add(c5);                    RareWeapons.Add();

                                  EpicWeapons.Add();                  LegendaryWeapons.Add();
                                  EpicWeapons.Add();                  LegendaryWeapons.Add();
                                  EpicWeapons.Add();                  LegendaryWeapons.Add();
                                  EpicWeapons.Add();                  LegendaryWeapons.Add();
                                  EpicWeapons.Add();                  LegendaryWeapons.Add();
                                           
            
        }


        public Weapon GetRandomWeapon(int JunkChance, int CommonChance, int RareChance, int EpicChance, int LegendaryChance)
        {
           
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
                Random Rare = new Random();
                int i = Rare.Next(0, RareWeapons.Count);
                return RareWeapons[i];
            }
            else if (r > RareChance && r <= EpicChance)
            {
                Random Epic = new Random();
                int i = Epic.Next(0, EpicWeapons.Count);
                return EpicWeapons[i];
            }
            else 
            {
                Random Legendary = new Random();
                int i = Legendary.Next(0, LegendaryWeapons.Count);
                return LegendaryWeapons[i];
            }
         
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
