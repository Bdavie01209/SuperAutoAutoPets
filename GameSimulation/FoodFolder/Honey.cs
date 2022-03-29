using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class Honey : Food
    {
        public override foodNames Name => foodNames.honey;

        public Honey()
        {

        }

        public override void OnConsume(Pets Pet, Environment env, int loc)
        {
            if (Pet != null)
            {
                Pet.Equip = equipment.honey;
            }
        }
    }
}
