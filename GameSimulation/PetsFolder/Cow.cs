using GameSimulation.FoodFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Cow : Pets
    {
        public override pets Name => pets.Cow;

        public Cow(int hp, int att)
        {
            this.Hp = 6 + hp;
            this.Attack = 4 + att;
        }

        public override void OnBought(Environment env, int pos)
        {
            base.OnBought(env, pos);

            env.foodshop[0] = new Milk();
            env.foodshop[1] = new Milk();
        }


    }
}
