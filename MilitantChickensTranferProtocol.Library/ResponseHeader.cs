using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;

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
        public byte[] description { get; set; }  // description of file
        public ResponseHeader()
        {

        }
        public ResponseHeader(int _responseCode, byte[] _description)
        {
            responseCode = _responseCode; //arguments
            description = _description; //arguments
        }
        public virtual byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}\n",
                                             responseCode,
                                             Encoding.UTF8.GetString(description));
            return Encoding.UTF8.GetBytes(rawHeader);
        }

        public void Send(BinaryWriter _writer, BufferedStream _stream)
        {
            byte[] payload = ReturnRawHeader();
            _writer.Write(IPAddress.NetworkToHostOrder(payload.Length));
            _writer.Write(payload);
            _stream.Flush();
        }

        //bool works because Post = 1, Get = 0
        public void ClientHandleResponse(bool isPost)
        {
            if (responseCode == 1)
            {
                
            }
            else if (responseCode == 2)
            {
                //description
            }
        }
    }
}
