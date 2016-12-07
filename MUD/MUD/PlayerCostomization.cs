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
            Console.WriteLine("what is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("what is your age?");
            bool isReading = true;
            float age = 19;
            while (isReading)
            {
                try
                {
                    age = float.Parse(Console.ReadLine());
                    isReading = false;
                }
                catch
                {
                    Console.WriteLine("Error, please type a number as your age, else you are a FUC**** bastard, and i will find you, and kill you !!! ");
                }
            }

           

            Console.WriteLine("choose your sex between a male or female");
            string sex = Console.ReadLine();

            Console.WriteLine("choose your race between orc, elf , dwarf, Or human");

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
                
            }
            Player.createPlayer(name, age, sex, race, att ,Hp);
            C.l("name", name);
            C.l("age", age.ToString());
            C.l("sex", sex);
            C.l("race", race);
            C.l("Hp",Hp.ToString());
            C.l("damage", att.ToString());
        }
    }
}
