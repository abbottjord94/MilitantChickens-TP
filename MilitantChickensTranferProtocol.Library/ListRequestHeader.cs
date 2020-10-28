using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class ListRequestHeader
    {
        public int requestCode { get; set; }
        public string filePath { get; set; }
        public string directories { get; set; }
        public string files { get; set; }
        public ListRequestHeader()
        {

        }
        public ListRequestHeader(string _filePath)
        {
            requestCode = 4;
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
            try
            {
                string completePath = Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, filePath);
                string[] filesInDir = Directory.GetFiles(completePath);
                string[] directories = Directory.GetDirectories(completePath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
