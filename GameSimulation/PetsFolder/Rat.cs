using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Rat : Pets
    {
        public override PetsNames Name => PetsNames.Rat;

        public Rat(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 4 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            base.Onfaint(team, enemy, pos);
            int rats = this.Level();
            for (int i = 4; i >= 0; i--)
            {
                if (enemy[i] == null)
                {
                    enemy[i] = new ZombieCricket(0,0);
                    if (rats == 0)
                    {
                        i -= 50;
                    }
                }
            }
        }
    }
}
