using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Cricket : Pets
    {
        public override pets Name { get => pets.Cricket; }

        public Cricket(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 2 + ExtraHp;
            Xp = 0;
        }


        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
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
            if (this.Equip == equipment.honey)
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


    }
}
