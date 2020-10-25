using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("GET Request Received: {0}", filePath);
        }

        public override void HandleRequest(BinaryWriter _writer, BufferedStream _stream)
        {
            try
            {
                //Join on the server's base directory (we can change this later)
                string completePath = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, filePath);
                if(File.Exists(completePath))
                {
                    //Send the response with the file
                    byte[] file = File.ReadAllBytes(filePath);
                    ResponseHeader response = new ResponseHeader(1, file);
                    response.Send(_writer, _stream);
                    Console.WriteLine("File Sent: {0}", filePath);
                }
                else
                {
                    //Send a failure response.
                    string descriptionString = "File not found: " + filePath;
                    ResponseHeader response = new ResponseHeader(2, Encoding.UTF8.GetBytes(descriptionString));
                    response.Send(_writer, _stream);
                    Console.WriteLine(descriptionString);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
