using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MilitantChickensTranferProtocol.Library
{
    public class RequestReader
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
            //string[] dataHeadSplit = rawHeader.Split("\n");
            try
            {
                // Take the Code:<reqcode> and split the code off. Also verify its an int
                // Using try/catch
                Regex reqPattern = new Regex(@"Code:(\d)", RegexOptions.Compiled);
                var reqCode = reqPattern.Match(rawHeader);
                int request = Int32.Parse(reqCode.Groups[1].Value);
                if (request == 0)
                {
                    //TODO:
                    // Parse Data and add it to constructor.
                    Regex pathPattern = new Regex(@"Path:([\/\w\d.]*)", RegexOptions.Compiled);
                    var filePath = pathPattern.Match(rawHeader);
                    // Since we used class inheritance, we can do this:
                    packet = new GetRequestHeader(filePath.Groups[1].Value);
                }
                if (request == 1)
                {
                    //TODO:
                    // Parse Data and add it to constructor.
                    // one string is code : number newline path : path, second string is data sent
                    Regex pathPattern = new Regex(@"Path:([\/\w\d.]*)", RegexOptions.Compiled);
                    var filePath = pathPattern.Match(rawHeader);
                    string path = filePath.Groups[1].Value;

                    Regex fileData = new Regex(@"Data:(.*)", RegexOptions.Singleline);
                    var filedata = fileData.Match(rawHeader);
                    // Since we used class inheritance, we can do this:
                    packet = new PostRequestHeader(path, Encoding.UTF8.GetBytes(filedata.Groups[1].Value));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}