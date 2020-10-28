using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
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
        static BigInteger p = BigInteger.Parse("B10B8F96A080E01DDE92DE5EAE5D54EC52C99FBCFB06A3C69A6A9DCA52D23B616073E28675A23D189838EF1E2EE652C013ECB4AEA906112324975C3CD49B83BFACCBDD7D90C4BD7098488E9C219A73724EFFD6FAE5644738FAA31A4FF55BCCC0A151AF5F0DC8B4BD45BF37DF365C1A65E68CFDA76D4DA708DF1FB2BC2E4A4371", System.Globalization.NumberStyles.HexNumber);
        static BigInteger g = BigInteger.Parse("A4D1CBD5C3FD34126765A442EFB99905F8104DD258AC507FD6406CFF14266D31266FEA1E5C41564B777E690F5504F213160217B4B01B886A5E91547F9E2749F4D7FBD7D3B9A92EE1909D0D2263F80A76A6A24C087A091F531DBF0A0169B6A28AD662A4D18E73AFA32D779D5918D08BC8858F4DCEF97C2A24855E6EEB22B3B2E5", System.Globalization.NumberStyles.HexNumber);
        static BigInteger a = generateBigInt();

        static BigInteger send_to_server = BigInteger.ModPow(g, a, p);
        static string server_string = send_to_server.ToString();

        //final secret key;
        //This is how the NSA cries - Jay
        public static BigInteger s = new BigInteger();
        public BigInteger key;

        public Client()
        {

        }

        public Client(string _server)
        {
            server = _server;
        }

        static BigInteger generateBigInt()
        {
            byte[] randomBytes = new byte[128];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            randomBytes[randomBytes.Length - 1] &= (byte)0x7F;
            BigInteger key = new BigInteger(randomBytes);
            return key;
        }

        public void SendHeader(byte[] header)
        {

            try
            {
                if (connected)
                {
                    header = dencrypt(header);
                    writer.Write(IPAddress.NetworkToHostOrder(header.Length));
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

        public int HandleResponse(bool isPost, string filename)
        {
            try
            {

                if (isPost)
                {
                    //Regardless of response code, the behavior is the same if the client sends a POST request:
                    int len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                    byte[] msg = reader.ReadBytes(len);
                    ResponseReader responseReader = new ResponseReader(msg, s);
                    if (responseReader.header.responseCode == 2)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(responseReader.header.description));
                        return -1;
                    }
                    else if (responseReader.header.responseCode == 1)
                    {
                        FileStream fs = new FileStream(filename, FileMode.Open);
                        long filesize = fs.Length;
                        if (filesize < 1024)
                        {
                            byte[] filePart = new byte[filesize];
                            fs.Read(filePart, 0, (int)filesize);

                            writer.Write(IPAddress.NetworkToHostOrder(filePart.Length));
                            writer.Write(filePart);
                            writer.Flush();
                            return 0;
                        }
                        else
                        {
                            byte[] filePart = new byte[1024];
                            while (fs.Read(filePart, 0, 1024) > 0)
                            {
                                writer.Write(IPAddress.NetworkToHostOrder(filePart.Length));
                                writer.Write(filePart);
                                writer.Flush();
                            }
                            return 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response Received");
                        return -1;
                    }

                 }
                
                else
                {
                    int len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                    byte[] msg = reader.ReadBytes(len);
                    ResponseReader responseReader = new ResponseReader(msg, s);

                    if (responseReader.header.responseCode == 2)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(responseReader.header.description));
                        return 0;
                    }
                    else if (responseReader.header.responseCode == 1)
                    {
                        FileStream fs = new FileStream(filename, FileMode.CreateNew);

                        while (responseReader.header.responseCode != 3)
                        {
                            fs.Write(responseReader.header.description, 0, responseReader.header.description.Length);
                            fs.Flush();
                            len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                            msg = reader.ReadBytes(len);
                            responseReader = new ResponseReader(msg, s);
                        }
                        Console.WriteLine("File Received: {0}", filename);
                        fs.Close();
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Bad response received");
                        return 0;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return -1;
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

                if (client.Connected)
                {
                    writer.Write(IPAddress.NetworkToHostOrder(server_string.Length));
                    writer.Write(Encoding.UTF8.GetBytes(server_string));
                    writer.Flush();

                    int server_key_len = IPAddress.NetworkToHostOrder(reader.ReadInt32());
                    byte[] server_key_msg = reader.ReadBytes(server_key_len);
                    BigInteger server_key = BigInteger.Parse(Encoding.UTF8.GetString(server_key_msg));
                    s = BigInteger.ModPow(server_key, a, p);
                    Console.WriteLine("Key Generated: 0x{0:x}", s);
                    key = s;


                    connected = true;
                }


            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static byte[] dencrypt(byte[] msg)
        {
            string k = s.ToString();
            byte[] messageBytes = msg;
            byte[] keyBytes = Encoding.UTF8.GetBytes(k);
            for (int i = 0; i < messageBytes.Length; i++)
            {
                messageBytes[i] ^= keyBytes[i % keyBytes.Length];
            }

            return messageBytes;
        }
    }
}
