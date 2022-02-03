using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    class ZombieCricket : Pets
    {
        public override int Xp { get => xp; set => xp = value; }
        private int xp;
        public override int Hp { get => hp; set => hp = value; }
        private int hp;
        public override int Attack { get => attack; set => attack = value; }
        private int attack;
        public override PetsNames Name { get => PetsNames.ZombieCricket; }

        public ZombieCricket(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 1 + ExtraHp;
            Xp = 0;
        }


        public override Pets clone()
        {
            return new ZombieCricket(0,0);
        }


    }
}
