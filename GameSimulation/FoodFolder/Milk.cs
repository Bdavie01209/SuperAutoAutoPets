using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class Milk : Food
    {
        public override foodNames Name => foodNames.Milk;

        public override void OnConsume(Pets Pet, Environment env, int loc)
        {
            base.OnConsume(Pet, env, loc);
            Pet.Hp += 2;
            Pet.Attack += 1;
            env.gold += 3;
        }

    }
}
