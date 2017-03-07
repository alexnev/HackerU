using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lesson23S
{
    class Program
    {
        static void Main(string[] args)
        {
            //There is a limited number(short, 65535) of ports, it's recommended that your custom ports will be above 1000
            //  since all port numbers below 1000 are used by common protocols (http, tcp, ftp etc.)
            //A disadvantage of using these custom ports is that most firewall programs block these high-numbered ports
            TcpListener listener = new TcpListener(3000);
            //It's very important to close open connections such as listener and socket when the application is done.
            listener.Start();
            while (true)
            {
                Console.WriteLine("wainting for incoming connection");
                //.acceptSocket() and .Recieve() are blocking methods, they block the rest of the code until they are intiialized.
                Socket socket = listener.AcceptSocket();
                Console.WriteLine("client connected");
                byte[] buffer = new byte[1024];
                StringBuilder sb = new StringBuilder();
                int actuallyRead;
                do
                {
                    actuallyRead = socket.Receive(buffer);
                    string s = new UTF8Encoding().GetString(buffer, 0, actuallyRead);
                    sb.Append(s);
                } while (actuallyRead == buffer.Length);
                Console.WriteLine(sb);

                socket.Receive(buffer);
                string responseString = "thank you";
                byte[] responseBytes = new UTF8Encoding().GetBytes(responseString);
                socket.Send(responseBytes);
                socket.Close();
            }
            listener.Stop();
        }
    }
}
