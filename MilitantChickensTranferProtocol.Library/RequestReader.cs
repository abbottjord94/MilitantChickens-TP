using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class RequestReader
    {
        public string rawHeader { get; set; }
        public RequestHeader packet { get; set; }
        public RequestReader()
        {

        }
        public RequestReader(byte[] _rawHeader)
        {
            rawHeader = Encoding.UTF8.GetString(_rawHeader);
            string[] dataHeadSplit = rawHeader.Split("\n");
            try
            {
                int reqCode = Int32.Parse(dataHeadSplit[0].Split(":")[1]);
                if (reqCode == 0)
                {
                    packet = new GetRequestHeader();
                }
                if (reqCode == 1)
                {
                    packet = new PostRequestHeader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
