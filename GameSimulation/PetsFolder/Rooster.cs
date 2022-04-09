using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Rooster : Pets
    {
        public override pets Name => pets.Rooster;

        public Rooster(int hp, int att)
        {
            this.Hp = 3 + hp;
            this.Attack = 5 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            base.Onfaint(team, enemy, pos);

            for(int i = 0; i < this.Level(); i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (team[x] == null)
                    {
                        team[x] = new ZombieCricket(0, this.Attack / 2);
                        break;
                    }
                }
            }


        }

    }
}
