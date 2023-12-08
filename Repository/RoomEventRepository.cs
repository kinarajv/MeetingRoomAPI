using Microsoft.EntityFrameworkCore;
using MeetingRoomAPI.Model;
using MeetingRoomAPI.Data;

namespace MeetingRoomAPI.Repositories
{
    public class RoomEventRepository : IRoomEventRepository
    {
        private readonly DataContext _context;

        public RoomEventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomEvent>> GetAllRoomEventsAsync()
        {
            return await _context.RoomEvents.ToListAsync();
        }

        public async Task<RoomEvent> GetRoomEventByIdAsync(int roomEventId)
        {
            return await _context.RoomEvents.FindAsync(roomEventId);
        }

        public async Task<IEnumerable<RoomEvent>> GetRoomEventsByRoomIdAsync(int roomId)
        {
            return await _context.RoomEvents
                .Where(re => re.RoomId == roomId)
                .ToListAsync();
        }

        public async Task AddRoomEventAsync(RoomEvent roomEvent)
        {
            _context.RoomEvents.Add(roomEvent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomEventAsync(RoomEvent roomEvent)
        {
            _context.RoomEvents.Update(roomEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomEventAsync(int roomEventId)
        {
            var roomEvent = await _context.RoomEvents.FindAsync(roomEventId);
            if (roomEvent != null)
            {
                _context.RoomEvents.Remove(roomEvent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
