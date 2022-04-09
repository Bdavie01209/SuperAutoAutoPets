using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Elephant : Pets
    {
        public override pets Name => pets.Elephant;

        public Elephant(int hp, int at)
        {
            this.Hp = hp + 5;
            this.Attack = 3 + at;
        }

        public override void OnAttack(Pets[] team, Pets[] enemy)
        {
            if (team[3] != null)
            {
                team[3].OnDamage(1, team, enemy, 3);

            }
            if (this.Level() >= 2)
            {
                if(team[2] != null)
                {
                    team[2].OnDamage(1, team, enemy, 2);
                }
            }
            if (this.Level() == 3)
            {
                if(team[1] !=  null)
                {
                    team[1].OnDamage(1, team, enemy, 1);
                }
            }
        }
    }
}
