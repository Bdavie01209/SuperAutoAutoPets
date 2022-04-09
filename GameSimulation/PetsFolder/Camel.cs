using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Camel : Pets
    {
        public override pets Name => pets.Camel;

        public Camel(int extrahp, int extraatt)
        {
            this.Hp = 5 + extrahp;
            this.Attack = 2 + extraatt;
        }

        public override void OnDamage(int damage, Pets[] team, Pets[] enemy, int loc)
        {
            base.OnDamage(damage, team, enemy, loc);

            if(loc > 0)
            {
                if (team[loc - 1] != null)
                {
                    team[loc - 1].Hp += this.Level() * 2;
                    team[loc - 1].Attack += this.Level();
                }
            }
        }

    }
}
