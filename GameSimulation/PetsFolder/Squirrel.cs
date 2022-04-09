using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Squirrel : Pets
    {
        public override pets Name => pets.Squirrel;

        public Squirrel(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 2 + att;
        }

    }
}
