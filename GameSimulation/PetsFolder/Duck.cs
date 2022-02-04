using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Duck : Pets
    {
        public override PetsNames Name { get => PetsNames.Duck; }

        public Duck(int ExtraHp, int ExtraAtt)
        {
            Attack = 1 + ExtraAtt;
            Hp = 2 + ExtraHp;
            Xp = 0;
        }

        public override void OnSelfSold(Environment env, int pos)
        {
            env.Team[pos] = null;
            if (Xp == 5)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (env.Petshop[x] != null)
                    {
                        env.Petshop[x].Hp += 3;
                    }
                }
                env.gold += 3;
            }
            else if (Xp > 2)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (env.Petshop[x] != null)
                    {
                        env.Petshop[x].Hp += 2;
                    }
                }
                env.gold += 2;
            }
            else
            {
                for (int x = 0; x < 5; x++)
                {
                    if (env.Petshop[x] != null)
                    {
                        env.Petshop[x].Hp += 1;
                    }
                }
                env.gold += 1;
            }

    }

    }
}
