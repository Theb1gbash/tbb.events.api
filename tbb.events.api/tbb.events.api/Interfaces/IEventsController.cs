using tbb.events.api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace tbb.events.api.Interfaces
{
    public interface IEventsController
    {
        Task<ActionResult<Events>> GetEventDetails(int eventId);
        Task<ActionResult<EventDescription>> GetEventDescription(int eventId);
        Task<ActionResult<IEnumerable<TicketInfo>>> GetTicketingInformation(int eventId);
        Task<ActionResult<IEnumerable<Image>>> GetImageGallery(int eventId);
        Task<ActionResult<Organizer>> GetOrganizerInformation(int eventId);
        Task<ActionResult<Location>> GetLocationInformation(int eventId);
        Task<ActionResult<SocialShare>> GetSocialSharingData(int eventId);
    }
}
