using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using GameSimulation.PetsFolder;
using System.IO;
using System.IO.Pipes;
using GameSimulation.FoodFolder;

namespace GameSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool selfControl = true;
            bool render = false;


            Console.WriteLine("Render? y/n");
            render = Console.ReadKey().ToString().ToUpper() == "Y";

            Console.WriteLine("SelfControl? y/n");
            selfControl = Console.ReadKey().ToString().ToUpper() == "Y";


            Environment env = new Environment(selfControl, render);

            Console.ReadKey();

            //Below is the server 

            Server Sock = new Server(1025, "127.0.0.1");

            Console.ReadKey();

            Server guiSock = new Server(9012, "127.0.0.1");
            Controller Con = new Controller(env, Sock, guiSock);

            if (!selfControl)
            {
                env.AddDelegates(Con.SendActionToGui,Con.DeterminWin,Con.ReRoll);
            }
            else
            {
                guiSock.SendMessage("CLO");
            }

            while(true)
            {
                Con.Interact();
            }
            
        }
    }
}
