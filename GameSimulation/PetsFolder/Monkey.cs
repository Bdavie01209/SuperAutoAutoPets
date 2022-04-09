using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Monkey : Pets
    {
        public override pets Name => pets.Monkey;

        public Monkey(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 1 + att;
        }

        public override void OnTurnEnd(Environment env, int pos)
        {
            base.OnTurnEnd(env, pos);

            for (int i = 4; i >= 0; i--)
            {
                if (env.Team[i] != null)
                {
                    env.Team[i].Hp += 3 * this.Level();
                    env.Team[i].Attack += 2 * this.Level();
                }
            }


        }




    }
}
