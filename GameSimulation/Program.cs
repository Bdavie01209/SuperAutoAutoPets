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
            Environment env = new Environment(true, false,true);

            env.Team[0] = new Ant(0,0);
            env.Team[1] = new Pig(0,0);
            env.Team[2] = new Ant(0,0);
            env.Team[3] = new Ant(0,0);
            env.Team[4] = new Ant(0,0);
            
            env.Petshop[0] = new horse(0, 0);
            env.Petshop[1] = new horse(0, 0);
            env.Petshop[2] = new horse(0, 0);
            env.Petshop[3] = new horse(0, 0);
            env.Petshop[4] = new horse(0, 0);

            env.foodshop[1] = new Apple();

            Console.ReadKey();

            //Below is the server 

            Server Sock = new Server(1025, "127.0.0.1");


            while (true)
            {
                
            }
            
        }
    }
}
