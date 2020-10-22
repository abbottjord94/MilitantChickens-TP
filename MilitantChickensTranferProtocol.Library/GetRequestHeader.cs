using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class GetRequestHeader : RequestHeader
    {
        public GetRequestHeader(string _filePath)
        {
            requestCode = 0;
            filePath = _filePath;
        }
    }
}
