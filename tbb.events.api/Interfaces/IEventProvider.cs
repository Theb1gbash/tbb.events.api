using tbb.events.api.Models;

namespace tbb.events.api.Interfaces
{
    public interface IEventProvider
    {
        Task<Events> GetEventDetails(int eventId);
        Task<EventDescription> GetEventDescription(int eventId);
        Task<IEnumerable<TicketInfo>> GetTicketingInformation(int eventId);
        Task<IEnumerable<Image>> GetImageGallery(int eventId);
        Task<Organizer> GetOrganizerInformation(int eventId);
        Task<Location> GetLocationInformation(int eventId);
        Task<SocialShare> GetSocialSharingData(int eventId);
    }
}
