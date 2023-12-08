using MeetingRoomAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomAPI.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{
	}

	public DbSet<Room> Rooms  { get; set; }
	public DbSet<RoomEvent> RoomEvents  { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Room>(r =>
		{
			r.HasKey(r => r.RoomId);
			r.HasMany(r => r.RoomEvents).WithOne(re => re.Room).HasForeignKey(re => re.RoomId);
		});
		modelBuilder.Entity<RoomEvent>(re =>
		{
			re.HasKey(re => re.RoomEventId);
			re.HasOne(re => re.Room).WithMany(r => r.RoomEvents);
		});
		modelBuilder.Entity<Room>().HasData(
			new Room() {RoomId = 1,Description ="RuanganA",Capacity = 1},
			new Room() {RoomId = 2,Description ="RuanganB",Capacity = 1},
			new Room() {RoomId = 3,Description ="RuanganC",Capacity = 1}
		);
		modelBuilder.Entity<RoomEvent>().HasData(
			new RoomEvent() {
				RoomEventId = 1,
				Description ="EventRuanganA", 
				StartTime = new DateTime(2023, 10, 26, 13, 0, 0),
				EndTime = new DateTime(2023, 10, 26, 14, 0, 0),
				RoomId = 1
			},
			new RoomEvent() {
				RoomEventId = 2,
				Description ="EventRuanganA2", 
				StartTime = new DateTime(2023, 10, 26, 15, 0, 0),
				EndTime = new DateTime(2023, 10, 26, 16, 0, 0),
				RoomId = 1
			},
			new RoomEvent() {
				RoomEventId = 3,
				Description ="EventRuanganA", 
				StartTime = new DateTime(2023, 10, 26, 11, 0, 0),
				EndTime = new DateTime(2023, 10, 26, 14, 0, 0),
				RoomId = 2
			},
			new RoomEvent() {
				RoomEventId = 4,
				Description ="EventRuanganA2", 
				StartTime = new DateTime(2023, 10, 26, 15, 55, 0),
				EndTime = new DateTime(2023, 10, 26, 16, 0, 0),
				RoomId = 2
			}
		);
	}

}
