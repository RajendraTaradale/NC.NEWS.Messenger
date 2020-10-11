using NC.NEWS.Domain;
using System.Collections.Generic;
using System.Linq;

namespace NC.NEWS.Messenger.DistributedCache
{
    public class IntrimData
    {
        static List<NotificationQueue> dt = null;
        public IntrimData()
        {
            dt = new List<NotificationQueue>();
        }

        public static void SetData(List<NotificationQueue> lst)
        {
            if (dt != null && dt.Count() > 0)
            {
                dt.AddRange(lst);
            }
            else
            {
                dt = lst;
            }
        }

        public static List<NotificationQueue> GetData()
        {
            return dt;
        }
    }
}
