using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Dodo :Pets
    {
        public override pets Name => pets.Dodo;

        public Dodo(int hp, int at)
        {
            this.Hp = 3 + hp;
            this.Attack = 2 + at;
        }

        public override void OnBattleStart(Pets[] team, Pets[] enemy, int pos)
        {
            if (pos < 4) //if it is in the 4th position it cannot have anything in front of it
            {
                if (team[pos + 1] != null) //if the position is null something probably went wrong but perhaps a mosquito killed it
                {
                    double scale = .5;
                    switch (this.Level())
                    {
                        case 3:
                            scale = 1.5;
                            break;
                        case 2:
                            scale = 1;
                            break;
                        default:
                            scale = .5;
                            break;
                    }
                    team[pos + 1].Attack += (int)Math.Floor(this.Attack * scale);
                }
            }
        }
    }
}
