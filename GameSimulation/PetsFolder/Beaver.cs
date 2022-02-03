using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Beaver : Pets
    {
        public override int Xp { get => xp; set => xp = value; }
        private int xp;
        public override int Hp { get => hp; set => hp = value; }
        private int hp;
        public override int Attack { get => attack; set => attack = value; }
        private int attack;
        public override PetsNames Name { get => PetsNames.Beaver; }

        public Beaver(int ExtraHp, int ExtraAtt)
        {
            Attack = 2 + ExtraAtt;
            Hp = 2 + ExtraHp;
            Xp = 0;
        }

        public override void onSelfSold(Environment env, int pos)
        {
            env.Team[pos] = null;
            int buffs = 0;
            foreach (Pets p in env.Team)
            {
                if (buffs >= 2)
                {
                    break;
                }
                if (p != null)
                {
                    switch (Xp)
                    {
                        case 5:
                            p.Hp += 3;
                            break;
                        case 4:
                        case 3:
                        case 2:
                            p.Hp += 2;
                            break;
                        default:
                            p.Hp += 1;
                            break;
                    }
                    buffs++;
                }
            }
            switch (Xp)
            {
                case 5:
                    env.gold += 3;
                    break;
                case 4:
                case 3:
                case 2:
                    env.gold += 2;
                    break;
                default:
                    env.gold += 1;
                    break;
            }

        }
        public override Pets clone()
        {
            Beaver returnValue = new Beaver(0, 0);
            returnValue.Attack = this.Attack;
            returnValue.Hp = this.Hp;
            returnValue.equip = this.equip;
            returnValue.Xp = this.xp;
            return returnValue;
        }

    }
}

