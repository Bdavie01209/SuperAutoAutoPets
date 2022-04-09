using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.PetsFolder
{
    public class Boar : Pets
    {
        public override pets Name => pets.Boar;

        public Boar(int hp, int att)
        {
            this.Hp = 6 + hp;
            this.Attack = 8 + att;
        }

        public override void OnAttack(Pets[] team, Pets[] enemy)
        {
            base.OnAttack(team, enemy);
            this.Hp += this.Level() * 2;
            this.Attack += this.Level() * 2;
        }

    }
}
