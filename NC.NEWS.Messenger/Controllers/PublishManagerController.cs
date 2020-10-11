using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NC.NEWS.Domain;
using NC.NEWS.Exchange;
using NC.NEWS.Messenger.DistributedCache;
using NC.NEWS.PersistenceStorage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NC.NEWS.Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishManagerController : ControllerBase
    {

        private ApplicationDbContext _context;
        public List<NotificationQueue> notification = null;

        public PublishManagerController(ApplicationDbContext context)
        {
            notification = new List<NotificationQueue>();
            _context = context;
        }

        // GET: api/<PublishManagerController>
        [HttpGet]
        public IEnumerable<NotificationQueue> Get()
        {
            return IntrimData.GetData()?.Distinct()?.Take(8);
        }

        // POST api/<PublishManagerController>
        [HttpPost]
        public void Post([FromBody] PublishConfiguration publishConfiguration)
        {
            foreach (var item in _context.channelOnboard)
            {
                MessagePublisher mp = new MessagePublisher(item.sourceName, publishConfiguration.sourceNotificationInterval);
                var subscriber = _context.subscriberOnboard.Where(s => s.ChannelId == item.Id).FirstOrDefault();
                if (subscriber != null)
                {
                    MessageSubscriber sub1 = new MessageSubscriber(subscriber.SubEmail, subscriber.Category);
                    sub1.Subscribe(mp);
                    mp.Publish();

                    IntrimData.SetData(mp.GetAllNotification());
                    //_context.notificationQueue.AddRange(mp.GetAllNotification());
                    //_context.SaveChanges();
                }
            }
        }
    }
}
