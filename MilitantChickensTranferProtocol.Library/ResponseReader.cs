using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace MilitantChickensTranferProtocol.Library
{
    public class ResponseReader
    {
        public byte[] rawHeader { get; set; }
        public ResponseHeader header { get; set; }
        public static BigInteger key { get; set; }
        public ResponseReader()
        {
            //Empty Constructor
        }
        public ResponseReader(byte[] _rawHeader, BigInteger _key)
        {
            key = _key;
            rawHeader = dencrypt(_rawHeader);
            byte respCode = rawHeader[0];
            byte[] desc = new byte[rawHeader.Length - 1];
            for (int i = 0; i < desc.Length; i++)
            {
                desc[i] = rawHeader[i + 1];
            }
            header = new ResponseHeader(respCode,desc);
        }

        static byte[] dencrypt(byte[] msg)
        {
            string k = key.ToString();
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
