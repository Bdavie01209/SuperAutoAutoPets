using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    class ZombieCricket : Pets
    {
        public override PetsNames Name { get => PetsNames.ZombieCricket; }

        public ZombieCricket(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 1 + ExtraHp;
            Xp = 0;
        }
    }
}
