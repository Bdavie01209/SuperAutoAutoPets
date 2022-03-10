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

        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            int shots = this.Level() - 1;
            int[] PositionHit = new int[3] { -1, -1, -1 };
            while (shots >= 0)
            {
                bool targetsleft = false;
                for (int i = 0; i < 5; i++)
                {
                    if (enemy[i] != null)
                    {
                        if (!PositionHit.Contains(i))
                        {
                            targetsleft = true;
                        }
                    }
                }
                int hitloc = rn.Next(0, 5);
                if (enemy[hitloc] != null && !PositionHit.Contains(hitloc))
                {
                    enemy[hitloc].OnDamage(1, enemy, team, hitloc);
                    PositionHit[shots] = hitloc;
                    shots -= 1;

                }
                if (!targetsleft)
                {
                    break;
                }
            }
        }



    }
}
