using MeetingRoomAPI.Model;

namespace MeetingRoomAPI.Interfaces;

public interface IRoomRepository
{
	Task<IEnumerable<Room>> GetAllRoomsAsync();
	Task<Room> GetRoomByIdAsync(int roomId);
	Task<Room> GetRoomEventsById(int roomId);
	Task AddRoomAsync(Room room);
	Task UpdateRoomAsync(Room room);
	Task DeleteRoomAsync(int roomId);
}
