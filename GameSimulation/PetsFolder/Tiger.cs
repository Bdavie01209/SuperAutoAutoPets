using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Tiger : Pets
    {
        public override pets Name => pets.Tiger;

        public Tiger(int hp, int att)
        {
            this.Hp = 3 + hp;
            this.Attack = 4 + att;
        }
    }
}
