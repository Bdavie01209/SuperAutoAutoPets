using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Rhino : Pets
    {
        public override pets Name => pets.Rhino;

        public Rhino(int hp, int att)
        {
            this.Hp = 8 + hp;
            this.Attack = 5 + att;
        }
    }
}
