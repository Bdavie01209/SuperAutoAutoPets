using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Skunk : Pets
    {
        public override pets Name => pets.Skunk;

        public Skunk(int hp, int att)
        {
            this.Hp = 6;
            this.Attack = 3 + att;
        }

        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            base.OnBattleStart(team, enemy, pos);

            bool enemies = false;
            int highestHP = -1;
            for (int i = 0; i < 5; i++)
            {
                if (enemy[i] != null)
                {
                    enemies = true;
                    if (highestHP != -1)
                    {
                        if (enemy[highestHP].Hp > enemy[i].Hp)
                        {
                            highestHP = i;
                        }
                    }
                    else
                    {
                        highestHP = i;
                    }
                }
            }
            if (enemies)
            {
                enemy[highestHP].Hp = enemy[highestHP].Hp - (int)Math.Floor(enemy[highestHP].Hp * (.33 * this.Level()));
                if (enemy[highestHP].Hp <= 0)
                {
                    enemy[highestHP].Hp = 1;
                }
            }

        }

    }
}
