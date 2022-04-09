using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Blowfish : Pets
    {
        public override pets Name => pets.Blowfish;
        private Random rn = new Random();

        public Blowfish(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 3 + att;
        }
        public override void OnBought(Environment env, int pos)
        {
            base.OnBought(env, pos);
        }

        public override void OnDamage(int damage, Pets[] team, Pets[] enemy, int loc)
        {
            base.OnDamage(damage, team, enemy, loc);
            if(team[loc] != null)
            {
                bool enemyExists = false;
                bool enemyhit = false;
                for (int i = 0; i < 5; i++)
                {
                    if (enemy[i] != null)
                    {
                        enemyExists = true;
                    }
                }
                while (!enemyhit && enemyExists)
                {
                    int target = rn.Next(0, 5);
                    if (enemy[target] != null)
                    {
                        enemy[target].OnDamage(this.Level() * 2, enemy, team, target);
                        enemyhit = true;
                    }
                }
            }
        }

    }
}
