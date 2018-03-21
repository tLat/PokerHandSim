using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Server).Start();
            Thread.Sleep(500);
            Client();
        }
        static void Client()
        {
            using (TcpClient client = new TcpClient("localhost", 51111))
                while (true)
                {
                    using (NetworkStream n = client.GetStream())
                    {
                        BinaryWriter w = new BinaryWriter(n);
                        w.Write("Hello");
                        w.Flush();
                        Console.WriteLine(new BinaryReader(n).ReadString());
                    }
                }
            
        }
        static void Server()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 51111);
            while (true)
            {
                listener.Start();
                using (TcpClient c = listener.AcceptTcpClient())

                using (NetworkStream n = c.GetStream())
                {

                    string msg = new BinaryReader(n).ReadString();
                    BinaryWriter w = new BinaryWriter(n);
                    w.Write(msg + " right back!");
                    w.Flush();

                }
                listener.Stop();
            }
            
        }
    }

}

