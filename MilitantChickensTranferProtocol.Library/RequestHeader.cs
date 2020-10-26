using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class RequestHeader
    {
        public int requestCode { get; set; }
        public string filePath { get; set; }
        public RequestHeader()
        {

        }
        public RequestHeader (int _requestCode, string _filePath)
        {
            requestCode = _requestCode;
            filePath = _filePath;
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

       
    }
}
