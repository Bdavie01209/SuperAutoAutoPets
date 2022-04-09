using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Deer : Pets
    {
        public override pets Name => pets.Deer;

        public Deer(int hp, int att)
        {
            this.Hp = 1 + hp;
            this.Attack = 1 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            ZombieCricket Bus = new ZombieCricket(1, 1);
            Bus.Attack = 5 * this.Level();
            Bus.Hp = 5 * this.Level();
            Bus.Equip = equipment.Chili;
            base.Onfaint(team, enemy, pos);
            team[pos] = Bus;
        }

    }
}
