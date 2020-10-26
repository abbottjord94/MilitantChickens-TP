using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class ResponseReader
    {
        public string rawHeader { get; set; }
        public ResponseHeader header { get; set; }
        public ResponseReader()
        {
            //Empty Constructor
        }
        public ResponseReader(byte[] _rawHeader)
        {
            rawHeader = Encoding.UTF8.GetString(_rawHeader);
            string[] dataHeadSplit = rawHeader.Split("\n");
            int respCode = Int32.Parse(dataHeadSplit[0].Split(":")[1]);
            string description = dataHeadSplit[1].Split(":")[1];

            header = new ResponseHeader(respCode, Encoding.UTF8.GetBytes(description));
        }
        
    }
}
