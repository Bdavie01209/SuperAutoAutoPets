﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Fish : Pets
    {
        public override pets Name => pets.Fish;

        public Fish(int bonusH, int BonusX)
        {
            this.Hp = 3 + bonusH;
            this.Attack = 2 + BonusX;
        }

        public override void XpUp(Environment env, int pos)
        {
            base.XpUp(env,  pos);
            int scale = 0;
            switch (Xp)
            {
                case 5:
                    scale = 2;
                    break;
                case 2:
                    scale = 1;
                    break;
                default:
                    scale = 0;
                    break;
            }
            for (int i = 0; i < 5; i++)
            {
                if (i != pos)
                {
                    if (env.Team[i] != null)
                    {
                        env.Team[i].Attack += 1 * scale;
                        env.Team[i].Hp += 1 * scale;
                    }
                }
            }
        }



    }
}
