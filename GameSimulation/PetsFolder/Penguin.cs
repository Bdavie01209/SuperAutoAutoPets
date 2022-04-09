using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Penguin : Pets
    {
        public override pets Name => pets.Penguin;

        public Penguin(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 1 + att;
        }

        public override void OnTurnEnd(Environment env, int pos)
        {
            base.OnTurnEnd(env, pos);

            for (int i = 0; i <5; i++)
            {
                if (env.Team[i] != null)
                {
                    if (env.Team[i].Level() > 1)
                    {
                        env.Team[i].Hp += this.Level();
                        env.Team[i].Attack += this.Level();
                    }
                }
            }


        }
    }
}
