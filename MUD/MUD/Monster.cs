using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
    public class Monster
    {
        public int a_level;
        public string b_WhatType;
        public Monster(int Level, string WhatTypeMonster)

        {
            a_level= Level;
            b_WhatType = WhatTypeMonster;
        }
    }
}
