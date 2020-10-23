using System;
using System.Collections.Generic;
using System.Text;

namespace MilitantChickensTranferProtocol.Library
{
    class RequestReader
    {
        public string rawHeader { get; set; }
        public RequestHeader packet { get; set; }
        public RequestReader()
        {

        }
        // Constructor that builds a reader from a byte[], plug and play with server
        public RequestReader(byte[] _rawHeader)
        {
            rawHeader = Encoding.UTF8.GetString(_rawHeader);
            // Separate each line (Goal is to only grab line #1 -- response code
            string[] dataHeadSplit = rawHeader.Split("\n");
            try
            {
                // Take the Code:<reqcode> and split the code off. Also verify its an int
                // Using try/catch
                int reqCode = Int32.Parse(dataHeadSplit[0].Split(":")[1]);
                if (reqCode == 0)
                {
                    //TODO:
                    // Parse Data and add it to constructor.
                    string filePath = dataHeadSplit[1].Split(":")[1];
                    // Since we used class inheritance, we can do this:
                    packet = new GetRequestHeader(filePath);
                }
                if (reqCode == 1)
                {
                    //TODO:
                    // Parse Data and add it to constructor.
                    string[] firstParse = rawHeader.Split("\n\n"); // one string is code : number newline path : path, second string is data sent
                    string[] secondParse = firstParse[0].Split("\n");
                    string data = firstParse[1];
                    string code = secondParse[0].Split(":")[1];
                    string path = secondParse[1].Split(":")[1];
                    
                    // Since we used class inheritance, we can do this:
                    packet = new PostRequestHeader(path, Encoding.UTF8.GetBytes(data));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}