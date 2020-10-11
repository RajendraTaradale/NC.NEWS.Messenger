using System;

namespace NC.NEWS.Exchange
{
    public class MessageEvent
    {
        public string NotificationMessage { get; private set; }

        public DateTime NotificationDate { get; private set; }

        public MessageEvent(DateTime _dateTime, string _message)
        {
            NotificationDate = _dateTime;
            NotificationMessage = _message;
        }
    }
}
