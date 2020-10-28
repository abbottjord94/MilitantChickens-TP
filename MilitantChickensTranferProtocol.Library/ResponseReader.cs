using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MilitantChickensTranferProtocol.Library
{
    public class ResponseReader
    {
        public string rawHeader { get; set; }
        public ResponseHeader header { get; set; }
        public ResponseReader()
        {
            //Empty Constructor
        }
        public ResponseReader(byte[] _rawHeader)
        {
            rawHeader = Encoding.UTF8.GetString(_rawHeader);
            Regex reqPattern = new Regex(@"Code:(\d)", RegexOptions.Compiled);
            var reqCode = reqPattern.Match(rawHeader);

            Regex fileData = new Regex(@"Description:(.*)", RegexOptions.Compiled);
            var filedata = reqPattern.Match(rawHeader);

            int respCode = Int32.Parse(reqCode.Groups[1].Value);
            string description = filedata.Groups[1].Value;

            header = new ResponseHeader(respCode, Encoding.UTF8.GetBytes(description));
        }
        
    }
}
