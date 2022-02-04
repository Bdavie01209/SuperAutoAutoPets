using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Pig : Pets
    {
        public override PetsNames Name => PetsNames.Pig;

        public Pig(int hp, int att)
        {
            this.Hp = 1 + hp;
            this.Attack = 3 + att;
        }

        public override void onSelfSold(Environment env, int pos)
        {
            env.Team[pos] = null;
            if (Xp == 5)
            {
                env.gold += 6;
            }
            else if (Xp > 2)
            {
                env.gold += 4;
            }
            else
            {
                env.gold += 2;
            }
        }


        public override Pets clone()
        {
            Pig pet = new Pig(0, 0);
            pet.Attack = this.Attack;
            pet.Hp = this.Hp;
            pet.equip = this.equip;
            return pet;
        }
    }
}
