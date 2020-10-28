using MilitantChickensTranferProtocol.Library;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Numerics;

namespace MilitantChickensTransferProtocol.Terminal
{
    public class ClientRequestFactory
    {
        public bool isPost = false;
        public string filename;
        public RequestHeader BuildHeader(BigInteger _key)
        { 
            RequestHeader clientHeader = new RequestHeader();
            int requestCode = -1;
            
            //Loops console output to user until correct GET/POST request type is entered
            while (requestCode == -1) 
            {
                Console.WriteLine("Type GET to download a file and POST to send a file: ");
                string requestType = Console.ReadLine();

                if (requestType == "GET" || requestType == "get")
                {
                    requestCode = 0;
                    //isPost automatically false
                }
                else if (requestType == "POST" || requestType == "post")
                {
                    requestCode = 1;
                    isPost = true;
                }
                else
                {
                    Console.WriteLine("Incorrect request, please enter valid request type...");
                }
            }

            // handles GET requests, builds header with supplied filename
            if (requestCode == 0)
            {
                Console.WriteLine("Please enter the filename you would like to receive:");
                filename = Console.ReadLine();
      
                clientHeader = new GetRequestHeader(filename, _key);
                return clientHeader;
            }

            // handles POST requests - builds header if file exists
            if (requestCode == 1)
            {
                while (true)
                {
                    Console.WriteLine("Please enter the filepath of the file you would like to send:");
                    string filepath = Console.ReadLine();

                    // checks if file exists under given path
                    if (File.Exists(filepath))
                    {
                        byte[] fileData = File.ReadAllBytes(filepath);
                        clientHeader = new PostRequestHeader(filepath, fileData);
                        return clientHeader;
                    }
                    else
                    {
                        Console.WriteLine("File not found, please enter valid filepath...");
                    }
                }
            }

            return clientHeader;

        }

    }
}
