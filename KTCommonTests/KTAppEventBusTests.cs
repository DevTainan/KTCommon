using ExpectedObjects;
using KTCommon.EventBus;
using KTCommon.Interfaces;
using KTCommon.Structures;
using NUnit.Framework;
using System.Threading;

namespace KTCommonTests
{
    [TestFixture]
    public class KTAppEventBusTests
    {
        private KTAppEventBus _event;
        private bool _isConnected = false;
        private EventBusMessageEventArgs _message = null;
        private ExceptionEventArgs _error = null;

        [SetUp]
        public void SetUp()
        {
            _event = KTAppEventBus.Instance;
            _event.ConnectionStatus += OnConnectionStatus;
            _event.MessageReceived += OnMessageReceived;
            _event.TransactionError += OnTransactionError;
            _event.Connect();
        }

        [TearDown]
        public void Cleanup()
        {
            _event.Disconnect();
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
            _event.Send(channelId, messageId, content);

            var expected = new EventBusMessageEventArgs(channelId, messageId, content);

            Thread.Sleep(100);

            Assert.AreEqual(expected.ToExpectedObject(), _message);
        }

        [Test]
        public void Send_ReturnCorrect_Case2()
        {
            string channelId = "channelId";
            string messageId = "messageId";
            string content = "content";

            KTAppEventBus event2 = KTAppEventBus.Instance;
            event2.Send(channelId, messageId, content);

            var expected = new EventBusMessageEventArgs(channelId, messageId, content);

            Thread.Sleep(100);

            Assert.AreEqual(expected.ToExpectedObject(), _message);
        }
    }
}
