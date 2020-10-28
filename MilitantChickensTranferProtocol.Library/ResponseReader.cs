using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MilitantChickensTranferProtocol.Library
{
    public class ResponseReader
    {
        public byte[] rawHeader { get; set; }
        public ResponseHeader header { get; set; }
        public ResponseReader()
        {
            //Empty Constructor
        }
        public ResponseReader(byte[] _rawHeader)
        {
            rawHeader = _rawHeader;
            byte respCode = _rawHeader[0];
            byte[] desc = new byte[rawHeader.Length - 1];
            for (int i = 0; i < desc.Length; i++)
            {
                desc[i] = _rawHeader[i + 1];
            }
            header = new ResponseHeader(respCode,desc);

        }

    }
}
