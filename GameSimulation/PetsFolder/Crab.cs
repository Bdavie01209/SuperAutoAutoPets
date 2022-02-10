using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Crab : Pets
    {
        public override PetsNames Name => PetsNames.Crab;


        public Crab(int hp, int at)
        {
            this.Hp = 3 + hp;
            this.Attack = 3 + at;
        }

        public override void OnBought(Environment env, int pos)
        {
            base.OnBought(env, pos);
            bool teamFound = false;
            for (int i = 0; i < 5; i++)
            {
                if(i != pos) //not the crab
                {
                    if (env.Team[i] != null) //there is a team member there
                    {
                        if (!teamFound)
                        {
                            teamFound = true;
                            this.Hp = env.Team[i].Hp;
                        }
                        else
                        {
                            if (env.Team[i].Hp > this.Hp)
                            {
                                this.Hp = env.Team[i].Hp;
                            }
                        }
                    }
                }
            }
        }


    }

}
