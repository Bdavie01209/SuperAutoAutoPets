using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Mammoth : Pets
    {
        public override pets Name => pets.Mammoth;

        public Mammoth(int hp, int att)
        {
            this.Hp = 10 + hp;
            this.Attack = 3 + att;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            base.Onfaint(team, enemy, pos);

            for (int i = 0; i< 5; i++)
            {
                if(team[i] != null)
                {
                    team[i].Hp += this.Level() * 2;
                    team[i].Attack += this.Level() * 2;
                }
            }

        }

    }
}
