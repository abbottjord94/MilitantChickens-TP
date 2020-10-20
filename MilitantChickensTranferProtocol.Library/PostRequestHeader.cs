using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class PostRequestHeader : RequestHeader
    {
        byte[] data { get; set; }
        PostRequestHeader(string _filePath, byte[] _data)
        {
            requestCode = 1;
            filePath = _filePath;
            data = _data;
        }
    }
}
