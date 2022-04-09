using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Crocodile : Pets
    {
        public override pets Name => pets.Crocodile;
        private Random rn = new Random();

        public Crocodile(int hp, int att)
        {
            this.Hp = 4 + hp;
            this.Attack = 8 + att;
        }


        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            base.OnBattleStart(team, enemy, pos);
            bool enemyExists = false;
            bool hit = false;
            for (int i = 0; i < 5; i++)
            {
                if (enemy[i] != null)
                {
                    enemyExists = true;
                }
            }
            while (!hit)
            {
                int i = rn.Next(0, 5);
                if (enemy[i] != null)
                {
                    enemy[i].OnDamage(this.Level() * 8, enemy, team, i);
                    hit = true;
                }
            }
            



        }


    }
}
