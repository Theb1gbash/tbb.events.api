using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tbb.events.api.Interfaces;
using tbb.events.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace tbb.events.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase,IEventsController
    {
        private readonly IEventProvider _eventProvider;

        public EventsController(IEventProvider eventProvider)
        {
            _eventProvider = eventProvider;
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Events>> GetEventDetails(int eventId)
        {
            var eventDetails = await _eventProvider.GetEventDetails(eventId);
            if (eventDetails == null)
            {
                return NotFound();
            }
            return Ok(eventDetails);
        }

        [HttpGet("{eventId}/description")]
        public async Task<ActionResult<EventDescription>> GetEventDescription(int eventId)
        {
            var eventDescription = await _eventProvider.GetEventDescription(eventId);
            if (eventDescription == null)
            {
                return NotFound();
            }
            return Ok(eventDescription);
        }

        [HttpGet("{eventId}/tickets")]
        public async Task<ActionResult<IEnumerable<TicketInfo>>> GetTicketingInformation(int eventId)
        {
            var ticketingInfo = await _eventProvider.GetTicketingInformation(eventId);
            if (ticketingInfo == null)
            {
                return NotFound();
            }
            return Ok(ticketingInfo);
        }

        [HttpGet("{eventId}/images")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImageGallery(int eventId)
        {
            var images = await _eventProvider.GetImageGallery(eventId);
            if (images == null)
            {
                return NotFound();
            }
            return Ok(images);
        }

        [HttpGet("{eventId}/organizer")]
        public async Task<ActionResult<Organizer>> GetOrganizerInformation(int eventId)
        {
            var organizer = await _eventProvider.GetOrganizerInformation(eventId);
            if (organizer == null)
            {
                return NotFound();
            }
            return Ok(organizer);
        }

        [HttpGet("{eventId}/location")]
        public async Task<ActionResult<Location>> GetLocationInformation(int eventId)
        {
            var location = await _eventProvider.GetLocationInformation(eventId);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpGet("{eventId}/share")]
        public async Task<ActionResult<SocialShare>> GetSocialSharingData(int eventId)
        {
            var socialShare = await _eventProvider.GetSocialSharingData(eventId);
            if (socialShare == null)
            {
                return NotFound();
            }
            return Ok(socialShare);
        }
    }
}
