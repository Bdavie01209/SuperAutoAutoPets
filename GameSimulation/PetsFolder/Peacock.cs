using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Peacock : Pets
    {
        public override PetsNames Name => PetsNames.Peacock;

        public Peacock(int hp, int att)
        {
            this.Hp = 5 + hp;
            this.Attack = 2 + att;
        }

        public override void OnDamage(int damage, Pets[] team, Pets[] enemy, int loc)
        {
            base.OnDamage(damage, team, enemy, loc);
            if (team[loc] != null)
            {
                for (int i = 0; i < this.Level(); i++)
                {
                    this.Attack = this.Attack + (this.Attack / 2);
                }
            }
        }

    }
}
