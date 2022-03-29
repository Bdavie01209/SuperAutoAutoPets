using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class Pear : Food
    {
        public override foodNames Name => foodNames.Pear;

        public override void OnConsume(Pets Pet, Environment env, int loc)
        {
            Pet.Attack += 2;
            Pet.Hp += 2;
        }


    }
}
