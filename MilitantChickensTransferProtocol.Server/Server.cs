using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MilitantChickensTransferProtocol.Server
{
    class Server
    {
        public static int ListenPort = 9001;
        public static TcpListener listener = new TcpListener(IPAddress.Any, ListenPort);
        public static TcpClient client = null;
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

                    int len = reader.ReadInt32();
                    byte[] msg = reader.ReadBytes(len); //Read messages byte length
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(msg));
                    //Handle the server stuff from here
                    /*
                    byte[] array = File.ReadAllBytes(file);
                    writer.Write(array);
                    stream.Flush();
                    */
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}