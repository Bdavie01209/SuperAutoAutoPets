using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Sheep : Pets
    {
        public override pets Name => pets.Sheep;

        public Sheep(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 2 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            base.Onfaint(team, enemy, pos);

            team[pos] = new ZombieCricket(1, 1);

            for (int i = 0; i < 5; i++)
            {
                if (team[i] == null)
                {
                    team[i] = new ZombieCricket(1, 1);
                    break;
                }
            }

        }

    }
}
