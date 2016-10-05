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
        public string c_MostersHP;
        public string d_MostersAtt;
        public Monster(int Level, string WhatTypeMonster,string MostersHp, string MonstersAtt)

        {
            a_level = Level;
            b_WhatType = WhatTypeMonster;
            c_MostersHP = MostersHp;
            d_MostersAtt = MonstersAtt;
        }
    }
}
