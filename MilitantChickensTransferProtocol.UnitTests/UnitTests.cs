using MilitantChickensTranferProtocol.Library;
using MilitantChickensTransferProtocol.Terminal;
using MilitantChickensTransferProtocol.Server;
using NUnit.Framework;
using System.Text;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MilitantChickensTransferProtocol.UnitTests
{
    public class ServerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void EstablishConnectionTest()
        {
            Client testClient = new Client();
            //RequestHeader testHeader = new GetRequestHeader("cheese.txt");

            testClient.Connect("127.0.0.1", 9001);
            if (testClient.connected) Assert.Pass();
            else Assert.Fail();
            //Test that the connection to the client is successfully established.
            //This will take place in conjunction with the client's equivalent test.
        }

        [Test]
        public void SendResponseTest()
        {
            //Test to make sure that responses are successfully sent to the client

            Client testClient = new Client();
            RequestHeader testHeader = new GetRequestHeader("cheese.txt");
            ResponseHeader testResponse = new ResponseHeader();
            testClient.Connect("127.0.0.1", 9001);
            testClient.SendHeader(testHeader.ReturnRawHeader());
            if (testClient.HandleResponse(false, "cheese.txt") == 0) Assert.Pass();
            else Assert.Fail();
        }

        [Test]
        public void HandleFailureTest()
        {
            Client testClient = new Client();
            RequestHeader testHeader = new RequestHeader(9001, "cheese.txt");
            ResponseHeader testResponse = new ResponseHeader();
            testClient.Connect("127.0.0.1", 9001);
            testClient.SendHeader(testHeader.ReturnRawHeader());
            if (testClient.HandleResponse(false, "cheese.txt") == 0) Assert.Pass();
            else Assert.Fail();
        }
        /*
        public void SendFileTest()
        {
            Assert.Pass();
        }
        public void ReceiveFileTest()
        {
            //Test to make sure that files are being received properly.
            Assert.Pass();
        }
        */
    }

    public class ClientTests
    {
        [SetUp]
        public void SetupTest()
        {

        }
        [Test]
        public void EstablishConnectionTest()
        {
            Client testClient = new Client();
            //RequestHeader testHeader = new GetRequestHeader("cheese.txt");

            testClient.Connect("127.0.0.1", 9001);
            if (testClient.connected) Assert.Pass();
            else Assert.Fail();
            //Test that the connection to the client is successfully established.
            //This will take place in conjunction with the client's equivalent test.
        }

        [Test]
        public void SendGetRequestTest()
        {
            Client testClient = new Client();
            RequestHeader testHeader = new GetRequestHeader("cheese.txt");
            testClient.Connect("127.0.0.1", 9001);
            testClient.SendHeader(testHeader.ReturnRawHeader());
            if (testClient.HandleResponse(false, "cheese.txt") == 0) Assert.Pass();
            else Assert.Fail();
        }
        [Test]
        public void SendPostRequestTest()
        {
            Client testClient = new Client();
            byte[] testFile = File.ReadAllBytes(Path.Join(System.AppDomain.CurrentDomain.BaseDirectory, "cheese.txt"));
            RequestHeader testHeader = new PostRequestHeader("cheese.txt", testFile);
            testClient.Connect("127.0.0.1", 9001);
            testClient.SendHeader(testHeader.ReturnRawHeader());
            if (testClient.HandleResponse(true, "cheese.txt") == 0) Assert.Pass();
            else Assert.Fail();
        }

        [Test]
        public void HandleFailureTest()
        {
            Client testClient = new Client();
            RequestHeader testHeader = new GetRequestHeader("cheese.txt");
            testClient.Connect("127.0.0.1", 9001);
            testClient.SendHeader(testHeader.ReturnRawHeader());
            if (testClient.HandleResponse(false, "cheese.txt") == 0) Assert.Pass();
            else Assert.Fail();
        }
    }
}