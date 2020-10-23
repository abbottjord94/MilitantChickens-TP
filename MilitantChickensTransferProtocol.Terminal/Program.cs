using System;

namespace MilitantChickensTransferProtocol.Terminal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Hello World!");
            TcpConnectionClass.testFunction();

            client.Connect("127.0.0.1", "Test Message");

            //Debug Termination of Client -- TEMP DEBUG CODE
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            
        }
    }
}
