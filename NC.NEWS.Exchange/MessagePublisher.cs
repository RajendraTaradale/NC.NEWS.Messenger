using NC.NEWS.Domain;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NC.NEWS.Exchange
{
    public class MessagePublisher
    {
        List<NotificationQueue> allNotification = new List<NotificationQueue>();
        public string PublisherName { get; private set; }
        public int NotificationInterval { get; private set; }

        public string Category { get; private set; }

        public delegate void Notify(MessagePublisher p, MessageEvent e);

        public event Notify OnPublish;

        public List<NotificationQueue> GetAllNotification()
        {
            return allNotification;
        }

        public MessagePublisher(string _publisherName, int _notificationInterval)
        {
            PublisherName = _publisherName;
            NotificationInterval = _notificationInterval;
        }

        /* publish function publishes a Notification Event */
        public void Publish()
        {
            int i = 0;
            while (true)
            {
                /* Generate the test / publish message as per interval config */
                Thread.Sleep(NotificationInterval);
                if (OnPublish != null)
                {
                    MessageEvent notificationObj = new MessageEvent(DateTime.Now, "New message arrived from");
                    Random random = new Random();
                    var msg = new NotificationQueue { Id = random.Next(), ChannelMessage = ((MessageSubscriber)OnPublish.Target).SubscriberName + " " + ((MessageSubscriber)OnPublish.Target).SubscriberCategory + " " + this.PublisherName + " at " + DateTime.Now.ToString() }; allNotification.Add(msg);
                    allNotification.Add(msg);
                    OnPublish(this, notificationObj);
                }
                Thread.Yield();
                i++;
                if (i == 10) /* for test set count and return */
                {
                    break;
                }
            }
        }
    }
}
