using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class RequestHeader
    {
        public int requestCode { get; set; }
        public string filePath { get; set; }
        public static BigInteger key { get; set; }
        public RequestHeader()
        {

        }
        public RequestHeader (int _requestCode, string _filePath, BigInteger _key)
        {
            requestCode = _requestCode;
            filePath = _filePath;
            key = _key;
        }
        public virtual byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}\n",
                                             requestCode,
                                             filePath);
            return Encoding.UTF8.GetBytes(rawHeader);
        }

        public virtual void HandleRequest(BinaryWriter _writer, BufferedStream _stream)
        {

        }

        public static byte[] dencrypt(byte[] _msg)
        {
            string k = key.ToString();
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
