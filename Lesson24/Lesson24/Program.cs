using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson24
{
    class Program
    {
        public const byte ACTION_SEND_MESSAGE = 100;
        public const byte ACTION_GET_MESSAGES = 101;
        public const byte OKAY = 90;
        public const byte FAILURE = 91;
        public const string SERVER_IP = "127.0.0.1";
        public const int PORT = 80;
        public const byte ACTION_SIGNUP = 102;
        public const byte ACTION_LOGIN = 103;

        static void Main(string[] args)
        {
            int lastMessageReceived = 0;
            bool go = true;
            byte[] userNameAndPasswordBytes = null;

            Thread getMessagesThread = new Thread(() =>
            {
                while (go)
                {
                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch { if (!go) break; }
                    if (userNameAndPasswordBytes == null)
                        continue;
                    byte[] lastMessageReceivedBytes = BitConverter.GetBytes(lastMessageReceived);
                    TcpClient tcpClientGetMessages = null;
                    NetworkStream networkStreamGetMessages = null;
                    try
                    {
                        tcpClientGetMessages = new TcpClient(SERVER_IP, PORT);
                        networkStreamGetMessages = tcpClientGetMessages.GetStream();
                        networkStreamGetMessages.WriteByte(ACTION_GET_MESSAGES);
                        networkStreamGetMessages.Write(userNameAndPasswordBytes, 0, userNameAndPasswordBytes.Length);
                        networkStreamGetMessages.Write(lastMessageReceivedBytes, 0, lastMessageReceivedBytes.Length);//4 bytes
                        int length;
                        byte[] buffer = new byte[256];
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        while ((length = networkStreamGetMessages.ReadByte()) != -1)
                        {
                            int actuallyRead = networkStreamGetMessages.Read(buffer, 0, length);
                            if (actuallyRead != length)
                                continue;
                            string sender = Encoding.UTF8.GetString(buffer, 0, length);
                            length = networkStreamGetMessages.ReadByte();
                            if (length < 1)
                                continue;
                            actuallyRead = networkStreamGetMessages.Read(buffer, 0, length);
                            if (actuallyRead != length)
                                continue;
                            string message = Encoding.UTF8.GetString(buffer, 0, length);
                            lastMessageReceived++;
                            Console.WriteLine(sender + ": " + message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error checking messages: " + ex.Message);
                    }
                    finally
                    {
                        if (networkStreamGetMessages != null)
                            networkStreamGetMessages.Close();
                        if (tcpClientGetMessages != null)
                            tcpClientGetMessages.Close();
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            });

            Console.WriteLine("Welcome to BetterThanWhatsapp Chat.");

            int loginOrSignUp = 0;
            do
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Signup");
                Console.WriteLine("3. Quit");
                string input = Console.ReadLine();
                if (input.Equals("1"))
                    loginOrSignUp = 1;
                else if (input.Equals("2"))
                    loginOrSignUp = 2;
                else if (input.Equals("3"))
                    loginOrSignUp = 3;
                else
                {
                    Console.WriteLine("illegal input");
                    continue;
                }
                break;
            } while (true);
            if (loginOrSignUp == 3)
            {
                go = false;
                getMessagesThread.Interrupt();
                return;
            }


            TcpClient tcpClient = null;
            NetworkStream networkStream = null;
            while (true)
            {
                Console.Write("please enter user name: ");
                string userName = Console.ReadLine();
                Console.Write("please enter password: ");
                string password = Console.ReadLine();
                //TODO: check that userName and password contains at least
                // some characters

                byte[] userNameBytes = Encoding.UTF8.GetBytes(userName);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                userNameAndPasswordBytes = new byte[1 + userName.Length + 1 + passwordBytes.Length];
                userNameAndPasswordBytes[0] = (byte)userNameBytes.Length;
                for (int i = 0; i < userNameBytes.Length; i++)
                {
                    userNameAndPasswordBytes[1 + i] = userNameBytes[i];
                }

                userNameAndPasswordBytes[userNameBytes.Length + 1] = (byte)passwordBytes.Length;
                for (int i = 0; i < passwordBytes.Length; i++)
                {
                    userNameAndPasswordBytes[userNameBytes.Length + 2 + i] =
                        passwordBytes[i];
                }
                try
                {
                    tcpClient = new TcpClient(SERVER_IP, PORT);
                    networkStream = tcpClient.GetStream();
                    networkStream.WriteByte(loginOrSignUp == 1 ? ACTION_LOGIN : ACTION_SIGNUP);
                    networkStream.Write(userNameAndPasswordBytes,
                        0, userNameAndPasswordBytes.Length);
                    int response = networkStream.ReadByte();
                    if (response == OKAY)
                    {
                        break;
                    }
                    else if (response == FAILURE)
                    {
                        Console.WriteLine(loginOrSignUp == 1 ? "login failure" : "signup failure");
                        //TODO: wrap this process in a loop so the user,
                        // can enter username and password again.
                    }
                    else
                    {
                        Console.WriteLine("Illegal response");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("something really bad happened " +
                        ex.Message);
                }
                finally
                {
                    if (networkStream != null)
                        networkStream.Close();
                    if (tcpClient != null)
                        tcpClient.Close();
                }
            }

            getMessagesThread.Start();
            Console.WriteLine("you are now logged in.");
            Console.WriteLine("type in your message and hit enter");
            do
            {
                string input = Console.ReadLine();
                byte[] messageBytes = Encoding.UTF8.GetBytes(input);
                try
                {
                    tcpClient = new TcpClient(SERVER_IP, PORT);
                    networkStream = tcpClient.GetStream();
                    networkStream.WriteByte(ACTION_SEND_MESSAGE);
                    networkStream.Write(userNameAndPasswordBytes, 0, userNameAndPasswordBytes.Length);
                    networkStream.Write(messageBytes, 0, messageBytes.Length);
                    int response = networkStream.ReadByte();
                    if (response == FAILURE)
                        Console.WriteLine("failed to send message");
                    if (input.ToLower() == "quit")
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error " + ex.Message);
                }
                finally
                {
                    if (networkStream != null)
                        networkStream.Close();
                    if (tcpClient != null)
                        tcpClient.Close();
                }

            } while (true);

            go = false;
            getMessagesThread.Interrupt();//takes the thread out of "sleep" state
        }
    }
}