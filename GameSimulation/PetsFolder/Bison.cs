using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Bison : Pets
    {
        public override pets Name => pets.Bison;

        public Bison(int hp, int att)
        {
            this.Hp = 6 + hp;
            this.Attack = 6 + att;
        }

        public override void OnTurnEnd(Environment env, int pos)
        {
            for(int i = 0; i < 5; i++)
            {
                if (env.Team[i] != null)
                {
                    if(env.Team[i].Level() == 3)
                    {
                        this.Hp += 2 * this.Level();
                        this.Attack += 2 * this.Level();
                    }
                }
            }
        }

    }
}
