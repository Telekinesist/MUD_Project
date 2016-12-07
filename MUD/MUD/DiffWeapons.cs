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
            Weapon c3 = new Weapon(13, "Rusten Spork", "It was just to feed babys, but now it can be just to KILL");
            Weapon c4 = new Weapon(15, "Rusten Dagget", "An one thousand years old Dagget");
            Weapon c5 = new Weapon(18, "Rusten Sword", "A two thousand five hundred years old Sword");
            //alle common våben der laves i spillet 

            Weapon r1 = new Weapon(20, "Broad sword.", "A sizeable sword with a broad blade");
            Weapon r2 = new Weapon(23, "Warhammer.", "A big hammer designed for brawling");
            Weapon r3 = new Weapon(26, "Crossbow.", "A simple, but effective crossbow");
            Weapon r4 = new Weapon(30, "Katana.", "A japanese sword known for its extreme sharpness.Used by the samurai");
            Weapon r5 = new Weapon(35, "Luger pistol.", "The iconic pistol used by the Wehrmacht");
            //alle rare våben der laves i spillet

            Weapon e1 = new Weapon(40, "Andúril.", "The mighty sworn worn and used by Aragorn, son of Arathorn.Forged from the shards of Narsil");
            Weapon e2 = new Weapon(45, "Excalibur.", "The sword of swords, put in the stone by Merlin, pulled out and used by King Arthur of the Britons");
            Weapon e3 = new Weapon(50, "Mjölnir.", "The hammer that always returns to the thrower.Used by the mighty god of Asgárd, Thor.");
            Weapon e4 = new Weapon(55, "Indy’s whip." ,"Well… It’s a whip.BUT, this one was used by Indiana Jones!");
            Weapon e5 = new Weapon(60, "DL - 44 Heavy Blaster Pistol.", "Solo shot first. ‘Nuff said");
            //alle epic våben der laves i spillet

            Weapon l1 = new Weapon(70, "Thunder hammer of the Blood Ravens.", "The mightiest of hammers, harnessing kinetic energy to unleash fatal blows to anything in its way");
            Weapon l2 = new Weapon(80, "Fat Man launcher." ,"You have heard of the A - Bomb ? This “gun” launches one");
            Weapon l3 = new Weapon(90, "Handheld trebuchet.", "Miniature version of the awesome siege weapon of old");
            Weapon l4 = new Weapon(100, "Bladed ligthaber", "A jedi weapon");
            Weapon l5 = new Weapon(250, "Double - bladed lightsaber.","You know what this does");

            JunkWeapons.Add(j1);                    CommonWeapons.Add(c1);                    RareWeapons.Add(r1);
            JunkWeapons.Add(j2);                    CommonWeapons.Add(c2);                    RareWeapons.Add(r2);
            JunkWeapons.Add(j3);                    CommonWeapons.Add(c3);                    RareWeapons.Add(r3);
            JunkWeapons.Add(j4);                    CommonWeapons.Add(c4);                    RareWeapons.Add(r4);
            JunkWeapons.Add(j5);                    CommonWeapons.Add(c5);                    RareWeapons.Add(r5);

                                  EpicWeapons.Add(e1);                  LegendaryWeapons.Add(l1);
                                  EpicWeapons.Add(e2);                  LegendaryWeapons.Add(l2);
                                  EpicWeapons.Add(e3);                  LegendaryWeapons.Add(l3);
                                  EpicWeapons.Add(e4);                  LegendaryWeapons.Add(l4);
                                  EpicWeapons.Add(e5);                  LegendaryWeapons.Add(l5);
                                           
            
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
            else if (r > EpicChance && r <= LegendaryChance)
            {
                Random Legendary = new Random();
                int i = Legendary.Next(0, LegendaryWeapons.Count);
                return LegendaryWeapons[i];
            }
            else
            {
                C.d("Der er gået noget galt, du har ikke fået noget våben");
                return null;
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
