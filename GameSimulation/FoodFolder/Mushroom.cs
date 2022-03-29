using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class Mushroom : Food
    {
        public override foodNames Name => foodNames.Mushroom;

        public override void OnConsume(Pets Pet, Environment env, int loc)
        {
            //
        }

    }
}
