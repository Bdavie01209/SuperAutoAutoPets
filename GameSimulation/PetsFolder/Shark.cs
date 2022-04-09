using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Shark : Pets
    {
        public override pets Name => pets.Shark;

        public Shark(int hp, int att)
        {
            this.Hp = 4 + hp;
            this.Attack = 4 + att;
        }

        public override void OnFriendAheadFaints(Pets[] team, Pets[] enemy, int loc)
        {
            base.OnFriendAheadFaints(team, enemy, loc);

            this.Hp += this.Level();
            this.Attack += 2 * this.Level();
        }
    }
}
