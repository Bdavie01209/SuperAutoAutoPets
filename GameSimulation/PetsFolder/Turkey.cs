using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Turkey : Pets
    {
        public override pets Name => pets.Turkey;

        public Turkey(int hp, int att)
        {
            this.Hp = 4 + hp;
            this.Attack = 3 + att;
        }


    }
}
