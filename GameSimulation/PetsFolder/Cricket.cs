using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Cricket : Pets
    {
        public override int Xp { get => xp; set => xp = value; }
        private int xp;
        public override int Hp { get => hp; set => hp = value; }
        private int hp;
        public override int Attack { get => attack; set => attack = value; }
        private int attack;
        public override PetsNames Name { get => PetsNames.Cricket; }

        public Cricket(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 2 + ExtraHp;
            Xp = 0;
        }


        public override void onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            switch (Xp)
            {
                case 5:
                    team[pos] = new ZombieCricket(2,2);
                    break;
                case 4:
                case 3:
                case 2:
                    team[pos] = new ZombieCricket(1,1);
                    break;
                default:
                    team[pos] = new ZombieCricket(0,0);
                    break;
            }
            if (this.equip == equipment.honey)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (team[i] == null)
                    {
                        team[i] = new ZombieCricket(0, 0);
                        break;
                    }
                }
            }
        }

        public override Pets clone()
        {
            Cricket returnValue = new Cricket(0, 0);
            returnValue.Attack = this.Attack;
            returnValue.Hp = this.Hp;
            returnValue.equip = this.equip;
            returnValue.Xp = this.xp;
            return returnValue;
        }


    }
}
