using System;

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
    }
}
