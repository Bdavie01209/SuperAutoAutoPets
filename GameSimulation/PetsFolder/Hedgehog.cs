using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Hedgehog : Pets
    {
        public override pets Name => pets.Hedgehog;

        public Hedgehog(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 2 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            team[pos] = null;
            int mod = this.Level();
            for (int i = 0; i < 5; i++)
            {
                if (team[i] != null)
                {
                    team[i].OnDamage(mod * 2,team,enemy,i);
                }
                if (enemy[i] != null)
                {
                    enemy[i].OnDamage(mod * 2, enemy, team, i);
                }
            }
            team[pos] = this;
            base.Onfaint(team, enemy, pos);
        }
    }
}
