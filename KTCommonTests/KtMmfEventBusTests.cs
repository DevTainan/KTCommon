using ExpectedObjects;
using KTCommon.EventBus;
using KTCommon.Interfaces;
using KTCommon.Structures;
using NUnit.Framework;
using System.Threading;

namespace KTCommonTests
{
    [TestFixture]
    public class KtMmfEventBusTests
    {
        private KtMmfEventBus _event1;
        private bool _isConnected = false;
        private EventBusMessageEventArgs _message = null;
        private ExceptionEventArgs _error = null;

        [SetUp]
        public void SetUp()
        {
            _event1 = new KtMmfEventBus();
            _event1.ConnectionStatus += OnConnectionStatus;
            _event1.MessageReceived += OnMessageReceived;
            _event1.TransactionError += OnTransactionError;
            _event1.SetConnectionInfo(true);
            _event1.Connect();
        }

        [TearDown]
        public void Cleanup()
        {
            _event1.Disconnect();
            _event1.Dispose();
        }

        private void OnConnectionStatus(object sender, ConnectionStatusEventArgs e)
        {
            _isConnected = e.IsConnected;
        }

        private void OnMessageReceived(object sender, EventBusMessageEventArgs e)
        {
            _message = e;
        }

        private void OnTransactionError(object sender, ExceptionEventArgs e)
        {
            _error = e;
        }

        [Test]
        public void IsConnected_ReturnTrue()
        {
            Assert.IsTrue(_isConnected, "KTAppEventBus should be connected.");
        }

        [Test]
        public void Send_ReturnCorrect_Case1()
        {
            string channelId = "channelId";
            string messageId = "messageId";
            string content = "content";


            KtMmfEventBus event2 = new KtMmfEventBus();
            event2.MessageReceived += OnMessageReceived;
            event2.SetConnectionInfo(false);
            event2.Connect();

            _event1.Send(channelId, messageId, content);


            var expected = new EventBusMessageEventArgs(channelId, messageId, content);

            Thread.Sleep(100);

            event2.Disconnect();
            event2.Dispose();

            Assert.AreEqual(expected.ToExpectedObject(), _message);
        }

        [Test]
        public void Send_ReturnCorrect_Case2()
        {
            string channelId = "channelId";
            string messageId = "messageId";
            string content = "content";

            KtMmfEventBus event2 = new KtMmfEventBus();
            event2.SetConnectionInfo(false);
            event2.Connect();

            event2.Send(channelId, messageId, content);

            var expected = new EventBusMessageEventArgs(channelId, messageId, content);

            Thread.Sleep(100);

            event2.Disconnect();
            event2.Dispose();

            Assert.AreEqual(expected.ToExpectedObject(), _message);
        }
    }
}
