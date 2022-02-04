using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Mosquito : Pets
    {
        private Random rn;
        public override PetsNames Name => PetsNames.Mosquito;

        public Mosquito(int hp, int at)
        {
            rn = new Random();
            this.Hp = 2 + hp;
            this.Attack = 2 + at;
        }

        public override void OnBattleStart(Pets[] team, Pets[] enemy)
        {
            int shots = 1;

            switch (Xp)
            {
                case 5:
                    shots = 3;
                    break;
                case 4:
                case 3:
                case 2:
                    shots = 2;
                    break;
                default:
                    shots = 1;
                    break;
            }
            int[] PostionsHit = new int[3] { -1, -1, -1 };
            while (shots > 0)
            {
                bool targetsleft = false;
                for (int i = 0; i < 5; i++)
                {
                    if (enemy[i] != null)
                    {
                        if (i != PostionsHit[0] && i != PostionsHit[1] && i != PostionsHit[2])
                        {
                            targetsleft = true;
                        }
                    }
                }
                int hitloc = rn.Next(1, 6) - 1;
                if (enemy[hitloc] != null)
                {
                    if (hitloc != PostionsHit[0] && hitloc != PostionsHit[1] && hitloc != PostionsHit[2])
                    {
                        enemy[hitloc].OnDamage(1, enemy, team, hitloc);
                        shots -= 1;
                    }
                }
                if (!targetsleft)
                {
                    break;
                }
            }
        }



    }
}
