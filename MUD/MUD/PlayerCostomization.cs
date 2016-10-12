using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    class PlayerCostomization
    {
        public static void CreatePlayer()
        {
            Console.WriteLine("what is your name");
            string name = Console.ReadLine();

            Console.WriteLine("what is your age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("choose you sex betrine a male or female");
            string sex = Console.ReadLine();

            Console.WriteLine("choose your race betrine, orc, elf , dwarf, Or human");

            string race = Console.ReadLine();
            int Hp = 100;
            int att = 10;
            switch (race.ToLower())
            {
                case "orc":
                    Hp = 85;
                    att = 12;
                    break;
                case "elf":
                    Hp = 70;
                    att = 15;
                    break;
                case "dwarf":
                    Hp = 125;
                    att = 7;
                    break;
                case "human":
                    Hp = 100;
                    att = 10;
                    break;
                default:
                    break;
              
                    Player p = new Player(name, age, sex, race);
                
            }

        }
    }
}
