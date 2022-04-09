using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Leopard : Pets
    {
        public override pets Name => pets.Leopard;
        private Random rn = new Random();

        public Leopard(int hp, int att)
        {
            this.Hp = 4 + hp;
            this.Attack = 10 + att;
        }

        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            base.OnBattleStart(team, enemy, pos);
            bool enemyExists = false;
            bool hit = false;
            int hits = 0;
            for (int i = 0; i < 5; i++)
            {
                if(enemy[i] != null)
                {
                    enemyExists = true;
                }
                
            }

            while (!hit && enemyExists && hits < this.Level())
            {
                int can = rn.Next(0, 5);
                if(enemy[can] != null)
                {
                    hit = true;
                    enemy[can].OnDamage(this.Attack / 2, enemy, team, can);
                    enemyExists = false;
                    hits++;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (enemy[i] != null)
                    {
                        enemyExists = true;
                    }

                }
            }

        }

    }
}
