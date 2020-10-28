using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class GetRequestHeader : RequestHeader
    {
        public GetRequestHeader()
        {
            requestCode = 0;
        }
        public GetRequestHeader(string _filePath, BigInteger _key)
        {
            requestCode = 0;
            filePath = _filePath;
            key = _key;
            Console.WriteLine("GET Request Received: {0}", filePath);
        }

        public override void HandleRequest(BinaryWriter _writer, BinaryReader _reader, BufferedStream _stream)
        {
            try
            {
                //Join on the server's base directory (we can change this later)
                string completePath = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, filePath);
                if(File.Exists(completePath))
                {
                    //Send the response with the file
                    //byte[] file = File.ReadAllBytes(filePath);
                    
                    byte[] filePart = new byte[1024];
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    long fileSize = fs.Length;
                    if (fileSize < filePart.Length) Array.Resize<byte>(ref filePart, (int)fileSize);
                    while (fs.Read(filePart, 0, filePart.Length) > 0)
                    {
                        //Console.WriteLine(Encoding.UTF8.GetString(filePart));
                        ResponseHeader response = new ResponseHeader(1, filePart);
                        response.Send(_writer, _stream, key);

                        if (fileSize - fs.Position >= filePart.Length) Array.Resize<byte>(ref filePart, 1024);
                        else Array.Resize<byte>(ref filePart, (int)(fileSize - fs.Position));
                    }
                    fs.Close();
                    //I'm gonna make 3 the "end of file" response code.
                    ResponseHeader endResponse = new ResponseHeader(3, Encoding.UTF8.GetBytes("EOF"));
                    endResponse.Send(_writer, _stream, key);
                    Console.WriteLine("File Sent: {0}", filePath);
                }
                else
                {
                    //Send a failure response.
                    string descriptionString = "File not found: " + filePath;
                    ResponseHeader response = new ResponseHeader(2, Encoding.UTF8.GetBytes(descriptionString));
                    response.Send(_writer, _stream, key);
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
