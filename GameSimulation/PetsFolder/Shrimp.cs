﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Shrimp : Pets
    {
        public override pets Name => pets.Shrimp;

        public Shrimp(int hp, int att)
        {
            this.Hp = 3 + hp;
            this.Hp = 3 + att;
        }
    }
}
