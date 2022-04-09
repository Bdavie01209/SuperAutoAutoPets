using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Turtle : Pets
    {
        public override pets Name => pets.Turtle;

        public Turtle(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 1 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            base.Onfaint(team, enemy, pos);
            for(int i = 1; i < this.Level() + 1; i++)
            {
                if (pos - i >= 0)
                {
                    if (team[pos - i] != null)
                    {
                        team[pos - i].Equip = equipment.Melon;
                    }
                }
            }
        }
    }
}
