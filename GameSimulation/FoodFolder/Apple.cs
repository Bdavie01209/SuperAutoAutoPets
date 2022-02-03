using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class Apple : Food
    {
        public override foodNames Name { get => foodNames.apple; }

        public override void OnConsume(Pets Pet, Environment env)
        {
            Pet.Attack++;
            Pet.Hp++;
        }
    }
}
