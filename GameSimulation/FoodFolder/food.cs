using GameSimulation.FoodFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    public abstract class Food
    {
        public static Food FoodGen(int i)
        {
            return i switch
            {
                15 => new Steak(),
                14 => new Pizza(),
                13 => new Mushroom(),
                12 => new Melon(),

                11 => new Sushi(),
                10 => new Chocolate(),
                9 => new Chili(),

                8 => new Pear(),
                7 => new CannedFood(),

                6 => new SaladBowl(),
                5 => new Garlic(),

                4 => new SleepingPill(),
                3 => new MeatBone(),

                2 => new Cupcake(),
                1 => new Honey(),
                _ => new Apple()
            };
        }
        public abstract foodNames Name { get; }
        public virtual void OnConsume(Pets Pet, Environment env, int loc)
        {
            //base case do nothing
        }

    }
}
