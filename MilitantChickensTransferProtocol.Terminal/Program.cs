using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MilitantChickensTransferProtocol.Terminal
{
    class Program
    {

        static void Connect(String server, String message)
        {
            try 
            { 
                Int32 clientPort = 9002;
                TcpClient client = new TcpClient(server, clientPort);


                BufferedStream stream = new BufferedStream(client.GetStream());

                BinaryWriter writer = new BinaryWriter(stream);

                Byte[] msg = System.Text.Encoding.UTF8.GetBytes(message);

                stream.Write(msg);

                stream.Flush();


            }
            catch
            {
                Exception e;
            }
        }

        public static void Main()
        {
            Console.WriteLine("Establishing connection to server");
            try
            {
                Connect("10.0.0.1", "testing client connection");
            }
            catch
            {
                Console.WriteLine("could not establish connection");
            }
            

        }



    }
}
