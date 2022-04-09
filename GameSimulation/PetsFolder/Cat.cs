using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Cat : Pets
    {
        public override pets Name => pets.Cat;

        public Cat(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 4 + att;
        }
    }
}
