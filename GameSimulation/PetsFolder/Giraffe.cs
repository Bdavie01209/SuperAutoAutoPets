using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Giraffe : Pets
    {
        public override pets Name => pets.Giraffe;

        public Giraffe(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 2 + att;
        }

        public override void OnTurnEnd(Environment env, int pos)
        {
            int slotstofront = pos - 4;
            int i = 1;
            switch (this.Level())
            {
                case 3:
                    while (i < 4 && slotstofront >= i)
                    {
                        if (env.Team[pos + i] != null)
                        {
                            env.Team[pos + i].Hp += 1;
                            env.Team[pos + i].Attack += 1;
                        }
                        i++;
                    }
                    break;
                case 2:
                    while (i < 3 && slotstofront >= i)
                    {
                        if (env.Team[pos + i] != null)
                        {
                            env.Team[pos + i].Hp += 1;
                            env.Team[pos + i].Attack += 1;
                        }
                        i++;
                    }
                    break;
                default:
                    while (i < 2 && slotstofront >= i)
                    {
                        if (env.Team[pos + i] != null)
                        {
                            env.Team[pos + i].Hp += 1;
                            env.Team[pos + i].Attack += 1;
                        }
                        i++;
                    }
                    break;
            }
        }


    }
}
