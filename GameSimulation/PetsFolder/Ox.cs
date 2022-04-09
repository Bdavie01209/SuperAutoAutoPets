using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Ox : Pets
    {
        public override pets Name => pets.Ox;

        public Ox(int hp, int att)
        {
            this.Hp = 4 + hp;
            this.Attack = 4 + att;
        }

        public override void OnFriendAheadFaints(Pets[] team, Pets[] enemy, int loc)
        {
            this.Equip = equipment.Melon;
            this.Attack += this.Level() * 2;
        }



    }
}
