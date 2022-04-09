using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Hippo : Pets
    {
        public override pets Name => pets.Hippo;

        public Hippo(int hp, int att)
        {
            this.Hp = 7 + hp;
            this.Attack = 4 + att;
        }
    }
}
