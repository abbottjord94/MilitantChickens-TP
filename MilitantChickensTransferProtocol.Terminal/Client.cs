using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Net;
using MilitantChickensTranferProtocol.Library;

namespace MilitantChickensTransferProtocol.Terminal
{
    public class Client
    {
        public TcpClient client = null;
        public BinaryReader reader = null;
        public BinaryWriter writer = null;
        public BufferedStream stream = null;
        public Int32 clientPort = 9001;
        public static ResponseReader responseReader = null;
        public string server;
        public bool connected = false;
        public string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
        //public static ResponseHeader responseHeader = null;

        public Client()
        {

        }

        public Client(string _server)
        {
            server = _server;
        }

        public void SendHeader(byte[] header)
        {

            try
            {

                /*
                client = new TcpClient(server, clientPort);
                stream = new BufferedStream(client.GetStream());
                writer = new BinaryWriter(stream);
                */
                if (connected)
                {
                    writer.Write(IPAddress.HostToNetworkOrder(header.Length));
                    writer.Write(header);

                    stream.Flush();
                } else
                {
                    Connect(server, clientPort);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void HandleResponse(bool isPost, string filename)
        {
            try
            {
                int len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                byte[] msg = reader.ReadBytes(len);

                ResponseReader responseReader = new ResponseReader(msg);

                if (isPost)
                {
                    //Regardless of response code, the behavior is the same if the client sends a POST request:
                    Console.WriteLine(Encoding.UTF8.GetString(responseReader.header.description));
                } else
                {
                    if(responseReader.header.responseCode == 1)
                    {
                        File.WriteAllBytes(Path.Join(basePath, filename), responseReader.header.description);
                    } else if(responseReader.header.responseCode == 2)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(responseReader.header.description));
                    } else
                    {
                        Console.WriteLine("Received a different response code than expected");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Connect(String server, Int32 port)
        {
            try
            {
                //Has to be the same as the server
                client = new TcpClient(server, port);
                stream = new BufferedStream(client.GetStream());
                writer = new BinaryWriter(stream);
                reader = new BinaryReader(stream);

                if (client.Connected) connected = true;


            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
