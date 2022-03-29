using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.FoodFolder
{
    public class SaladBowl : Food
    {
        public override foodNames Name => foodNames.SaladBowl;

        private Random rn = new Random(); 

        public override void OnConsume(Pets Pet, Environment env, int loc)
        {
            int numpets = 0;
            for (int i = 0; i < 5; i++)
            {
                if(env.Team[i] != null)
                {
                    numpets += 1;
                }
            }
            if (numpets != 0)
            {
                for (int x = 0; x < 2; x++)
                {
                    int q = rn.Next(0,5);
                    if (env.Team[q] != null)
                    {
                        env.Team[q].Attack += 1;
                        env.Team[q].Hp += 1;
                    }
                }
            }
        }

    }
}
