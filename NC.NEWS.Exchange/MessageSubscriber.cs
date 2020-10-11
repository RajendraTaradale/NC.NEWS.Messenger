using System;

namespace NC.NEWS.Exchange
{
    public class MessageSubscriber
    {

        public string SubscriberName { get; private set; }

        public string SubscriberCategory { get; private set; }

        public MessageSubscriber(string _subscriberName, string _subscriberCategory = "all")
        {
            SubscriberName = _subscriberName;
            SubscriberCategory = _subscriberCategory;
        }

        public void Subscribe(MessagePublisher p)
        {
            p.OnPublish += OnNotificationReceived;
        }

        public void Unsubscribe(MessagePublisher p)
        {
            p.OnPublish -= OnNotificationReceived;
        }

        protected virtual void OnNotificationReceived(MessagePublisher p, MessageEvent e)
        {
            if (SubscriberCategory == "all")
            {
                Console.WriteLine("Hey " + SubscriberName + " - " + e.NotificationMessage + " - " + p.PublisherName + "(" + SubscriberCategory + ")" + " at " + e.NotificationDate);
            }
            Console.WriteLine("Hey " + SubscriberName + " - " + e.NotificationMessage + " - " + p.PublisherName + "(" + SubscriberCategory + ")" + " at " + e.NotificationDate);
        }
    }
}
