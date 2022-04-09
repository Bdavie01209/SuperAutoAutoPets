using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Spider : Pets
    {
        public override pets Name => pets.Spider;
        private Random rn;

        public Spider(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 2 + att;
            rn = new Random();
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            int scale = 0;
            switch (this.Level())
            {
                case 2:
                    scale = 5;
                    break;
                case 1:
                    scale = 2;
                    break;
                default:
                    scale = 0;
                    break;   
            }
            Pets p = Pets.PetsGen(rn.Next(19, 30),0,0);
            p.Xp = scale;
            p.Hp = 2;
            p.Attack = 2;

            team[pos] = p;


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
