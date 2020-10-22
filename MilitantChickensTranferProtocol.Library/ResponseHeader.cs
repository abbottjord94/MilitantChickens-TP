using System;
using System.Collections.Generic;
using System.Text;

/*response code needs an int for data/error
byte array for the int

client sends get request, packet with file type and file path

server sends response back (OK and file data in byte aeeay) or(2 error, description in byte array)

write constructor, copy constructor, return raw header code*/

namespace MilitantChickensTranferProtocol.Library
{
    public class ResponseHeader
    {
        public int responseCode { get; set; }
        public string description { get; set; }  // description of file
        public ResponseHeader()
        {

        }
        public ResponseHeader(int _responseCode, string _description)
        {
            responseCode = _responseCode; //arguments
            description = _description; //arguments
        }
        public virtual byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}\n",
                                             responseCode,
                                             description);
            return Encoding.UTF8.GetBytes(rawHeader);
        }
    }
}
