using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace MilitantChickensTransferProtocol.Terminal
{
    class Client
    {
        public void Connect(String server, String message)
        {
            try
            {
                //Has to be the same as the server
                Int32 clientPort = 9001; 
                TcpClient client = new TcpClient(server, clientPort);


                BufferedStream stream = new BufferedStream(client.GetStream());

                BinaryWriter writer = new BinaryWriter(stream);

                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                writer.Write(IPAddress.HostToNetworkOrder(messageBytes.Length)); //Change 
                writer.Write(messageBytes);

                //stream.Write(msg);

                stream.Flush();
                //Test Connection of Client after Flush
                if (client.Connected)
                {
                    Console.WriteLine("Message Sent from Client (?)");
                }
                else
                {
                    Console.WriteLine("Client is not Connected");
                }


            }
            catch
            {
                Exception e;
            }
        }
    }
}
