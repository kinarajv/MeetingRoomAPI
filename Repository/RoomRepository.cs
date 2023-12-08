using Microsoft.EntityFrameworkCore;
using MeetingRoomAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingRoomAPI.Interfaces;
using MeetingRoomAPI.Data;

namespace MeetingRoomAPI.Repositories
{
	public class RoomRepository : IRoomRepository
	{
		private readonly DataContext _context;

		public RoomRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Room>> GetAllRoomsAsync()
		{
			return await _context.Rooms.ToListAsync();
		}

		public async Task<Room> GetRoomByIdAsync(int roomId)
		{
			return await _context.Rooms.FindAsync(roomId);
		}

		public async Task AddRoomAsync(Room room)
		{
			_context.Rooms.Add(room);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateRoomAsync(Room room)
		{
			_context.Entry(room).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteRoomAsync(int roomId)
		{
			var room = await _context.Rooms.FindAsync(roomId);
			if (room != null)
			{
				_context.Rooms.Remove(room);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Room> GetRoomEventsById(int roomId)
		{
			var room = await _context.Rooms.Include(r => r.RoomEvents).FirstOrDefaultAsync(r => r.RoomId == roomId);
			return room;
		}

	}
}
