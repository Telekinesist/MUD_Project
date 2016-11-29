using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUD
{
	[Serializable]
    public class Monster
    {
        public int a_level;
        public string b_WhatType;
        public int c_MostersHP;
        public int d_MostersAtt;
		public bool isSleeping;
        public Monster(int Level, string WhatTypeMonster,int MostersHp, int MonstersAtt, bool sleeping = false)

        {
            a_level = Level; 
            b_WhatType = WhatTypeMonster;
            c_MostersHP = MostersHp;
            d_MostersAtt = MonstersAtt;
			isSleeping = sleeping;
        }
    }
}
