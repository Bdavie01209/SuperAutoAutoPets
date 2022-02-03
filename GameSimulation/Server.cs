using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;



namespace GameSimulation
{
    public class Server
    {
        string message;
        int bytecount;
        NetworkStream stream;
        byte[] sendData;
        TcpClient client;


        public Server(int conPort, string portname)
        {
            client = new TcpClient(portname, conPort);
            Console.WriteLine("connection made...");
        }

        public void sendMessage(string message)
        {
            bytecount = Encoding.UTF8.GetByteCount(message);
            sendData = new byte[bytecount];
            sendData = Encoding.UTF8.GetBytes(message);
            stream = client.GetStream();
            stream.Write(sendData,0,sendData.Length);
            Console.WriteLine("C# Sent To python");
        }
        public string ReceiveMessage()
        {
            stream = client.GetStream();
            var buffer = new byte[1024];
            int numBytesRead = stream.Read(buffer, 0, buffer.Length);
            if (numBytesRead > 0)
            {
                return Encoding.UTF8.GetString(buffer, 0, numBytesRead);
            }

            return "oopsie woopsie";

        }


    }
}
