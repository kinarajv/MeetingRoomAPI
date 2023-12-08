﻿// <auto-generated />
using System;
using MeetingRoomAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeetingRoomAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("MeetingRoomAPI.Model.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Capacity = 1,
                            Description = "RuanganA"
                        },
                        new
                        {
                            RoomId = 2,
                            Capacity = 1,
                            Description = "RuanganB"
                        },
                        new
                        {
                            RoomId = 3,
                            Capacity = 1,
                            Description = "RuanganC"
                        });
                });

            modelBuilder.Entity("MeetingRoomAPI.Model.RoomEvent", b =>
                {
                    b.Property<int>("RoomEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomEventId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomEvents");

                    b.HasData(
                        new
                        {
                            RoomEventId = 1,
                            Description = "EventRuanganA",
                            EndTime = new DateTime(2023, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomId = 1,
                            StartTime = new DateTime(2023, 10, 26, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RoomEventId = 2,
                            Description = "EventRuanganA2",
                            EndTime = new DateTime(2023, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomId = 1,
                            StartTime = new DateTime(2023, 10, 26, 15, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RoomEventId = 3,
                            Description = "EventRuanganA",
                            EndTime = new DateTime(2023, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomId = 2,
                            StartTime = new DateTime(2023, 10, 26, 11, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RoomEventId = 4,
                            Description = "EventRuanganA2",
                            EndTime = new DateTime(2023, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomId = 2,
                            StartTime = new DateTime(2023, 10, 26, 15, 55, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MeetingRoomAPI.Model.RoomEvent", b =>
                {
                    b.HasOne("MeetingRoomAPI.Model.Room", "Room")
                        .WithMany("RoomEvents")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("MeetingRoomAPI.Model.Room", b =>
                {
                    b.Navigation("RoomEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
