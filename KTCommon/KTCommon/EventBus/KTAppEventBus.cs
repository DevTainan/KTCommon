using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// 通知管理員
    /// </summary>
    internal class KTAppEventBusManager
    {
        private static KTAppEventBusManager instance = null;
        private static readonly object padlock = new object();

        private KTAppEventBusManager()
        {
            Initial();
        }

        private void Initial()
        {
            lstObservers = new Dictionary<string, IObserver>();
        }

        public static KTAppEventBusManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new KTAppEventBusManager();
                        }
                    }
                }
                return instance;
            }
        }

        Dictionary<string, IObserver> lstObservers; // 使用List來存放觀察者名單

        /// <summary>
        /// 訂閱
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pObserver"></param>
        public void Subscribe(string id, IObserver pObserver)
        {
            lstObservers.Add(id, pObserver);
        }

        /// <summary>
        /// 取消訂閱
        /// </summary>
        /// <param name="id"></param>
        public void Unsubscribe(string id)
        {
            if (lstObservers.ContainsKey(id))
            {
                lstObservers.Remove(id);
            }
        }

        /// <summary>
        /// 發送新消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="messageId"></param>
        /// <param name="messageBody"></param>
        public void Send(string target, string messageId, string messageBody)
        {
            //Console.WriteLine("Send News..");
            NotifyObservers(target, messageId, messageBody);
        }

        /// <summary>
        /// 發送通知給在監聽名單中的觀察者
        /// </summary>
        /// <param name="target"></param>
        /// <param name="messageId"></param>
        /// <param name="messageBody"></param>
        private void NotifyObservers(string target, string messageId, string messageBody)
        {
            foreach (IObserver observer in lstObservers.Values)
            {
                observer.Notify(target, messageId, messageBody);
            }
        }
    }

    /// <summary>
    /// 觀察者介面
    /// </summary>
    public interface IObserver
    {
        void Notify(string target, string messageId, string messageBody);
        event EventHandler<NotifyMessageArgs> MessageReceived;
    }

    /// <summary>
    /// 觀察者
    /// </summary>
    public class KTAppEventBus : IObserver
    {
        public string Id { get; private set; }
        private KTAppEventBusManager cv_AppEventBusManager = KTAppEventBusManager.Instance;
        public event EventHandler<NotifyMessageArgs> MessageReceived;

        /// <summary>
        /// 建構式, 訂閱
        /// </summary>
        public KTAppEventBus()
        {
            Id = Guid.NewGuid().ToString();
            cv_AppEventBusManager.Subscribe(Id, this);
        }

        /// <summary>
        /// 解構式, 取消訂閱
        /// </summary>
        ~KTAppEventBus()
        {
            cv_AppEventBusManager.Unsubscribe(Id);
        }

        /// <summary>
        /// 收到消息 (請使用 Send 方法, 發送消息)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="messageId"></param>
        /// <param name="messageBody"></param>
        /// <remarks>
        /// 這邊是個缺點...居然是公開方法!!
        /// </remarks>
        public void Notify(string target, string messageId, string messageBody)
        {
            if (MessageReceived == null)
            {
                return;
            }

            var arg = new NotifyMessageArgs
            {
                Id = this.Id,
                Target = target,
                MessageId = messageId,
                MessageBody = messageBody,
            };
            MessageReceived(this, arg);
        }

        /// <summary>
        /// 發送新消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="messageId"></param>
        /// <param name="messageBody"></param>
        public void Send(string target, string messageId, string messageBody)
        {
            cv_AppEventBusManager.Send(target, messageId, messageBody);
        }
    }

    public class NotifyMessageArgs : EventArgs
    {
        public string Id { get; set; }
        public string Target { get; set; }
        public string MessageId { get; set; }
        public string MessageBody { get; set; }
    }
}
