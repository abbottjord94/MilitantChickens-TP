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

                    // Since we used class inheritance, we can do this:
                    packet = new GetRequestHeader();
                }
                if (reqCode == 1)
                {
                    //TODO:
                    // Parse Data and add it to constructor.

                    // Since we used class inheritance, we can do this:
                    packet = new PostRequestHeader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
