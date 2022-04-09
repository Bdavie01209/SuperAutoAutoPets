using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Seal : Pets
    {
        public override pets Name => pets.Seal;
        private Random rn = new Random();

        public Seal(int hp, int att)
        {
            this.Hp = 8 + hp;
            this.Attack = 3 + att;
        }

        public override void OnSelfEat(Environment env, int pos)
        {
            base.OnSelfEat(env, pos);
            int numhit = 0;
            int numfriends = 0;
            int hitpos = -1;
            for(int i = 0; i < 5; i++)
            {
                if (i != pos && env.Team[i] != null)
                {
                    numfriends += 1;
                }
            }
            while (numfriends > 0 && numhit < 2)
            {
                int canidate = rn.Next(0, 5);
                if (canidate != pos && canidate != hitpos && env.Team[canidate] != null)
                {
                    env.Team[canidate].Hp += this.Level();
                    env.Team[canidate].Attack += this.Level();
                    hitpos = canidate;
                    numfriends--;
                    numhit++;
                }
            }


        }

    }
}
