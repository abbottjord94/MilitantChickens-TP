using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class PostRequestHeader : RequestHeader
    {
        byte[] data { get; set; }
        public PostRequestHeader()
        {

        }
        public PostRequestHeader(string _filePath, byte[] _data)
        {
            requestCode = 1;
            filePath = _filePath;
            data = _data;
        }
        public override byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}\n\n{2}",
                                             requestCode,
                                             filePath,
                                             data);
            return Encoding.UTF8.GetBytes(rawHeader);
        }
    }
}
