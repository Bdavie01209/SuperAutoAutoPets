using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Parrot : Pets
    {
        public override pets Name => pets.Parrot;

        public Parrot(int hp, int att)
        {
            this.Hp = 3 + hp;
            this.Attack = 5 + att;
        }

        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            base.OnBattleStart(team, enemy, pos);

            if (pos < 4)
            {
                if (team[pos + 1] != null)
                {
                    Pets clone = team[pos + 1].Clone();
                    clone.Hp = this.Hp;
                    clone.Attack = this.Attack;
                    clone.Xp = this.Xp;
                    team[pos] = clone;
                }
            }

        }

    }
}
