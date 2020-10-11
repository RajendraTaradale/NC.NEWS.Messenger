using System;
using System.Collections.Generic;
using System.Text;

namespace NC.NEWS.Domain
{
   public class SubscriberOnboard
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public string SubEmail { get; set; }
        public string Category { get; set; }
    }
}
