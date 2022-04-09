using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Bunny : Pets
    {
        public override pets Name => pets.Bunny;

        public Bunny(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 3 + att;
        }

    }
}
