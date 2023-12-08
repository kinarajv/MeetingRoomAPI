
using MeetingRoomAPI.Model;

namespace MeetingRoomAPI.Repositories
{
    public interface IRoomEventRepository
    {
        Task<IEnumerable<RoomEvent>> GetAllRoomEventsAsync();
        Task<RoomEvent> GetRoomEventByIdAsync(int roomEventId);
        Task<IEnumerable<RoomEvent>> GetRoomEventsByRoomIdAsync(int roomId);
        Task AddRoomEventAsync(RoomEvent roomEvent);
        Task UpdateRoomEventAsync(RoomEvent roomEvent);
        Task DeleteRoomEventAsync(int roomEventId);
    }
}
