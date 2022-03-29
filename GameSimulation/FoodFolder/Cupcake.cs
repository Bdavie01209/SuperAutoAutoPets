using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class Cupcake : Food
    {
        public override foodNames Name => foodNames.Cupcake;


        public override void OnConsume(Pets Pet, Environment env, int loc)
        {
            Pet.Cupcake += 1;
            Pet.Attack += 3;
            Pet.Hp += 3;
        }
    }
}
