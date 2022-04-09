using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Dragon : Pets
    {
        public override pets Name => pets.Dragon;
        public Dragon(int hp, int att)
        {
            this.Hp = 8 + hp;
            this.Attack = 6 + att;
        }



    }
}
