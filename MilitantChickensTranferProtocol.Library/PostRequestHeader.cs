using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class PostRequestHeader : RequestHeader
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
            Console.WriteLine("POST Request Received: {0}", filePath);

        }
        public override byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}\nData:{2}",
                                             requestCode,
                                             filePath,
                                             data);
            return Encoding.UTF8.GetBytes(rawHeader);
        }

        public override void HandleRequest(BinaryWriter _writer, BufferedStream _stream)
        {
            try
            {
                string completePath = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, filePath);
                if(File.Exists(completePath))
                {
                    //Fail, file already exists.
                    string descriptionString = "File already exists at: " + filePath;
                    ResponseHeader response = new ResponseHeader(2, Encoding.UTF8.GetBytes(descriptionString));
                    response.Send(_writer, _stream, key);
                    Console.WriteLine(descriptionString);

                }
                else
                {
                    //Post the file and send the response.
                    try
                    {
                        File.WriteAllBytes(completePath, data);
                        string descriptionString = "File posted successfully: " + filePath;
                        ResponseHeader response = new ResponseHeader(1, Encoding.UTF8.GetBytes(descriptionString));
                        response.Send(_writer, _stream, key);
                        Console.WriteLine(descriptionString);

                    }
                    catch (Exception e)
                    {
                        string descriptionString = "File did not post successfully: " + filePath + ": " + e;
                        ResponseHeader response = new ResponseHeader(2, Encoding.UTF8.GetBytes(descriptionString));
                        response.Send(_writer, _stream, key);
                        Console.WriteLine(descriptionString);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
