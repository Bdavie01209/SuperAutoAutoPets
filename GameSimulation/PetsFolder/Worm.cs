using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Worm : Pets
    {
        public override pets Name => pets.Worm;

        public Worm(int hp, int att)
        {
            this.Hp = 2 + hp;
            this.Attack = 2 + att;
        }


        public override void OnSelfEat(Environment env, int pos)
        {
            base.OnSelfEat(env, pos);

            this.Hp += this.Level();
            this.Attack += this.Level();
        }

    }
}
