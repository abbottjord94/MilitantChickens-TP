using MilitantChickensTranferProtocol.Library;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Numerics;

namespace MilitantChickensTransferProtocol.Terminal
{
    public class ClientRequestFactory
    {
        public RequestHeader header = new RequestHeader();

        public void createGetHeader(string _filePath, BigInteger _key)
        {
            header = new GetRequestHeader(_filePath, _key);
        }
    }
}
