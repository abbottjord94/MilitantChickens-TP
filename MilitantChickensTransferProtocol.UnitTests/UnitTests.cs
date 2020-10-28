using MilitantChickensTranferProtocol.Library;
using NUnit.Framework;
using System.Text;
using System;
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
            //Test that the connection to the client is successfully established.
            //This will take place in conjunction with the client's equivalent test.
            Assert.Pass();
        }

        [Test]
        public void SendResponseTest()
        {
            //Test to make sure that responses are successfully sent to the client
            Assert.Pass();
        }

        [Test]
        public void HandleRequestTest()
        {
            //Test to make sure that requests from the client are successfully handled.
            Assert.Pass();
        }

        [Test]
        public void HandleFailureTest()
        {
            //Test to make sure that failures are handled properly; i.e., that the server doesn't crash when a failure occurs.
            Assert.Pass();
        }
        public void SendFileTest()
        {
            //Test to make sure that files are sent properly.
            Assert.Pass();
        }
        public void ReceiveFileTest()
        {
            //Test to make sure that files are being received properly.
            Assert.Pass();
        }
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
            //Test that the connection to the server is successfully established.
            //This will take place in conjunction with the server's equivalent test.
            Assert.Pass();
        }

        [Test]
        public void SendGetRequestTest()
        {
            //Test to make sure that GET requests are successfully sent to the server
            Assert.Pass();
        }
        [Test]
        public void SendPostRequestTest()
        {
            //Test to make sure that POST requests are successfully sent to the server
            Assert.Pass();
        }

        [Test]
        public void HandleResponseTest()
        {
            //Test to make sure that responses from the server are successfully handled.
            Assert.Pass();
        }

        [Test]
        public void HandleFailureTest()
        {
            //Test to make sure that failures are handled properly; i.e., that the client doesn't crash when a failure occurs.
            Assert.Pass();
        }
        public void SendFileTest()
        {
            //Test to make sure that files are sent properly.
            Assert.Pass();
        }
        public void ReceiveFileTest()
        {
            //Test to make sure that files are being received properly.
            Assert.Pass();
        }
    }
}