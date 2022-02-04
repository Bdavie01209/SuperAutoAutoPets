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
            bool render = true;
            bool RandTeams = true;
            Environment env = new Environment(selfControl, render, RandTeams);

            Console.ReadKey();

            //Below is the server 

            Server Sock = new Server(1025, "127.0.0.1");

            bool training = true;

            while (training)
            {
                var m = Sock.ReceiveMessage();
                if (m == "REN")
                {
                    env.render = true;
                }
                else
                {
                    Sock.Send355Array(env.processMessage(m));
                }
                
            }
            
        }
    }
}
