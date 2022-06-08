using KTCommon.Structures;
using System;

namespace KTCommon.Interfaces
{
    public interface IEventBus : IConnect, IDisposable
    {
        event EventHandler<EventBusMessageEventArgs> MessageReceived;
        event EventHandler<ExceptionEventArgs> TransactionError;

        void Send(string channelId, string messageId, string content);
    }

    public class EventBusMessageEventArgs : EventArgs
    {
        public string ChannelId { get; private set; }
        public string MessageId { get; private set; }
        public string Content { get; private set; }

        public EventBusMessageEventArgs(string channelId, string messageId, string content)
        {
            ChannelId = channelId;
            MessageId = messageId;
            Content = content;
        }
    }
}
