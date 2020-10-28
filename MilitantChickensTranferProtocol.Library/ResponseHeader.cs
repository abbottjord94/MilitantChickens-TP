using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Numerics;

/*response code needs an int for data/error
byte array for the int

client sends get request, packet with file type and file path

server sends response back (OK and file data in byte aeeay) or(2 error, description in byte array)

write constructor, copy constructor, return raw header code*/

namespace MilitantChickensTranferProtocol.Library
{
    public class ResponseHeader
    {
        public byte responseCode { get; set; }
        public byte[] description { get; set; }  // description of file
        public ResponseHeader()
        {
        }
        public ResponseHeader(byte _responseCode, byte[] _description)
        {
            responseCode = _responseCode; //arguments
            description = _description; //arguments
        }
        public virtual byte[] ReturnRawHeader()
        {
           byte[] rawheader = new byte[description.Length + 1];
           rawheader[0] = responseCode;
           for(int i=1; i < description.Length+1; i++)
            {
                rawheader[i] = description[i-1];
            }
           return rawheader;
        }

        public void Send(BinaryWriter _writer, BufferedStream _stream, BigInteger _key)
        {
            byte[] payload = dencrypt(ReturnRawHeader(), _key);
            _writer.Write(IPAddress.NetworkToHostOrder(payload.Length));
            _writer.Write(payload);
            _stream.Flush();
        }

        //bool works because Post = 1, Get = 0
        public void ClientHandleResponse(bool isPost)
        {
            if (responseCode == 1)
            {
                
            }
            else if (responseCode == 2)
            {
                //description
            }
        }

        static byte[] dencrypt(byte[] _msg, BigInteger _key)
        {
            string k = _key.ToString();
            byte[] messageBytes = _msg;
            byte[] keyBytes = Encoding.UTF8.GetBytes(k);
            for (int i = 0; i < messageBytes.Length; i++)
            {
                messageBytes[i] ^= keyBytes[i % keyBytes.Length];
            }

            return messageBytes;
        }
    }
}
