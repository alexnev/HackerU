using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson24___Server
{
    class ClientThread
    {
        public const int BUFFER_SIZE = 512;
        public const byte ACTION_SEND_MESSAGE = 100;
        public const byte ACTION_GET_MESSAGES = 101;
        public const byte ACTION_SIGNUP = 102;
        public const byte ACTION_LOGIN = 103;
        public const byte OKAY = 90;
        public const byte FAILURE = 91;

        TcpClient tcpClient;
        NetworkStream networkStream;
        List<Message> messages;
        Dictionary<string, User> users;

        public ClientThread(TcpClient tcpClient, List<Message> messages, Dictionary<string, User> users)
        {
            this.tcpClient = tcpClient;
            this.messages = messages;
            this.users = users;
            Thread thread = new Thread(() => {
                try
                {
                    //We get a stream from the client that allows us
                    // to send and receive bytes from the client.
                    networkStream = tcpClient.GetStream();
                    int action =
                        networkStream.ReadByte();


                    switch (action)
                    {
                        case ACTION_SEND_MESSAGE:
                            sendMessage();
                            break;
                        case ACTION_GET_MESSAGES:
                            getMessages();
                            break;
                        case ACTION_SIGNUP:
                            signUp();
                            break;
                        case ACTION_LOGIN:
                            login();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex);
                }
                finally
                {
                    if (networkStream != null)
                        try
                        {
                            networkStream.Close();
                        }
                        catch (Exception ex)
                        {

                        }
                    if (tcpClient != null)
                        try
                        {
                            tcpClient.Close();
                        }
                        catch (Exception ex)
                        {
                        }
                }

            });
            thread.Start();
        }

        public void sendMessage()
        {
            User u = getUser();
            if (u == null)
                return;
            if (!validUser(u))
                return;
            byte[] buffer = new byte[BUFFER_SIZE];
            int actuallyRead = networkStream.Read(buffer, 0, buffer.Length);
            string message = UTF8Encoding.UTF8.GetString(buffer, 0, actuallyRead);
            messages.Add(new Message(message, u.userName));
            networkStream.WriteByte(OKAY);
        }

        public void getMessages()
        {
            User u = getUser();
            if (u == null)
                return;
            if (!validUser(u))
                return;
            byte[] buffer = new byte[BUFFER_SIZE];
            int actuallyRead =
                networkStream.Read(buffer, 0, 4);
            if (actuallyRead != 4)
                return;
            int messagesFrom = BitConverter.ToInt32(buffer, 0);
            int actuallyWrite;
            for (int i = messagesFrom; i < messages.Count; i++)
            {

                Message message = messages[i];
                actuallyWrite = Encoding.UTF8.GetBytes(message.sender,
                    0, message.sender.Length, buffer, 0);
                networkStream.WriteByte((byte)actuallyWrite);
                networkStream.Write(buffer, 0, actuallyWrite);
                //byte[] messageBytes = UTF8Encoding.UTF8.GetBytes(message)
                actuallyWrite = Encoding.UTF8.GetBytes(message.content,
                    0, message.content.Length, buffer, 0);
                networkStream.WriteByte((byte)actuallyWrite);
                networkStream.Write(buffer, 0, actuallyWrite);

            }
        }

        public void signUp()
        {
            User u = getUser();
            if (u == null)
                return;
            bool success = false;
            lock (users)
            {
                if (!users.ContainsKey(u.userName))
                {
                    users.Add(u.userName, u);
                    success = true;
                }
            }
            networkStream.WriteByte(success ? OKAY : FAILURE);

        }

        public void login()
        {
            User u = getUser();
            if (u == null)
                return;
            networkStream.WriteByte(
                validUser(u) ? OKAY : FAILURE);
        }

        public bool validUser(User u)
        {
            if (!users.ContainsKey(u.userName))
                return false;
            User existingUser = users[u.userName];
            return existingUser.password.Equals(u.password);
        }



        public User getUser()
        {
            User user = new User();
            int userNameLength =
                networkStream.ReadByte();
            if (userNameLength < 1)
                return null;
            byte[] userNameBytes = new byte[userNameLength];
            int actuallyRead = networkStream.Read(
                userNameBytes, 0, userNameLength);
            if (actuallyRead != userNameLength)
                return null;
            user.userName =
                Encoding.UTF8.GetString(userNameBytes);
            int passwordLength = networkStream.ReadByte();
            if (passwordLength < 1)
                return null;
            byte[] passwordBytes = new byte[passwordLength];
            actuallyRead = networkStream.Read(
                passwordBytes, 0, passwordLength);
            if (actuallyRead != passwordLength)
                return null;
            user.password = Encoding.UTF8.GetString(
                passwordBytes);
            return user;
        }
    }
}
