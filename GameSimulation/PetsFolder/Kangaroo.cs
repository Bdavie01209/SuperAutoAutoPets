using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Kangaroo : Pets
    {
        public override pets Name => pets.Kangaroo;

        public Kangaroo(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 2 + att;
        }
    }
}
