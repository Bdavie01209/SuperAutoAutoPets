using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Snake : Pets
    {
        public override pets Name => pets.Snake;

        public Snake(int hp, int att)
        {
            this.Hp = 6 + hp;
            this.Attack = 6 + att;
        }

    }
}
