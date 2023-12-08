using AutoMapper;
using MeetingRoomAPI.DTOs;
using MeetingRoomAPI.Interfaces;
using MeetingRoomAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : Controller
{
	public readonly IRoomRepository _roomRepository;
	private readonly IMapper _mapper;

	public RoomController(IRoomRepository roomRepository, IMapper mapper)
	{
		_roomRepository = roomRepository;
		_mapper = mapper;
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Room>> GetRoom(int id)
	{
		var room = await _roomRepository.GetRoomByIdAsync(id);

		if (room == null)
		{
			return NotFound();
		}

		return Ok(room);
	}
	[HttpGet("eventroom/{id}")]
	public async Task<ActionResult<Room>> GetRoomEventsByRoomId(int id)
	{
		var events = await _roomRepository.GetRoomEventsById(id);

		if (events == null)
		{
			return NotFound();
		}

		return Ok(events);
	}
	[HttpPost]
	public async Task<ActionResult> CreateRoom([FromBody] RoomDTO register) 
	{
		Room newRoom = _mapper.Map<Room>(register);
		await _roomRepository.AddRoomAsync(newRoom);
		return Ok(newRoom);
	}
}
