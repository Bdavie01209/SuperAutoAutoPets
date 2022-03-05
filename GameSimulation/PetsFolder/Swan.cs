using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Swan : Pets
    {
        public override PetsNames Name => PetsNames.Swan;

        public Swan(int hp, int att)
        {
            this.Hp = 3 + hp;
            this.Attack = 1 + att;
        }

        public override void OnTurnStart(Environment env, int pos)
        {
            env.gold += this.Level();
        }

    }
}
