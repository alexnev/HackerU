using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

//Server Side
namespace Lesson24___Server
{
    class Program
    {
        public const int PORT = 80;
        static void Main(string[] args)
        {

            TcpListener tcpListener = null;
            try
            {
                //Set the TCP Listener:
                tcpListener = new TcpListener(PORT);
                tcpListener.Start();

                //we have an infinite loop
                //each client that connects to our server
                //causes an iteration of the loop.
                List<Message> messages = new List<Message>();
                Dictionary<string, User> users =
                    new Dictionary<string, User>();

                while (true)
                {
                    Console.WriteLine("waiting for incoming connection...");
                    //The Accept method blocks until a client is connected.
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Console.WriteLine("client connected");
                    ClientThread clientThread =
                        new ClientThread(tcpClient, messages, users);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Socket Exception: " + ex);
            }
            finally
            {

                if (tcpListener != null)
                    tcpListener.Stop();
            }
        }
    }
}