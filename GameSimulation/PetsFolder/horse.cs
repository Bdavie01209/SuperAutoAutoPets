﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class horse : Pets
    {
        public override PetsNames Name => PetsNames.Horse;
        public horse(int bonushp, int bonusatt)
        {
            this.Hp = 1 + bonushp;
            this.Attack = 2 + bonusatt;
        }


    }
}
