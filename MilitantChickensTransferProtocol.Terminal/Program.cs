using System;
using System.Net.Sockets;
using MilitantChickensTranferProtocol.Library;

namespace MilitantChickensTransferProtocol.Terminal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            //client.Connect("127.0.0.1", "Test Message");
            ClientRequestFactory factory = new ClientRequestFactory();
            RequestHeader header = factory.BuildHeader();
            byte[] requestHeader = header.ReturnRawHeader();
            client.Connect("127.0.0.1", 9001);
            client.SendHeader(requestHeader);
            client.HandleResponse(factory.isPost, factory.filename);
            //Debug Termination of Client -- TEMP DEBUG CODE
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            
        }
    }
}
