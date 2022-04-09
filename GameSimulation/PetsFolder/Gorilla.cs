using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Gorilla : Pets
    {
        public override pets Name => pets.Gorilla;
        int hurtCount = 0;

        public Gorilla(int hp, int att)
        {
            this.Hp = 9 + hp;
            this.Attack = 6 + att;
        }

        public override void OnDamage(int damage, Pets[] team, Pets[] enemy, int loc)
        {
            base.OnDamage(damage, team, enemy, loc);
            if(team[loc] != null)
            {
                if (hurtCount < this.Level())
                {
                    this.Equip = equipment.Melon;
                }
            }
        }


    }
}
