using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    public class Controller
    {
        private Environment Environment;
        private Server Server;
        public Controller(Environment env, Server Serv)
        {
            Environment = env;
            Server = Serv;
        }

        public void Interact()
        {
            var m = Server.ReceiveMessage();
            Server.Send355Array(Environment.processMessage(m));
        }
    }
}
