using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class ListRequestHeader : RequestHeader
    {
        public ListRequestHeader()
        {

        }
        public ListRequestHeader(string _filePath)
        {
            requestCode = 4;
            filePath = _filePath;
        }
        public override byte[] ReturnRawHeader()
        {
            string rawHeader = string.Format("Code:{0}\nPath:{1}\n",
                                             requestCode,
                                             filePath);
            return Encoding.UTF8.GetBytes(rawHeader);
        }

        public override void HandleRequest(BinaryWriter _writer, BufferedStream _stream)
        {
            try
            {
                string completePath = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, filePath);
                string[] filesInDir = Directory.GetFiles(completePath);
                string[] directories = Directory.GetDirectories(completePath);
                int numDirs = filesInDir.Length;
                int numFiles = directories.Length;
                string data = numDirs.ToString() + ";" + numFiles.ToString() + ";";
                foreach (string dir in directories)
                {
                    data = data + dir + ",";
                }
                foreach (string file in filesInDir)
                {
                    data = data + file + ",";
                }
                data.Remove(data.Length - 1);
                string descriptionString = "List wrote successfully: ";
                ResponseHeader response = new ResponseHeader(4, Encoding.UTF8.GetBytes(data));
                response.Send(_writer, _stream);
                Console.WriteLine(descriptionString);
            }
            catch(Exception e)
            {
                string descriptionString = "List wrote unsuccessfully: ";
                ResponseHeader response = new ResponseHeader(4, Encoding.UTF8.GetBytes(descriptionString));
                response.Send(_writer, _stream);
                Console.WriteLine(descriptionString);
                Console.WriteLine(e);
            }
        }
    }
}
