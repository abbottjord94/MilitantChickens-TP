using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class GetRequestHeader : RequestHeader
    {
        public GetRequestHeader()
        {
            requestCode = 0;
        }
        public GetRequestHeader(string _filePath)
        {
            requestCode = 0;
            filePath = _filePath;
        }
    }
}
