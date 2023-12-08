using AutoMapper;
using MeetingRoomAPI.DTOs;
using MeetingRoomAPI.Model;

namespace MeetingRoomAPI.Mapping;

public class MyMapper : Profile
{
	public MyMapper() 
	{
		//CreateMap<Source, Target>().ReverseMap();   
		CreateMap<RoomEvent, RoomEventDTO>().ReverseMap();
		CreateMap<Room, RoomDTO>().ReverseMap();
	}
}
