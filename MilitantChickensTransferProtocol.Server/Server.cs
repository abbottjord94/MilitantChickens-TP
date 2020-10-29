using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MilitantChickensTranferProtocol.Library;
using System.Numerics;
using System.Security.Cryptography;

namespace MilitantChickensTransferProtocol.Server
{
    public class Server
    {
        public static int ListenPort = 9001;
        public static TcpListener listener = new TcpListener(IPAddress.Any, ListenPort);
        public static TcpClient client = null;
        public static RequestReader requestReader = null;
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory;
        public static bool encryption = false;
        static BigInteger p = BigInteger.Parse("B10B8F96A080E01DDE92DE5EAE5D54EC52C99FBCFB06A3C69A6A9DCA52D23B616073E28675A23D189838EF1E2EE652C013ECB4AEA906112324975C3CD49B83BFACCBDD7D90C4BD7098488E9C219A73724EFFD6FAE5644738FAA31A4FF55BCCC0A151AF5F0DC8B4BD45BF37DF365C1A65E68CFDA76D4DA708DF1FB2BC2E4A4371", System.Globalization.NumberStyles.HexNumber);
        static BigInteger g = BigInteger.Parse("A4D1CBD5C3FD34126765A442EFB99905F8104DD258AC507FD6406CFF14266D31266FEA1E5C41564B777E690F5504F213160217B4B01B886A5E91547F9E2749F4D7FBD7D3B9A92EE1909D0D2263F80A76A6A24C087A091F531DBF0A0169B6A28AD662A4D18E73AFA32D779D5918D08BC8858F4DCEF97C2A24855E6EEB22B3B2E5", System.Globalization.NumberStyles.HexNumber);
        static BigInteger a = generateBigInt();
        static BigInteger generateBigInt()
        {
            byte[] randomBytes = new byte[128];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            randomBytes[randomBytes.Length - 1] &= (byte)0x7F;
            BigInteger key = new BigInteger(randomBytes);
            return key;
        }


        static void Option(string[] args)
        {
            int temp;
            //C:\Users\Edmar\Desktop\Digital
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "--encryption":
                        encryption = true;
                        break;

             

                    case "--root-dir":
                      
                        temp = arg.IndexOf("--root-dir") + 1;
                        
                        path = args[temp];


                        break;
                    case "server.exe":
                        break;
                    

                }

            }
        }
        static void Main(string[] args)
        {
            Option(args);
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

                    int key_len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                    byte[] key_msg = reader.ReadBytes(key_len);
                    BigInteger from_client = BigInteger.Parse(Encoding.UTF8.GetString(key_msg));
                    BigInteger client_key = BigInteger.ModPow(from_client, a, p);
                    Console.WriteLine("Key Generated: 0x{0:x}", client_key);

                    BigInteger send_to_client = BigInteger.ModPow(g, a, p);
                    string client_string = send_to_client.ToString();
                    writer.Write(IPAddress.NetworkToHostOrder(client_string.Length));
                    writer.Write(Encoding.UTF8.GetBytes(client_string));
                    writer.Flush();

                    int len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                    byte[] msg = reader.ReadBytes(len); //Read messages byte length

                    //RequestReader's constructor parses the header automatically. 

                    requestReader = new RequestReader(msg, client_key);

                    //We can then add a function to each child class of RequestHeader (which is a member of RequestReader) to correctly handle the request.
                    try
                    {
                        requestReader.packet.HandleRequest(writer, reader, stream);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        ResponseHeader failResponse = new ResponseHeader(2, Encoding.UTF8.GetBytes("Bad header received"));
                        failResponse.Send(writer, stream, client_key);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}