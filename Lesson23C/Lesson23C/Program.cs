using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lesson23C
{
    class Program
    {
        static void Main(string[] args)
        {
            //It's very important to close open connections such as client and stream when the application is done.
            TcpClient client = new TcpClient("127.0.0.1", 3000);
            NetworkStream stream = client.GetStream();
            String s = "";
            byte[] bytes = new UTF8Encoding().GetBytes(s);
            stream.Write(bytes, 0, bytes.Length);
            byte[] buffer = new byte[1024];
            int actuallyRead = stream.Read(buffer, 0, buffer.Length);
            string responseFromServer = new UTF8Encoding().GetString(buffer, 0, actuallyRead);
            stream.Close();
            client.Close();
        }
    }
}
