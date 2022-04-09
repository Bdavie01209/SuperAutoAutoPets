using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Whale : Pets
    {
        public override pets Name => pets.Whale;
        public Pets consumedPet = null;

        public Whale(int hp, int att)
        {
            this.Hp = 8 + hp;
            this.Attack = 3 + att;
        }


        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            base.OnBattleStart(team, enemy, pos);

            if (pos < 4)
            {
                if (team[pos + 1] != null)
                {
                    consumedPet = PetsGen((int)team[pos + 1].Name,0,0);
                    consumedPet.Xp = this.Xp;
                    team[pos + 1].Onfaint(team,enemy,pos + 1);
                }
            }
        }


        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            base.Onfaint(team, enemy, pos);
            if (consumedPet != null)
            {
                team[pos] = consumedPet;
            }
        }



    }
}
