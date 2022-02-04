using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Otter : Pets
    {
        public override PetsNames Name => PetsNames.Otter;

        public Otter(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 1 + att;
        }

        public override void onBought(Environment env, int pos)
        {
            if (env.Team[pos] != null)
            {
                env.Team[pos].XpUp(env, pos);
                for (int i = 0; i < 5; i++)
                {
                    if (i != pos && env.Team[i] != null)
                    {
                        switch (this.Level())
                        {
                            case 3:
                                env.Team[i].Attack += 3;
                                env.Team[i].Hp += 3;
                                break;
                            case 2:
                                env.Team[i].Attack += 2;
                                env.Team[i].Hp += 2;
                                break;
                            default:
                                env.Team[i].Attack += 1;
                                env.Team[i].Hp += 1;
                                break;
                        }
                    }
                }
            }
            else
            {
                env.Team[pos] = this;
                for (int i = 0; i < 5; i++)
                {
                    if (i != pos && env.Team[i] != null)
                    {
                        env.Team[i].Attack += 1;
                        env.Team[i].Hp += 1;
                    }
                }
            }
        }


        public override Pets clone()
        {
            Otter pet = new Otter(0,0);
            pet.Attack = this.Attack;
            pet.Hp = this.Hp;
            pet.equip = this.equip;
            return pet;
        }
    }
}
