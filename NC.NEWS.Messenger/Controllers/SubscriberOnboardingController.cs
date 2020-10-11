using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NC.NEWS.Domain;
using NC.NEWS.PersistenceStorage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NC.NEWS.Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberOnboardingController : ControllerBase
    {

        private ApplicationDbContext _context;

        public SubscriberOnboardingController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<SubscriberOnboardingController>
        [HttpGet]
        public IEnumerable<SubscriberOnboard> Get()
        {
            return _context.subscriberOnboard;
        }

        // POST api/<SubscriberOnboardingController>
        [HttpPost("Subscribe")]
        public string Post([FromBody] SubscriberOnboard subscriberOnboard)
        {
            if (subscriberOnboard != null)
            {
                if (_context.channelOnboard.Where(s => s.Id == subscriberOnboard.ChannelId).Any())
                {
                    _context.subscriberOnboard.Add(subscriberOnboard);
                    _context.SaveChanges();
                    return "Subscription Updated Successfully";

                }
                return "Channel does not exist " + subscriberOnboard.ChannelId;
            }
            return "Invalid Request";
        }

        // PUT api/<SubscriberOnboardingController>/5
        [HttpPost("UnSubscribe")]
        public string UnSubscribe([FromBody] SubscriberOnboard subscriberOnboard)
        {
            if (subscriberOnboard != null)
            {
                var unsub = _context.subscriberOnboard.Where(s => s.ChannelId == subscriberOnboard.ChannelId).FirstOrDefault();
                if (unsub != null)
                {
                    _context.subscriberOnboard.Remove(unsub);
                    _context.SaveChanges();
                    return "Un-Subscription Updated Successfully";

                }
                return "Channel does not exist " + subscriberOnboard.ChannelId;
            }
            return "Invalid Request";
        }

    }
}
