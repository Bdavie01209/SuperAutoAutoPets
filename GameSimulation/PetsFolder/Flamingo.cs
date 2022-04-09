using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Flamingo : Pets
    {
        public override pets Name => pets.Flamingo;

        public Flamingo(int hp, int attack)
        {
            this.Hp = 3 + hp;
            this.Attack = 3 + attack;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            if (pos > 1)
            {
                int mod = this.Level();
                if (team[pos - 1] != null)
                {
                    team[pos-1].Hp += mod * 1;
                    team[pos-1].Attack += mod * 1;
                }
                if (team[pos - 2] != null)
                {
                    team[pos - 2].Hp += mod * 1;
                    team[pos - 2].Attack += mod * 1;
                }

            }
            base.Onfaint(team, enemy, pos);
        }
    }
}
