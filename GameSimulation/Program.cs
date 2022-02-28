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
            bool RandTeams = true;
            Environment env = new Environment(selfControl, render, RandTeams);

            /*
            for (int i = 0; i < 10; i++)
            {
                Environment test1 = new Environment(selfControl, true, RandTeams);
                test1.Team[0] = new Mosquito(0,0);
                test1.Team[1] = new Mosquito(0,0);
                test1.Team[2] = new Mosquito(0,0);

                Console.WriteLine(test1.TeamFight(new Pets[5] { new Mosquito(0,0), new Mosquito(0,0), new Mosquito(0,0), null, null}));

            }
            */
            Console.ReadKey();

            //Below is the server 

            Server Sock = new Server(1025, "127.0.0.1");
            Controller Con = new Controller(env, Sock);

            while(true)
            {
                Con.Interact();
            }
            
        }
    }
}
