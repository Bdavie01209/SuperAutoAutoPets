using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using GameSimulation.PetsFolder;
using System.IO;
using System.IO.Pipes;


namespace GameSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Environment env = new Environment(true, false,true);
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            env.Buy(0, 0);
            env.Buy(1, 1);
            env.Buy(2, 2);
            env.Buy(3, 3);
            env.Buy(4, 4);


            Pets[] example = new Pets[5];
            example[1] = new horse(0, 0);
            example[2] = new horse(0, 0);
            example[3] = new horse(0, 0);

            Console.WriteLine("fight");

            if (env.TeamFight(example, false) == 1.0)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine("Draw");
            }
            int[,,] array = env.environmenttodata();

            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds + " miliseconds");

            env.renderTeam(env.Team);


            env.Reset();
            */
            Console.ReadKey();
            Server Sock = new Server(1025, "127.0.0.1");
            bool echo = false;


            while (true)
            {
                Thread.Sleep(100);
                string Message = Console.ReadLine();
                if (Message == "echo")
                {
                    echo = !echo;
                }
                Sock.sendMessage(Message);
                if (echo)
                {
                    Console.WriteLine(Sock.ReceiveMessage());
                }
            }
            
        }
    }
}
