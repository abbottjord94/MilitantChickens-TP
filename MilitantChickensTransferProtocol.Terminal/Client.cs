using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Net;
using MilitantChickensTranferProtocol.Library;

namespace MilitantChickensTransferProtocol.Terminal
{
    class Client
    {
        public static ResponseReader responseReader = null;
        //public static ResponseHeader responseHeader = null;

        public void SendHeader(String server, byte[] header)
        {
            TcpClient client = null;
            Int32 clientPort = 9001;
            BufferedStream stream = null;
            BinaryWriter writer = null;

            try
            {
                client = new TcpClient(server, clientPort);
                stream = new BufferedStream(client.GetStream());
                writer = new BinaryWriter(stream);

                writer.Write(IPAddress.HostToNetworkOrder(header.Length));
                writer.Write(header);

                stream.Flush();
            }
            catch
            {
                Exception e;
            }

        }

        public void HandleResponse(bool isPost)
        {
            
        }

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
                writer.Write(IPAddress.HostToNetworkOrder(messageBytes.Length)); 
                writer.Write(messageBytes);

                responseReader = new ResponseReader(messageBytes);

                //responseReader.header.ClientHandleResponse();

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
