using tbb.events.api.Interfaces;
using tbb.events.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace tbb.events.api.Providers
{
    public class EventProvider : IEventProvider
    {
        private readonly IEventRepository _eventRepository;

        public EventProvider(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<Events> GetEventDetails(int eventId)
        {
            return _eventRepository.GetEventDetails(eventId);
        }

        public Task<EventDescription> GetEventDescription(int eventId)
        {
            return _eventRepository.GetEventDescription(eventId);
        }

        public Task<IEnumerable<TicketInfo>> GetTicketingInformation(int eventId)
        {
            return _eventRepository.GetTicketingInformation(eventId);
        }

        public Task<IEnumerable<Image>> GetImageGallery(int eventId)
        {
            return _eventRepository.GetImageGallery(eventId);
        }

        public Task<Organizer> GetOrganizerInformation(int eventId)
        {
            return _eventRepository.GetOrganizerInformation(eventId);
        }

        public Task<Location> GetLocationInformation(int eventId)
        {
            return _eventRepository.GetLocationInformation(eventId);
        }

        public Task<SocialShare> GetSocialSharingData(int eventId)
        {
            return _eventRepository.GetSocialSharingData(eventId);
        }
    }
}
