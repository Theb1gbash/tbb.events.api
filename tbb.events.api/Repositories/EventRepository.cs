using Dapper;
using tbb.events.api.Interfaces;
using tbb.events.api.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace tbb.events.api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly string _connectionString;

        public EventRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<Events> GetEventDetails(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Events WHERE EventId = @EventId";
                return await connection.QueryFirstOrDefaultAsync<Events>(query, new { EventId = eventId });
            }
        }

        public async Task<EventDescription> GetEventDescription(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM EventDescription WHERE EventId = @EventId";
                return await connection.QueryFirstOrDefaultAsync<EventDescription>(query, new { EventId = eventId });
            }
        }

        public async Task<IEnumerable<TicketInfo>> GetTicketingInformation(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM TicketInfo WHERE EventId = @EventId";
                return await connection.QueryAsync<TicketInfo>(query, new { EventId = eventId });
            }
        }

        public async Task<IEnumerable<Image>> GetImageGallery(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Image WHERE EventId = @EventId";
                return await connection.QueryAsync<Image>(query, new { EventId = eventId });
            }
        }

        public async Task<Organizer> GetOrganizerInformation(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Organizer WHERE EventId = @EventId";
                return await connection.QueryFirstOrDefaultAsync<Organizer>(query, new { EventId = eventId });
            }
        }

        public async Task<Location> GetLocationInformation(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM Location WHERE EventId = @EventId";
                return await connection.QueryFirstOrDefaultAsync<Location>(query, new { EventId = eventId });
            }
        }

        public async Task<SocialShare> GetSocialSharingData(int eventId)
        {
            using (var connection = CreateConnection())
            {
                string query = "SELECT * FROM SocialShare WHERE EventId = @EventId";
                return await connection.QueryFirstOrDefaultAsync<SocialShare>(query, new { EventId = eventId });
            }
        }
    }
}
