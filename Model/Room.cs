namespace MeetingRoomAPI.Model;

public class Room
{
	public int RoomId { get; set; }
	public string Description  { get; set; }
	public int Capacity { get; set; } 
	public ICollection<RoomEvent> RoomEvents  { get; set; }
}
