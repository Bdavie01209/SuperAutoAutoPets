using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    public delegate void TakeActionDelegate(string M);
    public delegate double ReceiveWinLossDelegate();
    public delegate string RerollDelegate(bool TS);
    public class Controller
    {
        private Environment Environment;
        private Server ModelServer;
        private Server GUIServer;
        public Controller(Environment env, Server Serv, Server guiServ)
        {
            Environment = env;
            ModelServer = Serv;
            GUIServer = guiServ;
        }

        public void Interact()
        {
            var m = ModelServer.ReceiveMessage();
            ModelServer.Send355Array(Environment.ProcessMessage(m));
        }


        public void SendActionToGui(string M)
        {
            GUIServer.SendMessage(M);
            Console.WriteLine("sening... " + M);
            var l = GUIServer.ReceiveMessage();
            Console.WriteLine("received... " + l);
            if (l == "PAS")
            {
                //do nothing
            }
            else
            {
                Console.WriteLine("OOPSIE WOOPSIE SOMETHINGS WRONG!!!");
                throw new TaskCanceledException();
            }
        }

        public double DeterminWin()
        {
            GUIServer.SendMessage("END");
            var m = GUIServer.ReceiveMessage();
            Console.WriteLine("Received... m");
            if (m.ToUpper() == "W")
            {
                return 1.0;
            }
            else if (m.ToUpper() == "L")
            {
                return -1.0;
            }
            else
            {
                return 0.0;
            }
        }

        public string ReRoll(bool FirstRoll)
        {
            if (!FirstRoll)
            {
                GUIServer.SendMessage("RER");
                Console.WriteLine("sent RER");
            }
            else
            {
                GUIServer.SendMessage("FSU");
                Console.WriteLine("sent FSU");
            }
            var m = GUIServer.ReceiveMessage();
            Console.WriteLine("received... " + m);
            return m;
        }






    }
}
