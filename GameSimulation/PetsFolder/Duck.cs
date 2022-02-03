using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Duck : Pets
    {
        public override int Xp { get => xp; set => xp = value; }
        private int xp;
        public override int Hp { get => hp; set => hp = value; }
        private int hp;
        public override int Attack { get => attack; set => attack = value; }
        private int attack;
        public override PetsNames Name { get => PetsNames.Duck; }

        public Duck(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 2 + ExtraHp;
            Xp = 0;
        }

        public override void onSelfSold(Environment env, int pos)
        {
            env.Team[pos] = null;
            if (Xp == 5)
            {
                foreach (Pets p in env.Petshop)
                {
                    p.Hp += 3;
                }
                env.gold += 3;
            }
            else if (Xp > 2)
            {
                foreach (Pets p in env.Petshop)
                {
                    p.Hp += 2;
                }
                env.gold += 2;
            }
            else
            {
                foreach (Pets p in env.Petshop)
                {
                    p.Hp += 1;
                }
                env.gold += 1;
            }

    }

        public override Pets clone()
        {
            Duck returnValue = new Duck(0, 0);
            returnValue.Attack = this.Attack;
            returnValue.Hp = this.Hp;
            returnValue.equip = this.equip;
            returnValue.Xp = this.xp;
            return returnValue;
        }

    }
}
