using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Scorpion : Pets
    {
        public override pets Name => pets.Scorpion;


        public Scorpion(int hp, int att)
        {
            this.Hp = 1 + hp;
            this.Attack = 1 + att;
        }

    }
}
