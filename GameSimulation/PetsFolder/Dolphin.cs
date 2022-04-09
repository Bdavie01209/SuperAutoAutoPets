using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Dolphin : Pets
    {
        public override pets Name => pets.Dolphin;

        public Dolphin(int hp,int att)
        {
            this.Hp = 6 + hp;
            this.Attack = 4 + att;
        }

        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            base.OnBattleStart(team, enemy, pos);
            bool enemyexist = false;
            int lowesthpPos = -1;
            for (int i = 0;i < 5; i++)
            {
                if (enemy[i] != null)
                {
                    enemyexist = true;
                    if (lowesthpPos != -1)
                    {
                        if (enemy[lowesthpPos].Hp > enemy[i].Hp)
                        {
                            lowesthpPos = i;
                        }
                    }
                    else
                    {
                        lowesthpPos = i;
                    }
                }
            }
            if (enemyexist)
            {
                enemy[lowesthpPos].OnDamage(this.Level() * 5, enemy, team, lowesthpPos);
            }




        }

    }
}
