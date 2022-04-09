using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Badger : Pets
    {
        public override pets Name => pets.Badger;

        public Badger(int hp, int att)
        {
            this.Hp = hp + 4;
            this.Attack = att + 5;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            int scale = this.Level();
            team[pos] = null;
            if (pos == 4)
            {
                if (enemy[4] != null)
                {
                    enemy[4].OnDamage(scale * this.Attack, enemy, team, 4);
                }
                if (team[3] != null)
                {
                    team[3].OnDamage(scale * this.Attack, team, enemy, 3);
                }
            }
            else
            {
                if (team[pos + 1] != null)
                {
                    team[pos + 1].OnDamage(scale * this.Attack, team, enemy, pos + 1);
                }
                if (pos != 0 && team[pos -1] != null)
                {
                    team[pos - 1].OnDamage(scale * this.Attack, team, enemy, pos - 1);
                }
            }

            team[pos] = this;
            base.Onfaint(team, enemy, pos);
        }
    }
}
