using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameSimulation.PetsFolder
{
    public class Ant : Pets
    {
        public override PetsNames Name { get => PetsNames.Ant; }

        public Ant(int ExtraHp, int ExtraAtt)
        {
            Attack = 2 + ExtraAtt;
            Hp = 1 + ExtraHp;
            Xp = 0;
        }

        public override void Onfaint(Pets[] team, Pets[] enemy, int pos)
        {
            team[pos] = null;
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (team[i] != null)
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                return;
            }
            var random = new Random();
            int x = random.Next(1,6) - 1;
            while (team[x] == null)
            {
                x = random.Next(1,6) - 1;
            }
            switch (Xp)
            {
                case 5:
                    team[x].Attack += 6;
                    team[x].Hp += 3;
                    break;
                case 4:
                case 3:
                case 2:
                    team[x].Attack += 4;
                    team[x].Hp += 2;
                    break;
                default:
                    team[x].Attack += 2;
                    team[x].Hp += 1;
                    break;
            }
            base.Onfaint(team, enemy, pos);
        }
    }
}
