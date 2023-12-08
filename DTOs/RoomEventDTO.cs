namespace MeetingRoomAPI.DTOs;

public class RoomEventDTO
{
	public int RoomEventId  { get; set; }
	public string Description  { get; set; }
	public DateTime StartTime  { get; set; }
	public DateTime EndTime  { get; set; }
	public int RoomId  { get; set; }
}