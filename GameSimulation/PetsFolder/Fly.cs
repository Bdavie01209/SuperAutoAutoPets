using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Fly : Pets
    {
        public override pets Name => pets.Fly;

        public Fly(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 5 + att;
        }
    }
}
