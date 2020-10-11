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
    public class ChannelOnboardingController : ControllerBase
    {
        // GET: api/<NewsOnboardingController>
        private ApplicationDbContext _context;

        public ChannelOnboardingController(ApplicationDbContext context)
        {

            _context = context;
            if (!_context.channelOnboard.Any())
            {
                _context.channelOnboard.Add(new ChannelOnboard
                { sourceName = "NC.News.Communications" });

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<ChannelOnboard> Get()
        {
            return _context.channelOnboard;
        }

      
        // POST api/<NewsOnboardingController>
        [HttpPost]
        public string Post([FromBody] ChannelOnboard channelOnboard)
        {
            _context.channelOnboard.Add(channelOnboard);
            _context.SaveChanges();

            return channelOnboard.sourceName;
        }
    }
}
