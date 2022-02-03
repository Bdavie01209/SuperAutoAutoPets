using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    public abstract class Food
    {
        public abstract foodNames Name { get; }
        public virtual void OnConsume(Pets Pet, Environment env)
        {
            //base case do nothing
        }

    }
}
