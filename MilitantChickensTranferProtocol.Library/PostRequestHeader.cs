using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Numerics;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    public class PostRequestHeader : RequestHeader
    {
        public PostRequestHeader()
        {

        }
        public PostRequestHeader(string _filePath, BigInteger _key)
        {
            requestCode = 1;
            filePath = _filePath;
            key = _key;
            Console.WriteLine("POST Request Received: {0}", filePath);

        }
        public override byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}",
                                             requestCode,
                                             filePath);
            return Encoding.UTF8.GetBytes(rawHeader);
        }

        public override void HandleRequest(BinaryWriter _writer, BinaryReader _reader, BufferedStream _stream)
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
                    try
                    {
                        //Send OK response
                        ResponseHeader ok_response = new ResponseHeader(1, Encoding.UTF8.GetBytes("OK"));
                        ok_response.Send(_writer, _stream, key);

                        //Set up the file stream and filePart buffer
                        FileStream fs = new FileStream(completePath, FileMode.CreateNew);
                        byte[] filePart = new byte[1024];

                        //Receive file parts from client
                        int part_len = IPAddress.NetworkToHostOrder(_reader.ReadInt32());
                        byte[] msg = dencrypt(_reader.ReadBytes(part_len));

                        //Check if file part is less than 1024 bytes


                        //If it is, we assume that the file is less than 1024 bytes and just save it

                        if (part_len < 1024)
                        {
                            fs.Write(msg);
                            fs.Flush();
                            fs.Close();
                        }
                        //If it isn't, we assume there's more and enter a loop.

                        else
                        {
                            fs.Write(msg);
                            fs.Flush();
                            while (part_len >= 1024)
                            {
                                part_len = IPAddress.NetworkToHostOrder(_reader.ReadInt32());
                                msg = dencrypt(_reader.ReadBytes(part_len));
                                fs.Write(msg);
                                fs.Flush();
                            }

                            fs.Close();
                        }

                        /*

                        File.WriteAllBytes(completePath, data);
                        string descriptionString = "File posted successfully: " + filePath;
                        ResponseHeader response = new ResponseHeader(1, Encoding.UTF8.GetBytes(descriptionString));
                        response.Send(_writer, _stream, key);
                        Console.WriteLine(descriptionString);

                        */

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
