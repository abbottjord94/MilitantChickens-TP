using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using MilitantChickensTranferProtocol.Library;

namespace MilitantChickensTransferProtocol.Server
{
    class Server
    {
        public static int ListenPort = 9001;
        public static TcpListener listener = new TcpListener(IPAddress.Any, ListenPort);
        public static TcpClient client = null;
        public static RequestReader requestReader = null;
        static void Main(string[] args)
        {
            listener.Start();
            Console.WriteLine("Server listening on port {0}", ListenPort);
            while (true)
            {
                try
                {
                    client = listener.AcceptTcpClient();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                BinaryReader reader = null;
                BinaryWriter writer = null;

                try
                {
                    BufferedStream stream = new BufferedStream(client.GetStream());
                    reader = new BinaryReader(stream);
                    writer = new BinaryWriter(stream);

                    int len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                    byte[] msg = reader.ReadBytes(len); //Read messages byte length

                    //RequestReader's constructor parses the header automatically. 

                    requestReader = new RequestReader(msg);

                    //We can then add a function to each child class of RequestHeader (which is a member of RequestReader) to correctly handle the request.

                    requestReader.packet.HandleRequest(writer, stream);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}