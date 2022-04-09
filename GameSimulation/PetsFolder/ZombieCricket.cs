﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    class ZombieCricket : Pets
    {
        public override pets Name { get => pets.ZombieCricket; }

        public ZombieCricket(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 1 + ExtraHp;
            Xp = 0;
        }
    }
}
